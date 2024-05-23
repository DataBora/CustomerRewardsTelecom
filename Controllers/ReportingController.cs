using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using CustomerRewardsTelecom.Database;
using CustomerRewardsTelecom.Models;
using System.Globalization;
using System.Linq.Expressions;


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

                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Purchases>();

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
                            };
                            _dbContext.Purchases.Add(purchase);
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                }
                return Ok("Report processed Successfully!");
            }
            catch (Exception ex)
            {
                // Log the exception or return a more specific error message
                return StatusCode(500, $"An error occurred while processing the report: {ex.Message}");
            }
        }
    }
}