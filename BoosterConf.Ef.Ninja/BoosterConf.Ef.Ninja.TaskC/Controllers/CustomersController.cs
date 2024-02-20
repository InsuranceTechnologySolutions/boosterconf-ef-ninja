using BoosterConf.Ef.Ninja.TaskC.Models;
using BoosterConf.Ef.Ninja.TaskC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoosterConf.Ef.Ninja.TaskC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Customer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await customerService.GetCustomersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await customerService.GetCustomerByIdAsync(id);
            return Ok(result);
        }
    }
}
