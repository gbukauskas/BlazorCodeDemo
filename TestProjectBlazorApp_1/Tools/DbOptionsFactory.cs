using BlazorApp_1.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestProjectBlazorApp_1.Tools
{
    public static class DbOptionsFactory
    {
        static DbOptionsFactory()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config["ConnectionStrings:DefaultConnection"];

            DbContextOptions = new DbContextOptionsBuilder<NorthwindContext>()
            .UseSqlServer(connectionString)
                .Options;
        }

        public static DbContextOptions<NorthwindContext> DbContextOptions { get; }

    }
}
