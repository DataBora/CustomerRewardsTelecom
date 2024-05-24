using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(11)]
        public string SSN { get; set; } = string.Empty; // Social Security Number
        public DateTime DOB { get; set; } // Date of Birth

        // Foreign keys
        public int AgentId { get; set; }
        public int? HomeAddressId { get; set; } // Foreign key to HomeAddress

        // Navigation properties
        public Agents? Agent { get; set; }
        public Address? HomeAddress { get; set; }

        public List<string> FavoriteColors { get; set; } = new List<string>();
        public int Age { get; set; } // Age

        // Navigation properties
        public ICollection<Rewards> Rewards { get; set; } = new List<Rewards>();
        public ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
    }
}
