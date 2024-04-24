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

        public async Task<PageResponse<Customer>> GetPage(NorthwindContext ctx, int pageSize, int pageNumber)
        {
            Func<int, IEnumerable<Customer>, PageResponse<Customer>> buildAnswer = delegate (int recordCount, IEnumerable<Customer> items)
            {
                double pgCount = (double)recordCount / (double)pageSize;
                double integral = Math.Truncate(pgCount);
                double fractional = Math.Abs(pgCount - integral);
                return new PageResponse<Customer>()
                {
                    TotalRecords = recordCount,
                    TotalPages = fractional <= DELTA ? (int)integral : (int)integral + 1,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                    Items = items
                };
            };

            Debug.Assert(ctx != null && pageSize > 0 && pageNumber >= 0);   // pageNumber == 0 returns all records (no paging)
            try
            {
                int recordsCount = await GetAllEntities(ctx).CountAsync();
                if (recordsCount < 1) 
                {
                    return buildAnswer(recordsCount, []);
                }
                else
                {
                    var pageContent = await GetAllEntities(ctx)
                                                .Skip<Customer>((pageNumber - 1) * pageSize)
                                                .Take<Customer>(pageSize)
                                                .ToArrayAsync();
                    return buildAnswer(recordsCount, pageContent);
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
