namespace CustomerRewardsTelecom.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; }= String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;

        // Foreign key
        public int AgentId { get; set; }

        // Navigation properties
      
        public Agents? Agent { get; set; }

        //adding List to avoid null references
        public ICollection<Rewards> Rewards { get; set; } = new List<Rewards>();
        public ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
    }
}
