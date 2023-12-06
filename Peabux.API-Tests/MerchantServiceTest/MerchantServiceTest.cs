﻿using Microsoft.EntityFrameworkCore;
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


        [Test, Order(1)]
        public async Task GetMerchant_WithResponse_Test()
        {
            var result = await merchantService.GetMerchant(1);
            Assert.That(result.Success, Is.True, "The operation should be successful");

            // Access properties from the data contained in BaseResponse
            var merchantData = result.Data as GetMerchantModel;

            Assert.That(merchantData?.BusinessName, Is.EqualTo("Brandtechture Design Agency"));

            Assert.That(merchantData, Is.Not.Null, "Merchcant data should not be null");
        }


        [Test, Order(2)]
        public async Task GetCustomer_WithoutResponse_Test()
        {
            var result = await merchantService.GetMerchant(60);
            Assert.That(result.Success, Is.False, "The operation should failed because no Customer Id of 60");

            // Access properties from the data contained in BaseResponse
            var merchantData = result.Data as GetMerchantModel;

            Assert.That(merchantData, Is.Null, "Merchant data should be null");
        }



        [Test, Order(3)]
        public async Task AddMerchant_With_Success_Response_Test()
        {
            var newMerchant = new AddMerchantModel()
            {
                BusinessIdNumber = "BUS-4549001239",
                BusinessName = "Primehype Systems Services",
                ContactName = "Ayo",
                ContactSurname = "Adeyemi",
                EstablishmentDate = new DateTime(2018, 07, 12),
                MerchantNumber = "7003412",
                AverageTransaction = 1500000
            };

            var result = await merchantService.AddMerchant(newMerchant);

            Assert.That(result, Is.Not.Null);
            Assert.That(newMerchant?.ContactSurname, Does.StartWith("Adeyemi"));
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(newMerchant?.BusinessIdNumber, Is.EqualTo("BUS-4549001239"));
            Assert.That(result.Success, Is.True, "The operation should saved successful");
        }


        [Test, Order(4)]
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