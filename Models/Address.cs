namespace CustomerRewardsTelecom.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Customers> Customers { get; set; } = new List<Customers>();
    }

}
