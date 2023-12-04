using Peabux.API.Data;
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

            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
