using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Models;
using CustomerRewardsTelecom.Database;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;
using System;
using SOAPDemo;
using System.Globalization;

namespace CustomerRewardsTelecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerPostSoapController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly SOAPDemoSoap _soapClient;

        public CustomerPostSoapController(ApplicationDBContext context, SOAPDemoSoap soapClient)
        {
            _context = context;
            _soapClient = soapClient;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> PostSoapData(string id)
        {
            try
            {
                // Call the SOAP service to get the person data
                var soapResponse = await _soapClient.FindPersonAsync(id);

                if (soapResponse == null)
                {
                    return NotFound();
                }

                var customer = new Customers
                {
                    Name = soapResponse.Name,
                    SSN = soapResponse.SSN,
                    DOB =soapResponse.DOB, 
                    Age = (int)soapResponse.Age,
                    FavoriteColors = soapResponse.FavoriteColors.Select(fc => fc).ToList(),
                    HomeAddress = new CustomerRewardsTelecom.Models.Address // Assigning HomeAddress
                    {
                        Street = soapResponse.Home.Street,
                        City = soapResponse.Home.City,
                        State = soapResponse.Home.State,
                        Zip = soapResponse.Home.Zip
                    }
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                return Ok("Customer data saved successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }



        }

    }
}
