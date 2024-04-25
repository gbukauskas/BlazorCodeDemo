using BlazorApp_1.CustomErrors;
using BlazorApp_1.DataContext.Models;
using BlazorApp_1.DataContext.RequestResponse;
using BlazorApp_1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace BlazorApp_1.Services
{
    public class CustomerService : INorthWind<Customer>, IPagedCollection<Customer>
    {
        public static readonly double DELTA = 0.000001;

        public Task<Customer> CreateEntity(NorthwindContext ctx, Customer newEntity)
        {
            throw new NotImplementedException();
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

        public Task<Customer> GetEntityById(NorthwindContext ctx, int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
