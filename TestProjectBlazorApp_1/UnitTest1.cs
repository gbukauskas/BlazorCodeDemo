using BlazorApp_1.DataContext.Models;
using BlazorApp_1.Services;
using BlazorApp_1.Services.Interfaces;
using TestProjectBlazorApp_1.Tools;

namespace TestProjectBlazorApp_1
{
    public class UnitTest1
    {
        private INorthWind<Customer> CustomerSvc;

        public UnitTest1()
        {
            CustomerSvc = new CustomerService();
        }

        [Fact]
        public void Test1()
        {
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                var allCustomers = CustomerSvc.GetAllEntities(context);
            }
        }
    }
}