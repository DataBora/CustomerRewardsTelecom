using CustomerRewardsTelecom.Models;

namespace CustomerRewardsTelecom.Interfaces
{
    public interface IRewardsRepository
    {

        Task<bool> CustomerExistsAsync(int customerId);
        Task<bool> AgentExistsAsync(int agentId);
        Task<int> GetDailyRewardCountAsync(int agentId);
        Task<Rewards?> GetRewardByCustomerIdAsync(int customerId);
        Task AddOrUpdateRewardAsync(int customerId, int agentId, string rewardLevel, decimal discount);
        Task<int> SaveChangesAsync();
    }
}
