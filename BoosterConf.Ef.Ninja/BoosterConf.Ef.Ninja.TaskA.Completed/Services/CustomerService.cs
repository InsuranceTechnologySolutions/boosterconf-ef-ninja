using System.Collections.ObjectModel;
using BoosterConf.Ef.Ninja.TaskA.Solved.Models;

namespace BoosterConf.Ef.Ninja.TaskA.Solved.Services
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerByIdAsync(Guid id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }

    public class CustomerService : ICustomerService 
    {
        public Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return Task.FromResult<Customer?>(null);
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return Task.FromResult<IEnumerable<Customer>>(new Collection<Customer>());            
        }
    }
}
