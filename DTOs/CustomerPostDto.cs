using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.DTOs
{
    public class CustomerPostDto
    {
        public string Name { get; set; } = string.Empty;
   
        public string SSN { get; set; } = string.Empty;
    
        public DateTime DOB { get; set; }
    
        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = String.Empty;

        public string Zip { get; set; } = string.Empty;

        public int AgentId { get; set; }

        public List<string> FavoriteColors { get; set; } = new List<string>();

    }
}
