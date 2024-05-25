using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Interfaces;
using CustomerRewardsTelecom.Models;
using Microsoft.EntityFrameworkCore;


namespace CustomerRewardsTelecom.Repositories
{
    public class PurchasesRepository : IPurchaseRepository
    {
        private readonly ApplicationDBContext _dbContext;
        

        public PurchasesRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
          
        }

        public async Task<Purchases?> GetPurchasesAsync(string customerId, DateTime date, decimal amount)
        {
            return await _dbContext.Purchases.FirstOrDefaultAsync(p => p.CustomerId == customerId && p.Date == date && p.Amount == amount);
        }

        public async Task AddPurchaseAsync(Purchases purchase)
        {
            await _dbContext.Purchases.AddAsync(purchase);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
