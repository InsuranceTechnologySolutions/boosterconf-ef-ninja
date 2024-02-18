using BoosterConf.Ef.Ninja.TaskA.Completed.Models;
using BoosterConf.Ef.Ninja.TaskA.Completed.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoosterConf.Ef.Ninja.TaskA.Completed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoversController(ICoverService coverService)
        : ControllerBase
    {        
        
        [HttpGet()]
        [ProducesResponseType(typeof(ICollection<Cover>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await coverService.GetCoversAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cover), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Cover), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await coverService.GetCoverByIdAsync(id);
            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
