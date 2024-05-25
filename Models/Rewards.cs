using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{

    public class Rewards
    {
        [Key]
        public string? CustomerId { get; set; } 

        [Required]
        [MaxLength(50)]
        public string RewardLevel { get; set; } = string.Empty;

        [Required]
        public decimal Discount { get; set; }

        public DateTime Date { get; set; }

        // Navigation property
        public Customers? Customer { get; set; }
    }
}
