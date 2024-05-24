using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRewardsTelecom.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "SSN is required")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "SSN must be between 9 and 11 characters")]
        public string SSN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [MaxLength(50)]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        [MaxLength(50)]
        public string State { get; set; } = String.Empty;

        [Required(ErrorMessage = "Zip is required")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip code must be 5 characters")]
        public string Zip { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        public int AgentId { get; set; }

        public List<string> FavoriteColors { get; set; } = new List<string>();

        //[NotMapped]
        //public int Age
        //{
        //    get { return (int)(DateTime.Now - DOB).TotalDays / 365; }
        //}
        public int Age
        {
            get
            {
                // Calculate age based on the DOB property
                TimeSpan span = DateTime.Now - DOB;
                int years = (int)(span.TotalDays / 365.25);
                return years;
            }
        }

        // Navigation properties
        public Agents? Agent { get; set; }

        // Navigation properties
        public ICollection<Rewards> Rewards { get; set; } = new List<Rewards>();
        public ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
    }
}
