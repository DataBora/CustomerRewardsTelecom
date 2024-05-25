using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Models;
using System.Globalization;
using CustomerRewardsTelecom.Repositories;
using CustomerRewardsTelecom.Interfaces;
using CustomerRewardsTelecom.Helpers;

namespace CustomerRewardsTelecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportingController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        public ReportingController(ICustomerRepository customerRepository, IPurchaseRepository purchaseRepository)
        {
            _customerRepository = customerRepository;
            _purchaseRepository = purchaseRepository;
        }

        [HttpPost("UploadReport")]
        public async Task<IActionResult> UploadReport(IFormFile file)
        {
            try
            {
                //Check if file exists or empty
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Invalid file.");
                }

                var customersNotFound = new List<string>();

                //instantiating Readers
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Registering the custom class map
                    csv.Context.RegisterClassMap<PurchasesCsvMap>();  
                    var records = csv.GetRecords<Purchases>().ToList();

                    foreach (var record in records)
                    {
                        //Check if we have this customer in Customers table
                        var customer = await _customerRepository.GetCustomerByIdAsync(record.CustomerId);

                        //Check if we have customer already within Purchases table
                        var existingPurchase = await _purchaseRepository.GetPurchasesAsync(record.CustomerId, record.Date, record.Amount);


                        if (existingPurchase != null)
                        {
                            throw new Exception($"Purchase records already exist in database.");
                            //ModelState.AddModelError("", "Purchase records already exist in database");
                            //return StatusCode(422, ModelState);
                        }
                        

                        if (customer != null)
                        {
                            var purchase = new Purchases
                            {
                                CustomerId = record.CustomerId,
                                Date = record.Date,
                                Amount = record.Amount,
                                Customer = customer
                            };

                            await _purchaseRepository.AddPurchaseAsync(purchase);
                        }
                        else
                        {
                            customersNotFound.Add(record.CustomerId);
                        }
                    }
                    if (customersNotFound.Any())
                    {
                        throw new Exception($"The following customers were not found in the database: {string.Join(", ", customersNotFound)}");
                    }

                    await _purchaseRepository.SaveChangesAsync();
                   
                }
                return Ok("Report processed successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the report: {ex.Message}");
            }
        }
    }
}
