using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Peabux.API.Data;
using Peabux.API.Entities;
using Peabux.API.Services.MerchantService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peabux.API_Tests.MerchantServiceTest
{
    public class MerchantServiceTest
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "PeabuxDbTest")
            .Options;

        AppDbContext dbContext;

        MerchantService merchantService;


        public void Setup()
        {
            dbContext = new AppDbContext(dbContextOptions);
            dbContext.Database.EnsureCreated();

            SeedDatabase();

            merchantService = new MerchantService(dbContext);
        }





















        [OneTimeTearDown]
        public void CleanUp()
        {
            dbContext.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
  
            var merchants = new List<Merchant>
            {
                new Merchant()
                {
                    MerchantId = 1,
                    BusinessId = "1059001239",
                    BusinessName = "Brandtechture Design Agency",
                    ContactName = "Austin",
                    ContactSurname = "Johnson",
                    EstablishmentDate = new DateTime(2000, 07, 12),
                    MerchantNumber = "1933412",
                    AverageTransaction = 2100000

                },

                  new Merchant()
                  {
                    MerchantId = 2,
                    BusinessId = "4549001239",
                    BusinessName = "Primehype Systems Services",
                    ContactName = "Ayo",
                    ContactSurname = "Adeyemi",
                    EstablishmentDate = new DateTime(2018, 07, 12),
                    MerchantNumber = "7003412",
                    AverageTransaction = 1500000
                  }
            };
            dbContext.Merchants.AddRange(merchants);

            dbContext.SaveChanges();
        }







    }
}
