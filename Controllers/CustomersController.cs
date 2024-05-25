using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOAPDemo;
using CustomerRewardsTelecom.Repositories;

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
        public async Task<IActionResult> InsertCustomer(string customerId, string agentId)
        {
            try
            {
                // Check if the given AgentId exists in the Agents table
                var agentExists = await _dbContext.Agents.AnyAsync(a => a.AgentId == agentId);
                if (!agentExists)
                {
                    return BadRequest("The provided AgentId does not exist.");
                }

                // Retrieve Customer data from SOAP service
                var customer = await _soapClient.FindPersonAsync(customerId);

                //If Customer not found send message
                if (customer == null)
                {
                    return BadRequest("Sorry we do not have that customer in out SOAP service.");
                }

                // Convert customerId from string to int
                //if (!int.TryParse(customerId, out int hashedCustomerId))
                //{
                //    return BadRequest("Invalid customerId format.");
                //}

                //Check if customer alreadu exist in Customers table by Name
                var customerExistsInCustomers = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Name == customer.Name);
                if (customerExistsInCustomers != null)
                {
                    return BadRequest("Customer already Exists in our database.");
                }

                // Create a new customer record
                var newCustomer = new Customers
                {   
                    CustomerId = customerId,
                    Name = customer.Name,
                    SSN = customer.SSN,
                    DOB = customer.DOB,
                    HomeStreet = customer.Home.Street,
                    HomeCity = customer.Home.City,
                    HomeState = customer.Home.State,
                    HomeZip = customer.Home.Zip,
                    OfficeStreet = customer.Office.Street,
                    OfficeCity = customer.Office.City,
                    OfficeState = customer.Office.State,
                    OfficeZip = customer.Office.Zip,
                    FavoriteColors = customer.FavoriteColors.ToList(),
                    Age = (int)customer.Age, 
                    AgentId = agentId,
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



