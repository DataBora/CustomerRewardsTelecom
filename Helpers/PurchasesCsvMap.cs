using CsvHelper.Configuration;
using CustomerRewardsTelecom.Models;

namespace CustomerRewardsTelecom.Helpers
{
    public class PurchasesCsvMap : ClassMap<Purchases>
    {
        public PurchasesCsvMap()
        {
            Map(m => m.CustomerId).Name("CustomerId");
            Map(m => m.Date).Name("Date");
            Map(m => m.Amount).Name("Amount");

        }
    }
}
