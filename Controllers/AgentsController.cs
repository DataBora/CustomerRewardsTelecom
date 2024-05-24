using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.DTOs;
using CustomerRewardsTelecom.Models;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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

        [HttpPost("InsertAgentIntoDB")]
        public async Task<IActionResult> InsertAgentsIntoDatabase(string agentName)
        {
           

            if (string.IsNullOrEmpty(agentName))
            {
              
                return BadRequest("Agent name is missing or invalid.");
            }

            try
            {
                    // Map the DTO to the entity
                    var agent = new Agents
                    {
                        Name = agentName
                    };

                    // Add the agent to the database
                    _dbContext.Agents.Add(agent);
                    await _dbContext.SaveChangesAsync();

                    return Ok("Agent inserted successfully");
                }
                catch (Exception ex)
                {
               
                    return StatusCode(500, $"An error occured, please try again: {ex.Message}");
                }
            }

    }
}
