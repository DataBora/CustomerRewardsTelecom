using CustomerRewardsTelecom.Models;

namespace CustomerRewardsTelecom.Interfaces
{
    public interface IRewardsRepository
    {

        Task<bool> CustomerExistsAsync(string customerId);
        Task<bool> AgentExistsAsync(int agentId);
        Task<int> GetDailyRewardCountAsync(int agentId);
        Task<Rewards?> GetRewardByCustomerIdAsync(string customerId);
        Task AddOrUpdateRewardAsync(string customerId, int agentId, string rewardLevel, decimal discount);
        Task<int> SaveChangesAsync();
    }
}
