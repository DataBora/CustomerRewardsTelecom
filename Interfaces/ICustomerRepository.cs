using CustomerRewardsTelecom.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerRewardsTelecom.Interfaces
{
    public interface ICustomerRepository
    {

        Task<Customers?> GetCustomerByIdAsync(int customerId);
    }
}
