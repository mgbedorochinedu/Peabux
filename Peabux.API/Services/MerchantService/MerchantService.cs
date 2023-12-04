using Peabux.API.Data;
using Peabux.API.Entities;
using Peabux.API.Models;
using Peabux.API.ServiceResponse;

namespace Peabux.API.Services.MerchantService
{
    public class MerchantService : IMerchantService
    {
        private readonly AppDbContext _db;

        public MerchantService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<BaseResponse> AddMerchant(AddMerchantModel model)
        {
            try
            {
                DateTime currentDate = DateTime.Today;
                var businessAge = currentDate - model.EstablishmentDate;

                if (businessAge?.TotalDays < 365)
                {
                    return new BaseResponse(false, null, "The Business cannot be less than a year.");
                }

                Merchant merchant = new Merchant()
                {
                    BusinessId = model.BusinessIdNumber,
                    BusinessName = model.BusinessName,
                    ContactName = model.ContactName,
                    ContactSurname = model.ContactSurname,
                    EstablishmentDate = model.EstablishmentDate,
                    MerchantNumber = model.MerchantNumber,
                    AverageTransaction = model.AverageTransaction,
                    CustomerId = model.CustomerId,
                    CreatedAt = DateTime.Now,
                };
                await _db.AddAsync(merchant);
                var isSaved = await _db.SaveChangesAsync();
                if(isSaved > 0)
                {
                    return new BaseResponse(true, null, "Successfully saved Merchant.");
                }
                else
                {
                    return new BaseResponse(false, null, "An error occur trying to save Merchant. Try Again Later.");
                }
            }
            catch (Exception ex)
            {
                //TODO: Handle Exception Log Here...
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }

        }



    }
}
