using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Peabux.API.Data;

namespace Peabux.API_Tests
{
    public class CustomerServiceTest
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "PeabuxDbTest")
            .Options;

        AppDbContext dbContext;


        [OneTimeSetUp]
        public void Setup()
        {
            dbContext = new AppDbContext(dbContextOptions);
            dbContext.Database.EnsureCreated();
        }

    }
}