using CustomerRewardsTelecom.DTOs;
using CustomerRewardsTelecom.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRewardsTelecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerBIController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public PowerBIController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetSalesBeforeRewards")]
        public async Task<IActionResult> GetSalesBeforeRewards()
        {
            var query = @"
                SELECT 
	                C.[Name], 
	                C.[HomeCity], 
	                R.[RewardLevel],
	                SUM(P.[Amount]) AS TotalSales,
	                COUNT(*) AS SalesFrequency,
	                AVG(P.[Amount]) AS AveragePurchase,
	                YEAR(P.Date) AS PurchaseYear
                FROM 
	                Customers C
                JOIN 
	                Purchases P ON C.CustomerId = P.CustomerId
                LEFT JOIN 
	                Rewards R ON C.CustomerId = R.CustomerId
                WHERE P.Date < '2023-01-01'
                GROUP BY 
	                C.[Name], 
	                C.[HomeCity], 
	                R.[RewardLevel],
	                YEAR(P.Date);";

            var salesSummary = await _dbContext.Set<SalesAnalysisPowerBI>().FromSqlRaw(query).ToListAsync();

            return Ok(salesSummary);
        }

        [HttpGet("GetSalesAfterRewards")]
        public async Task<IActionResult> GetSalesAfterRewards()
        {
            var query = @"
                SELECT 
	                C.[Name], 
	                C.[HomeCity], 
	                R.[RewardLevel],
	                SUM(P.[Amount]) AS TotalSales,
	                COUNT(*) AS SalesFrequency,
	                AVG(P.[Amount]) AS AveragePurchase,
	                YEAR(P.Date) AS PurchaseYear
                FROM 
	                Customers C
                JOIN 
	                Purchases P ON C.CustomerId = P.CustomerId
                LEFT JOIN 
	                Rewards R ON C.CustomerId = R.CustomerId
                WHERE P.Date > '2022-12-31' AND P.Date < '2024-01-01'
                GROUP BY 
	                C.[Name], 
	                C.[HomeCity], 
	                R.[RewardLevel],
	                YEAR(P.Date);";

            var salesSummary = await _dbContext.Set<SalesAnalysisPowerBI>().FromSqlRaw(query).ToListAsync();

            return Ok(salesSummary);
        }
    }
}

   




