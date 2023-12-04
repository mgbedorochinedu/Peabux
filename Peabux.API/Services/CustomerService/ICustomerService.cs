using Peabux.API.Models;
using Peabux.API.ServiceResponse;

namespace Peabux.API.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<BaseResponse> CreateCustomer(CreateCustomerModel model);
    }
}
