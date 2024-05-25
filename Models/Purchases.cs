using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{
    public class Purchases
    {
        [Key]
        public string CustomerId { get; set; } = string.Empty ;
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        // Navigation property
        public Customers? Customer { get; set; }
    }
}
