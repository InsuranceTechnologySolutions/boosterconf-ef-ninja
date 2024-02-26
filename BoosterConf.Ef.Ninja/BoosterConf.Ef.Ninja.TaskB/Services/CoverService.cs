using System.Collections.ObjectModel;
using BoosterConf.Ef.Ninja.TaskB.Models;

namespace BoosterConf.Ef.Ninja.TaskB.Services
{
    public interface ICoverService
    {
        Task<Cover?> GetCoverByIdAsync(Guid id);
        Task<IEnumerable<Cover>> GetCoversAsync();
    }

    public class CoverService : ICoverService   
    {
        public Task<Cover?> GetCoverByIdAsync(Guid id)
        {
            return Task.FromResult<Cover?>(null);               
        }

        public Task<IEnumerable<Cover>> GetCoversAsync()
        {
            return Task.FromResult<IEnumerable<Cover>>(new Collection<Cover>());
        }
    }
}
