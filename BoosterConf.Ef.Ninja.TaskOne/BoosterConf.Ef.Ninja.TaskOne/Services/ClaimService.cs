using System.Collections.ObjectModel;
using BoosterConf.Ef.Ninja.TaskOne.Models;

namespace BoosterConf.Ef.Ninja.TaskOne.Services
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
