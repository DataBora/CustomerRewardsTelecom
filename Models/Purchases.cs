namespace CustomerRewardsTelecom.Models
{
    public class Purchases
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        // Navigation property
        public Customers? Customer { get; set; }
    }
}
