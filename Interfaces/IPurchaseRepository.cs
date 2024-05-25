using CustomerRewardsTelecom.Models;
using System.Threading.Tasks;


namespace CustomerRewardsTelecom.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Purchases?> GetPurchasesAsync(string customerId, DateTime date, decimal amount);
        Task AddPurchaseAsync(Purchases purchase);

        Task<int> SaveChangesAsync(); 
    }
}
