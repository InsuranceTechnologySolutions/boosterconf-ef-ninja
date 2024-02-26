using System.Collections.ObjectModel;
using BoosterConf.Ef.Ninja.TaskA.Models;

namespace BoosterConf.Ef.Ninja.TaskA.Services
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
