using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Models;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.DTOs;
using Newtonsoft.Json;


namespace CustomerRewardsTelecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerPostSoapController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public CustomerPostSoapController(ApplicationDBContext context)
        {
            _dbContext = context;
        
        } 

        [HttpPost("CustomerPostRequest")]
        public async Task<IActionResult> CustomerPost([FromBody] CustomerPostDto request )
        {
            try
            {
                //check for agent ID
                var agentResult = _dbContext.Agents.Any(a => a.Id == request.AgentId);
                if (!agentResult)
                {
                    return NotFound("Agent not found!");
                }

                var customer = new Customers
                {
                    Name = request.Name,
                    SSN = request.SSN,
                    DOB = request.DOB,
                    Street = request.Street,
                    City = request.City,
                    State = request.State,
                    Zip = request.Zip,
                    AgentId = request.AgentId,
                    FavoriteColors = request.FavoriteColors

                };


                _dbContext.Customers.Add(customer);
                await _dbContext.SaveChangesAsync();

                return Ok("Customer data saved successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }



        }

    }
}
