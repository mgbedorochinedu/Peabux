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



        /// <summary>
        /// Create customer to the database.
        /// </summary>
        /// <param name="model">Some of the field are required.</param>
        /// <returns>Returns success message if everything is saved successful, or error message indicating something went wrong.</returns>
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



        /// <summary>
        /// Get a single customer on the database by Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Return a single customer. </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomer([FromQuery] int customerId)
        {
            var response = await _customerService.GetCustomer(customerId);
            return Ok(response);
        }



    }
}
