using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Models;
using System.Globalization;
using System.Threading.Tasks;

namespace CustomerRewardsTelecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public AgentsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("InsertAgents")]
        public async Task<IActionResult> InsertAgentsIntoDatabase([FromBody] Agents agents)
        {
            if (agents == null)
            {
                return BadRequest("Bad request");
            }

            try
            {
                // Add the agent to the database
                _dbContext.Agents.Add(agents);
                await _dbContext.SaveChangesAsync();

                return Ok("Agent inserted successfully");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
