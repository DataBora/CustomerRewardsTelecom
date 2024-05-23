using CsvHelper.Configuration;

namespace CustomerRewardsTelecom.Models
{
    public class PurchasesCsvMap : ClassMap<Purchases>
    {
        public PurchasesCsvMap()
        {
            Map(m => m.CustomerId).Name("CustomerId");
            Map(m => m.Date).Name("Date");
            Map(m => m.Date).Name("Date");

        }
    }
}
