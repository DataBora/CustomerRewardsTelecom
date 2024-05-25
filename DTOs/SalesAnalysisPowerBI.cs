namespace CustomerRewardsTelecom.DTOs
{
    public class SalesAnalysisPowerBI
    {
        public string Name { get; set; } = string.Empty;
        public string HomeCity { get; set; } = string.Empty;
        public string RewardLevel { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int SalesFrequency { get; set; }
        public decimal AveragePurchase { get; set; }
        public int PurchaseYear { get; set; }
    }
}
