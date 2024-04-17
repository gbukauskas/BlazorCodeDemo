using BlazorApp_1.DataContext.Models;
using BlazorApp_1.Services.Interfaces;

namespace BlazorApp_1.Services
{
    public class CustomerService : INorthWind<Customer>
    {
        public Task<Customer> CreateEntity(NorthwindContext ctx, Customer newEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> GetAllEntities(NorthwindContext ctx)
        {
            throw new NotImplementedException();
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
