using BoosterConf.Ef.Ninja.TaskC.Models;
using BoosterConf.Ef.Ninja.TaskC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoosterConf.Ef.Ninja.TaskC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClaimsController(IClaimService claimService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<LifeClaim>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await claimService.GetClaimsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LifeClaim), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(LifeClaim), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await claimService.GetClaimByIdAsync(id);
            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
