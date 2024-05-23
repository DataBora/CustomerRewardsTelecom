using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.DTOs;
using CustomerRewardsTelecom.Models;
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
        public async Task<IActionResult> InsertAgentsIntoDatabase([FromBody] AgentsPostDto agentsPostDto)
        {
            if (agentsPostDto == null)
            {
                return BadRequest("Bad request");
            }

            try
            {
                // Map the DTO to the entity
                var agent = new Agents
                {
                    Name = agentsPostDto.Name
                };

                // Add the agent to the database
                _dbContext.Agents.Add(agent);
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
