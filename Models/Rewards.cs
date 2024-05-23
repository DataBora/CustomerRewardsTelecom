namespace CustomerRewardsTelecom.Models
{
    public class Rewards
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

        // Foreign key
        public int CustomerId { get; set; }

        // Navigation property
        public Customers? Customer { get; set; }
    }
}
