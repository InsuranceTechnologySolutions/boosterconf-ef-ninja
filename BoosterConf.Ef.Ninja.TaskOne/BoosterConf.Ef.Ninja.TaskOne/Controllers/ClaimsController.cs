using BoosterConf.Ef.Ninja.TaskOne.Models;
using BoosterConf.Ef.Ninja.TaskOne.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoosterConf.Ef.Ninja.TaskOne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClaimsController(IClaimService claimService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Claim>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await claimService.GetClaimsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Claim), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Claim), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await claimService.GetClaimByIdAsync(id);
            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
