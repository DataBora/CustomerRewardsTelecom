using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CustomerRewardsTelecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RewardsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public RewardsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        [HttpPost("AllocateRewards")]
        public async Task<IActionResult> AllocateAwards(int agentid, int customerId, string description, decimal value)
        {
            // Checking if the customer exists in Customers table
            var customerExists = await _dbContext.Customers.AnyAsync(c => c.Id == customerId);
            if (!customerExists)
            {
                return BadRequest("This Custoemr is not our current Customer.");
            }


            var today = DateTime.Today;

            //Checking if agent allocated 5 rewards and customer is not null
            try
            {
                var dailyRewardCount = _dbContext.Rewards
                    .Where(r => r.Customer != null && r.Customer.AgentId == agentid && r.Date.Date == today)
                    .Count();

                if (dailyRewardCount >= 5)
                {
                    return BadRequest("Daily limit is 5 rewards per Agent.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            // Check if the customer already was Reward in Rewarad table
            var existingReward = await _dbContext.Rewards.FirstOrDefaultAsync(r => r.CustomerId == customerId);

            if (existingReward != null)
            {
                // Customer already has a reward entry, update the existing row
                existingReward.RewardLevel = description;
                existingReward.Value = value;
                existingReward.Date = DateTime.Today;
            }
            else
            {
                // Customer does not have a reward entry, create a new row
                var newReward = new Rewards
                {
                    CustomerId = customerId,
                    RewardLevel = description,
                    Value = value,
                    Date = DateTime.Today
                };
                _dbContext.Rewards.Add(newReward);
            }

            await _dbContext.SaveChangesAsync();


            return Ok("Rewards allocated sucesfully");
        }


    }
}
