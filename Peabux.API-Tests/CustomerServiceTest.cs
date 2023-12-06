using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Peabux.API.Data;
using Peabux.API.Entities;
using System;
using System.Collections.Generic;

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

            SeedDatabase();
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            dbContext.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var customers = new List<Customer>
            {
                new Customer()
                {
                    CustomerId = 1,
                    NationalID = "5412-7512-3412-3456",
                    Name = "Amadi",
                    Surname = "Ahmed",
                    DOB = new DateTime(1967, 11, 3),
                    CustomerNumber = "CUS1323970",
                    TransactionHistory = "None"
                },

                 new Customer()
                 {
                    CustomerId = 2,
                    NationalID = "9999-7512-6722-3456",
                    Name = "Chinedu",
                    Surname = "Okafor",
                    DOB = new DateTime(1980, 06, 14),
                    CustomerNumber = "CUS2113970",
                    TransactionHistory = "None"
                }

            };
            dbContext.Customers.AddRange(customers);


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