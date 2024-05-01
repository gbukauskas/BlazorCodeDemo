using BlazorApp_1.CustomErrors;
using BlazorApp_1.DataContext.Models;
using BlazorApp_1.Services;
using BlazorApp_1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using TestProjectBlazorApp_1.Tools;

namespace TestProjectBlazorApp_1
{
    public class UnitTest1
    {
        private INorthWind<Customer, string> CustomerSvc;
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
        
        [Fact]
        public async Task Test4()
        {
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                var tmp = await CustomerSvc.GetEntityByIdAsync(context, "AROUT");
                Assert.Equal("120 Hanover Sq.", tmp?.Address);
            }
        }

        [Fact]
        public async Task Test5()
        {
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                try
                {
                    var tmp = await CustomerSvc.GetEntityByIdAsync(context, "ARRUT");
                }
                catch (NotFoundException ex)
                {
                    Assert.Equal("Customer with ID=ARRUT was not found.", ex.Message);
                }
            }
        }
        [Fact]
        public async Task Test6()
        {
            var newEntity = CreateCustomer("ANTUN");
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                try
                {
                    var tmp = await CustomerSvc.CreateEntity(context, newEntity);
                    Assert.Equal("ANTUN", tmp.CustomerId);
                }
                catch (DataBaseUpdateException ex)
                {
                    Assert.Equal("Customer with ID=ANTON was not inserted.", ex.Message);
                }
            }
        }
        private Customer CreateCustomer(string customerId)
        {
            return new Customer()
            {
                CustomerId = customerId,
                CompanyName = "Antonio Moreno Taquería",
                ContactName = "Antonio Moreno",
                ContactTitle = "Owner",
                Address = "Mataderos  2312",
                City = "México D.F.",
                Region = "Acapulko",
                PostalCode = "05023",
                Country = "Mexico",
                Phone = "(5) 555-3932",
                Fax = "(5) 555-3745"
            };
        }

        [Fact]
        public async Task Test6a()
        {
            var entityCollection = new List<Customer>()
            {
                 CreateCustomer("JIM_1"),
                 CreateCustomer("JIM_2"),
                 CreateCustomer("JIM_3")
            };
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                var tmp = await CustomerSvc.CreateEntities(context, entityCollection);
                Assert.Equal(3, tmp.Count());
            }
        }

        [Fact]
        public async Task Test6b()
        {
            var entityCollection = new List<Customer>()
            {
                    CreateCustomer("ANATR"),
                    CreateCustomer("ANTON"),
            };
            try
            {
                using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
                {
                    var tmp = await CustomerSvc.CreateEntities(context, entityCollection);
                    Assert.Equal(3, tmp.Count());
                }
            }
            catch (DataBaseUpdateException ex)
            {
                Assert.True(ex.Message.Contains("ANATR") && ex.Message.Contains("ANTON"));
            }
        }

        [Fact]
        public async Task Test7()
        {
            var newEntity = CreateCustomer("ANTON");
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                try
                {
                    var tmp = await CustomerSvc.CreateEntity(context, newEntity);
                }
                catch (DataBaseUpdateException ex)
                {
                    Assert.Equal("Customer with ID=ANTON was not inserted.", ex.Message);
                }
            }
        }

        [Fact]
        public async Task Test8()
        {
            var newEntity = CreateCustomer("ANTUN");
            newEntity.City = "Kaunas";
            newEntity.Country = "Lithuania";
            try
            {
                using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
                {
                    var tmp = await CustomerSvc.UpdateEntity(context, newEntity);
                    Assert.True(tmp != null);
                    Assert.Equal("Lithuania", tmp?.Country);
                }
            }
            catch (DatabaseException ex)
            {
                Assert.Equal("Customer ID=ANTUN was not updated", ex.Message);
            }
        }

        [Fact]
        public async Task Test9()
        {
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            {
                var tmp = await CustomerSvc.DeleteEntityByIdAsync(context, "ANTUN");
                Assert.Equal("ANTUN", tmp);
            }
        }


        [Fact]
        public async Task Test10()
        {
            try
            {
                using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
                {
                    var tmp = await CustomerSvc.DeleteEntityByIdAsync(context, "BLAUS");
                }
            }
            catch (DataBaseUpdateException ex)
            {
                Assert.Equal("Customer with ID=BLAUS was not deleted.", ex.Message);
            }
        }

        [Fact]
        public async Task Test11()
        {
            using (var context = new NorthwindContext(DbOptionsFactory.DbContextOptions))
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int wereDeleted = await CustomerSvc
                        .GetAllEntities(context)
                        .Where(ent => ent.CustomerId.StartsWith("JIM"))
                        .ExecuteDeleteAsync();
                    Assert.Equal(3, wereDeleted);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}