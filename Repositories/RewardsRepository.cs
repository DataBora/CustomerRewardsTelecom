using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Interfaces;
using CustomerRewardsTelecom.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerRewardsTelecom.Repositories
{
    public class RewardsRepository : IRewardsRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public RewardsRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CustomerExistsAsync(string customerId)
        {
            return await _dbContext.Customers.AnyAsync(c => c.CustomerId == customerId);
        }

        public async Task<bool> AgentExistsAsync(int agentId)
        {
            return await _dbContext.Customers.AnyAsync(a => a.AgentId == agentId);
        }

        public async Task<int> GetDailyRewardCountAsync(int agentId)
        {
            var today = DateTime.Today;
            return await _dbContext.Rewards
                .Where(r => r.Customer != null && r.Customer.AgentId == agentId && r.Date.Date == today)
                .CountAsync();
        }

        public async Task<Rewards?> GetRewardByCustomerIdAsync(string customerId)
        {
            return await _dbContext.Rewards.FirstOrDefaultAsync(r => r.CustomerId == customerId);
        }

        public async Task AddOrUpdateRewardAsync(string customerId, int agentId, string rewardLevel, decimal discount)
        {
            var existingReward = await _dbContext.Rewards.FirstOrDefaultAsync(r => r.CustomerId == customerId);

            if (existingReward != null)
            {
                // Customer already has a reward entry, update the existing row
                existingReward.RewardLevel = rewardLevel;
                existingReward.Discount = discount;
                existingReward.Date = DateTime.Today;
            }
            else
            {
                // Customer does not have a reward entry, create a new row
                var newReward = new Rewards
                {
                    CustomerId = customerId,
                    RewardLevel = rewardLevel,
                    Discount = discount,
                    Date = DateTime.Today
                };
                _dbContext.Rewards.Add(newReward);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
