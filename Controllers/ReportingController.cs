using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Models;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerRewardsTelecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportingController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public ReportingController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("UploadReport")]
        public async Task<IActionResult> UploadReport(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Invalid file.");
                }

                var customersNotFound = new List<int>();

                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<PurchasesCsvMap>();  // Registering the custom class map
                    var records = csv.GetRecords<Purchases>().ToList();

                    foreach (var record in records)
                    {
                        var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == record.CustomerId);

                        if (customer != null)
                        {
                            var purchase = new Purchases
                            {
                                CustomerId = record.CustomerId,
                                Date = record.Date,
                                Amount = record.Amount,
                                Customer = customer
                            };
                            _dbContext.Purchases.Add(purchase);
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

                    await _dbContext.SaveChangesAsync();
                   
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
