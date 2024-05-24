using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{
    public class Purchases
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        // Navigation property
        public Customers? Customer { get; set; }
    }
}
