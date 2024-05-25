using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CustomerRewardsTelecom.Interfaces;


namespace CustomerRewardsTelecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RewardsController : ControllerBase
    {
        private readonly IRewardsRepository _rewardRepository;

        public RewardsController(IRewardsRepository rewardRepository)
        {
            _rewardRepository = rewardRepository;
        }

        [HttpPost("AllocateRewards")]
        public async Task<IActionResult> AllocateAwards(int agentId, int customerId, string rewardLevel, decimal discount)
        {
            try
            {
                var customerExists = await _rewardRepository.CustomerExistsAsync(customerId);
                if (!customerExists)
                {
                    return BadRequest("This Customer is not our current Customer.");
                }

                var agentExists = await _rewardRepository.AgentExistsAsync(agentId);
                if (!agentExists)
                {
                    return BadRequest("We don't have this Agent in our company.");
                }

                var dailyRewardCount = await _rewardRepository.GetDailyRewardCountAsync(agentId);
                if (dailyRewardCount >= 5)
                {
                    return BadRequest("Daily limit is 5 rewards per Agent.");
                }

                await _rewardRepository.AddOrUpdateRewardAsync(customerId, agentId, rewardLevel, discount);
                await _rewardRepository.SaveChangesAsync();

                return Ok("Rewards allocated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"UPS! We can't do that :(  Check for REWARD LEVEL (Bronze, Silver, Gold). {ex.Message}");
            }
        }
    }
}
