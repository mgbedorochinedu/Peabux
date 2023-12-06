using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Peabux.API.Data;
using Peabux.API.Entities;
using Peabux.API.Models;
using Peabux.API.Services.MerchantService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peabux.API_Tests.MerchantServiceTest
{
    public class MerchantServiceTest
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "MerchantDbTest")
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


        [Test, Order(1)]
        public async Task AddMerchant_With_Failed_Response_Test()
        {
            var newMerchant = new AddMerchantModel()
            {
                BusinessIdNumber = "",
                BusinessName = "Primehype Systems Services",
                ContactName = "Ayo",
                ContactSurname = "Adeyemi",
                EstablishmentDate = new DateTime(2018, 07, 12),
                MerchantNumber = "7003412",
                AverageTransaction = 1500000
            };

            // Manually validate the model to simulate ModelState.IsValid failure
            var validationContext = new ValidationContext(newMerchant, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(newMerchant, validationContext, validationResults, validateAllProperties: true);

            // Assert that the model state is invalid
            Assert.IsFalse(isValid);

            Assert.That(newMerchant?.BusinessIdNumber, Is.Empty);
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
                    AverageTransaction = 210000

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
                    AverageTransaction = 150000
                  }
            };
            dbContext.Merchants.AddRange(merchants);

            dbContext.SaveChanges();
        }







    }
}
