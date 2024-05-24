using System.ComponentModel.DataAnnotations;
namespace CustomerRewardsTelecom.DTOs
{
    public class AgentsPostDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
