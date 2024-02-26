using System.Collections.ObjectModel;
using BoosterConf.Ef.Ninja.TaskB.Solved.Models;

namespace BoosterConf.Ef.Ninja.TaskB.Solved.Services
{
    public interface IClaimService
    {
        Task<Claim?> GetClaimByIdAsync(Guid id);
        Task<IEnumerable<Claim>> GetClaimsAsync();
    }

    public class ClaimService : IClaimService   
    {
        public Task<Claim?> GetClaimByIdAsync(Guid id)
        {
            return Task.FromResult<Claim?>(null);
        }

        public Task<IEnumerable<Claim>> GetClaimsAsync()
        {
            return Task.FromResult<IEnumerable<Claim>>(new Collection<Claim>());
        }
    }
}
