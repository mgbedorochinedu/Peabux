using Microsoft.EntityFrameworkCore;
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

                if (businessAge.TotalDays < 365)
                {
                    return new BaseResponse(false, null, "The Business cannot be less than a year.");
                }

                var businessExist = _db.Merchants.Any(x => x.BusinessId.ToLower() == model.BusinessIdNumber.ToLower() 
                && x.MerchantNumber.ToLower() == model.MerchantNumber.ToLower());

                if (businessExist)
                    return new BaseResponse(false, null, $"Business Identification Number: {model?.BusinessIdNumber?.ToUpper()} with Merchant Number: {model?.MerchantNumber?.ToUpper()} already exist.");

                Merchant merchant = new Merchant()
                {
                    BusinessId = model?.BusinessIdNumber?.Trim().ToUpper(),
                    BusinessName = model?.BusinessName,
                    ContactName = model?.ContactName,
                    ContactSurname = model?.ContactSurname,
                    EstablishmentDate = model.EstablishmentDate,
                    MerchantNumber = model?.MerchantNumber?.Trim().ToUpper(),
                    AverageTransaction = model?.AverageTransaction,
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


        public async Task<BaseResponse> GetMerchant(int mechantId)
        {
            try
            {
                var dbMerchant = await _db.Merchants.Where(x => x.MerchantId.Equals(mechantId))
                    .Select(merchant => new GetMerchantModel()
                    {
                        BusinessId = merchant.BusinessId,
                        BusinessName = merchant.BusinessName,
                        ContactName = merchant.ContactName,
                        ContactSurname = merchant.ContactSurname,
                        EstablishmentDate = merchant.EstablishmentDate,
                        MerchantNumber = merchant.MerchantNumber,
                        AverageTransaction = merchant.AverageTransaction,
                    }).FirstOrDefaultAsync();

                if (dbMerchant == null)
                    return new BaseResponse(false, null, $"No Mechant with MechantId: {mechantId} found.");

                return new BaseResponse(true, dbMerchant, "Successfully fetch data.");

            }
            catch (Exception ex)
            {
                //TODO: Handle Exception Log Here...
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }



    }
}
