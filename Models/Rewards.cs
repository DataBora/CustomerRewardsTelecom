using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{
    public class Rewards
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]

        public string Description { get; set; } = String.Empty;

        [Required]
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

        // Foreign key
        [Required]
        public int CustomerId { get; set; }

        // Navigation property
        public Customers? Customer { get; set; }
    }
}
