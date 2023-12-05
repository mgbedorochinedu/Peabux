using Peabux.API.Data;
using Peabux.API.Entities;
using Peabux.API.Models;
using Peabux.API.ServiceResponse;

namespace Peabux.API.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _db;

        public CustomerService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<BaseResponse> CreateCustomer(CreateCustomerModel model)
        {
            try
            {
                var nationalIdExist =  _db.Customers.Any(x => x.NationalID.ToLower() == model.NationalID.ToLower());
                if(nationalIdExist)
                    return new BaseResponse(false, null, "National Identication Number already exist.");

                var customberNumberExist = _db.Customers.Any(x => x.CustomerNumber.ToLower() == model.CustomerNumber.ToLower());
                if (customberNumberExist)
                    return new BaseResponse(false, null, "Customer Number already exist.");

                if (!IsAbove18(model.DOB)) 
                { 
                    return new BaseResponse(false, null, "You must be 18 years to proceed with this application.");
                }

                Customer customer = new Customer()
                {
                    NationalID = model?.NationalID?.ToUpper(),
                    Name = model?.Name?.ToUpper(),
                    Surname = model?.Surname,
                    DOB = model?.DOB,
                    CustomerNumber = model?.CustomerNumber,
                    TransactionHistory = model?.TransactionHistory,
                    CreatedAt = DateTime.Now
                };
                await _db.AddAsync(customer);
                var isSaved = await _db.SaveChangesAsync();
                if (isSaved > 0)
                {
                    return new BaseResponse(true, customer.CustomerId, $"Successfully create a Customer with CustomerID: {customer.CustomerId}.");
                }
                else
                {
                    return new BaseResponse(false, null, "An error occur trying to create Customer. Try Again Later.");
                }

            }
            catch (Exception ex)
            {
                //TODO: Handle Exception Log Here...
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }

        public static bool IsAbove18(DateTime birthdate)
        {
            var today = DateTime.Now;
            var age = today.Year - birthdate.Year;

            if (birthdate.Month > today.Month || (birthdate.Month == today.Month && birthdate.Day > today.Day))
            {
                age--;
            }
            return age >= 18;
        }









    }
}
