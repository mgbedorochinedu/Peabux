using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peabux.API.Models;
using Peabux.API.Services.MerchantService;

namespace Peabux.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }


        /// <summary>
        /// Add Merchant to the database.
        /// </summary>
        /// <param name="model">The fields are required except AverageTransaction. It also accept the "CustomerId" to keep track of the customer creating the Merchant.</param>
        /// <returns>Returns success message if everything is saved successful, or error message indicating something went wrong.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddMerchant([FromBody] AddMerchantModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _merchantService.AddMerchant(model);
            return Ok(response);
        }

    }
}
