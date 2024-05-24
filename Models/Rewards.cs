using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{

    public class Rewards
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string RewardLevel { get; set; } = String.Empty;

        [Required]
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

        // Foreign key
        [Required]
        public int CustomerId { get; set; }

        // Navigation properties
        public Customers? Customer { get; set; }
    }
}
