using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRewardsTelecom.Models
{
    public class Customers
    {
        [Key]
        public string CustomerId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "SSN is required")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "SSN must be between 9 and 11 characters")]
        public string SSN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Home street is required")]
        [MaxLength(50)]
        public string HomeStreet { get; set; } = string.Empty;

        [Required(ErrorMessage = "Home city is required")]
        [MaxLength(50)]
        public string HomeCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Home state is required")]
        [MaxLength(50)]
        public string HomeState { get; set; } = string.Empty;

        [Required(ErrorMessage = "Home zip is required")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Home zip code must be 5 characters")]
        public string HomeZip { get; set; } = string.Empty;

        [Required(ErrorMessage = "Office street is required")]
        [MaxLength(50)]
        public string OfficeStreet { get; set; } = string.Empty;

        [Required(ErrorMessage = "Office city is required")]
        [MaxLength(50)]
        public string OfficeCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Office state is required")]
        [MaxLength(50)]
        public string OfficeState { get; set; } = string.Empty;

        [Required(ErrorMessage = "Office zip is required")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Office zip code must be 5 characters")]
        public string OfficeZip { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        public string AgentId { get; set; } = string.Empty ;

        public List<string> FavoriteColors { get; set; } = new List<string>();

        public int Age { get; set; }

        // Navigation properties
        public Agents? Agent { get; set; }

        // Navigation properties
        public ICollection<Rewards> Rewards { get; set; } = new List<Rewards>();
        public ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
    }
}
