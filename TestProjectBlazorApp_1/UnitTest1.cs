using BlazorApp_1.DataContext.Models;
using BlazorApp_1.Services;
using BlazorApp_1.Services.Interfaces;
using TestProjectBlazorApp_1.Tools;

namespace TestProjectBlazorApp_1
{
    public class UnitTest1
    {
        private INorthWind<Customer> CustomerSvc;
        private IPagedCollection<Customer> PageSvc;

        public UnitTest1()
        {
            var x = new CustomerService();
            CustomerSvc = x;
            PageSvc = x;
        }

        [Fact]
        public void Test1()
        {
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                int allCustomers = CustomerSvc.GetAllEntities(context).Count();
                Assert.Equal(91, allCustomers);
            }
        }

        [Fact]
        public async Task Test2()
        {
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                var tmp = CustomerSvc.GetAllEntities(context);
                var page = await PageSvc.GetPageAsync(tmp, 10, 2);
                
                Assert.NotNull(page?.Items);
                var item = page.Items.First();
                Assert.NotNull(item);
                Assert.Equal("BSBEV", item.CustomerId);
            }
        }

        [Fact]
        public async Task Test3()
        {
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                var tmp = CustomerSvc.GetAllEntities(context)
                            .Where(x => x.Country == "Brazil")
                            .OrderBy(x => x.ContactName);
                var page = await PageSvc.GetPageAsync(tmp, 10, 1);

                Assert.NotNull(page?.Items);
                var item = page.Items.First();
                Assert.NotNull(item);
                Assert.Equal("TRADH", item.CustomerId);
            }
        }

    }
}