using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peabux.API.Models;
using Peabux.API.Services.CustomerService;

namespace Peabux.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerModel model)
        {          
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = await _customerService.CreateCustomer(model);
                return Ok(response);                      
        }
    }
}
