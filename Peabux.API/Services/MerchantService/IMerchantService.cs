using Peabux.API.Models;
using Peabux.API.ServiceResponse;

namespace Peabux.API.Services.MerchantService
{
    public interface IMerchantService
    {
        Task<BaseResponse> AddMerchant(AddMerchantModel model);
        Task<BaseResponse> GetMerchant(int mechantId);
    }
}
