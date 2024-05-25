using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOAPDemo;


namespace CustomerRewardTelecom.CustomerService.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly SOAPDemoSoap _soapClient;
        private readonly ApplicationDBContext _dbContext;

        public CustomerController(ApplicationDBContext dBContext)
        {
            _soapClient = new SOAPDemoSoapClient(SOAPDemoSoapClient.EndpointConfiguration.SOAPDemoSoap);
            _dbContext = dBContext;
        }

        [HttpGet("FindPerson/{id}")]
        public async Task<IActionResult> FindPerson(string id)
        {
            try
            {
                var person = await _soapClient.FindPersonAsync(id);
                if (person == null)
                {
                    return NotFound();
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" An error occured while we were processing your request, please try aggain: {ex.Message}");
            }
        }

        [HttpPost("InsertCustomerIntoDatabase")]
        public async Task<IActionResult> InsertCustomer(string id, int agentId)
        {
            try
            {
                // Check if the given AgentId exists in the Agents table
                var agentExists = await _dbContext.Agents.AnyAsync(a => a.Id == agentId);
                if (!agentExists)
                {
                    return BadRequest("The provided AgentId does not exist.");
                }

                // Retrieve person data from SOAP service
                var person = await _soapClient.FindPersonAsync(id);
                if (person == null)
                {
                    return NotFound();
                }

                // Create a new customer record
                var newCustomer = new Customers
                {
                    Name = person.Name,
                    SSN = person.SSN,
                    DOB = person.DOB,
                    HomeStreet = person.Home.Street,
                    HomeCity = person.Home.City,
                    HomeState = person.Home.State,
                    HomeZip = person.Home.Zip,
                    OfficeStreet = person.Office.Street,
                    OfficeCity = person.Office.City,
                    OfficeState = person.Office.State,
                    OfficeZip = person.Office.Zip,
                    FavoriteColors = person.FavoriteColors.ToList(),
                    Age = (int)person.Age, 
                    AgentId = agentId
                };

                // Add the new customer record to the database
                _dbContext.Customers.Add(newCustomer);
                await _dbContext.SaveChangesAsync();

                return Ok(newCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request. Please try again: {ex.Message}");
            }
        }

    }
}



