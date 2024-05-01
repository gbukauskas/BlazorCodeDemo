using BlazorApp_1.CustomErrors;
using BlazorApp_1.DataContext.Models;
using BlazorApp_1.DataContext.RequestResponse;
using BlazorApp_1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BlazorApp_1.Services
{
    public class CustomerService : INorthWind<Customer, string>, IPagedCollection<Customer>
    {
        /// <summary>
        /// Precision for comparision of double constatns
        /// </summary>
        public static readonly double DELTA = 0.000001;

        /// <summary>
        /// The function creates new entity.
        /// </summary>
        /// <param name="ctx">
        ///     <see cref="NorthwindContext"/>
        /// </param>
        /// <param name="newEntity"></param>
        /// <returns>
        ///     <see cref="Customer"/>
        /// </returns>
        /// <exception cref="DataBaseUpdateException">Key value is already registerd</exception>
        public async Task<Customer> CreateEntity(NorthwindContext ctx, Customer newEntity)
        {
            try
            {
                ctx.Add(newEntity);
                await ctx.SaveChangesAsync();
                return newEntity;
            }
            catch (DbUpdateException ex)
            {
                string message = $"Customer with ID={newEntity.CustomerId} was not inserted.";
                throw new DataBaseUpdateException(message, ex);
            }
        }

        // https://learn.microsoft.com/en-us/ef/core/saving/
        // https://learn.microsoft.com/en-us/ef/core/saving/execute-insert-update-delete
        /// <summary>
        /// This method updates all properties of the <code>Customer</code> object.
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="DatabaseException"></exception>
        public async Task<Customer> UpdateEntity(NorthwindContext ctx, Customer entity)
        {
            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    Customer customer = await GetEntityByIdAsync(ctx, entity.CustomerId);
                    customer.CompanyName = entity.CompanyName;
                    customer.ContactName = entity.ContactName;
                    customer.ContactTitle = entity.ContactTitle;
                    customer.Address = entity.Address;
                    customer.City = entity.City;
                    customer.Region = entity.Region;
                    customer.PostalCode = entity.PostalCode;
                    customer.Country = entity.Country;
                    customer.Phone = entity.Phone;
                    customer.Fax = entity.Fax;

                    await ctx.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return customer;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new DatabaseException($"Customer ID={entity.CustomerId} was not updated", ex);
                }
            }
        }

        /// <summary>
        /// The function inserts into dtatbase some entities
        /// </summary>
        /// <param name="ctx"><see cref="NorthwindContext"/></param>
        /// <param name="collection">Collection of new entitis</param>
        /// <returns>Collection of inserted items</returns>
        /// <exception cref="DataBaseUpdateException"></exception>
        public async Task<IEnumerable<Customer>> CreateEntities(NorthwindContext ctx, IEnumerable<Customer> collection)
        {
            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    await ctx.Customers.AddRangeAsync(collection);
                    await ctx.SaveChangesAsync(); 
                    await transaction.CommitAsync();
                    return collection;
                }
                catch (Exception ex)
                {
                    var acc  = new StringBuilder("");
                    StringBuilder idList = new StringBuilder("");
                    string message = "Customers were not stored";
                    if (collection != null)
                    {
                        string[] tmp = collection.Select(x => x.CustomerId).ToArray();
                        string customerIdList = tmp.Aggregate((x, y) => x + " " + y);
                        if (customerIdList.Length > 100)
                        {
                            customerIdList = customerIdList[..97] + "...";
                        }
                        message = $"Customers with ID '{customerIdList}' were not stored";
                    }
                    throw new DataBaseUpdateException(message, ex);
                }
            }
        }

        /// <summary>
        /// Returns all records from the database
        /// </summary>
        /// <param name="ctx">
        ///     <see cref="NorthwindContext"/>
        /// </param>
        /// <returns>Queryable collection</returns>
        public IQueryable<Customer> GetAllEntities(NorthwindContext ctx)
        {
            Debug.Assert(ctx != null);
            return ctx.Customers;
        }

        /// <summary>
        /// Returns entity which key is equal to value in the second parameter
        /// </summary>
        /// <param name="ctx">
        ///     <see cref="NorthwindContext"/>
        /// </param>
        /// <param name="id">Primary key</param>
        /// <returns>
        ///     <see cref="Customer"/>
        /// </returns>
        /// <exception cref="NotFoundException"><see cref="NotFoundException"/></exception>
        public async Task<Customer> GetEntityByIdAsync(NorthwindContext ctx, string id)
        {
            Customer? answer = await ctx.Customers.FindAsync(id);
            if (answer == null)
            {
                string message = $"Customer with ID={id} was not found.";
                throw new NotFoundException(message);
            }
            return answer;
        }

        /// <summary>
        /// The function returns one page, <see cref="PageResponse<T>"/>
        /// </summary>
        /// <param name="collection">Passing IQuerable instead of <code>NorthwindContext</code>simplifies sorting and filtering</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageNumber">Number of the page. Numbering starts from 1.</param>
        /// <returns><see cref="PageResponse"/></returns>
        /// <exception cref="DatabaseException"></exception>
        public async Task<PageResponse<Customer>> GetPageAsync(IQueryable<Customer> collection, int pageSize, int pageNumber)
        {
            Func<int, int, int, IEnumerable<Customer>, PageResponse<Customer>> buildAnswer = 
                delegate (int recordCount, int pageNumber, int totalPages, IEnumerable< Customer> items)
            {
                return new PageResponse<Customer>()
                {
                    TotalRecords = recordCount,
                    TotalPages = totalPages,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                    Items = items
                };
            };

            Debug.Assert(collection != null && pageSize > 0 && pageNumber >= 0);   // pageNumber == 0 returns last page
            try
            {
                int recordsCount = await collection.CountAsync();
                if (recordsCount < 1)
                {
                    return buildAnswer(recordsCount, 0, 0, []);
                }
                else
                {
                    double pgCount = (double)recordsCount / (double)pageSize;
                    double integral = Math.Truncate(pgCount);
                    double fractional = Math.Abs(pgCount - integral);
                    int totalPages = fractional <= DELTA ? (int)integral : (int)integral + 1;
                    int currentPage = (pageNumber < 1) ? totalPages
                                                       : pageNumber > totalPages ? 1 : pageNumber;

                    var pageContent = await collection
                                                .Skip<Customer>((currentPage - 1) * pageSize)
                                                .Take<Customer>(pageSize)
                                                .ToArrayAsync();

                    return buildAnswer(recordsCount, currentPage, totalPages, pageContent);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("GetPage failed.", ex);
            }
        }

        /// <summary>
        /// The function removes entity from the database
        /// </summary>
        /// <param name="ctx"><see cref="NorthwindContext"/></param>
        /// <param name="id">ID of the record which would be deleted.</param>
        /// <returns>ID of the removed record</returns>
        /// <exception cref="DataBaseUpdateException"></exception>
        public async Task<string> DeleteEntityByIdAsync(NorthwindContext ctx, string id)
        {
            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    Customer customer = new Customer { CustomerId = id };
                    ctx.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    await ctx.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return id;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new DataBaseUpdateException($"Customer with ID={id} was not deleted.", ex);
                }
            }
        }
    }
}
