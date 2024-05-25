using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{
    public class Agents
    {
        [Key]
        public string AgentId { get; set; } = string.Empty; 

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
    }
}
