using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Interfaces;
using CustomerRewardsTelecom.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerRewardsTelecom.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CustomerRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customers?> GetCustomerByIdAsync(int customerId)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }
    }
}
