using CustomerRewardsTelecom.Models;

namespace CustomerRewardsTelecom.Interfaces
{
    public interface IRewardsRepository
    {

        Task<bool> CustomerExistsAsync(string customerId);
        Task<bool> AgentExistsAsync(string agentId);
        Task<int> GetDailyRewardCountAsync(string agentId);
        Task<Rewards?> GetRewardByCustomerIdAsync(string customerId);
        Task AddOrUpdateRewardAsync(string customerId, string agentId, string rewardLevel, decimal discount);
        Task<int> SaveChangesAsync();
    }
}
