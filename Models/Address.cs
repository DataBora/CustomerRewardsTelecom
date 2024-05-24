using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models

{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string State { get; set; } = string.Empty;

        [Required]
        [MaxLength(5)]
        public string Zip { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Customers> Customers { get; set; } = new List<Customers>();
    }

}
