using System.Collections.ObjectModel;
using BoosterConf.Ef.Ninja.TaskC.Models;

namespace BoosterConf.Ef.Ninja.TaskC.Services
{
    public interface IClaimService
    {
        Task<LifeClaim?> GetClaimByIdAsync(Guid id);
        Task<IEnumerable<LifeClaim>> GetClaimsAsync();
    }

    public class ClaimService : IClaimService   
    {
        public Task<LifeClaim?> GetClaimByIdAsync(Guid id)
        {
            return Task.FromResult<LifeClaim?>(null);
        }

        public Task<IEnumerable<LifeClaim>> GetClaimsAsync()
        {
            return Task.FromResult<IEnumerable<LifeClaim>>(new Collection<LifeClaim>());
        }
    }
}
