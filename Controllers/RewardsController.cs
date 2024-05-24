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
            // Checking if the customer exists
            var customerExists = await _dbContext.Customers.AnyAsync(c => c.Id == customerId);
            if (!customerExists)
            {
                return BadRequest("Customer not found.");
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

            var reward = new Rewards
            {
                CustomerId = customerId,
                Description = description,
                Value = value,
                Date = today
            };

            _dbContext.Rewards.Add(reward);

            await _dbContext.SaveChangesAsync();


            return Ok("Rewards allocated sucesfully");
        }


    }
}
