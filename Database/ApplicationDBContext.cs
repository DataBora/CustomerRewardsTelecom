using CustomerRewardsTelecom.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerRewardsTelecom.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Rewards> Rewards { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Agents> Agents { get; set; }
    }
}
