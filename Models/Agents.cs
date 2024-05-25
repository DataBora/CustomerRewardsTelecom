using System.ComponentModel.DataAnnotations;

namespace CustomerRewardsTelecom.Models
{
    public class Agents
    {
        [Key]
        public int AgentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
    }
}
