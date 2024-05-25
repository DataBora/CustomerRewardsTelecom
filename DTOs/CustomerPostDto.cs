using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.DTOs
{
    public class CustomerPostDto
    {

        public string Name { get; set; } = string.Empty;
   
        public string SSN { get; set; } = string.Empty;
    
        public DateTime DOB { get; set; }
    
        public string HomeStreet { get; set; } = string.Empty;

        public string HomeCity { get; set; } = string.Empty;

        public string HomeState { get; set; } = string.Empty;

        public string HomeZip { get; set; } = string.Empty;

        public string OfficeStreet { get; set; } = string.Empty;

        public string OfficeCity { get; set; } = string.Empty;

        public string OfficeState { get; set; } = string.Empty;

        public string OfficeZip { get; set; } = string.Empty;

        public List<string> FavoriteColors { get; set; } = new List<string>();

    }
}
