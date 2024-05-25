using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{

    public class Rewards
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string RewardLevel { get; set; } = string.Empty;

        [Required]
        public decimal Discount { get; set; }
        public DateTime Date { get; set; }

        // Foreign key
        [Required]
        public string CustomerId { get; set; } = string.Empty;

        // Navigation properties
        public Customers? Customer { get; set; }
    }
}
