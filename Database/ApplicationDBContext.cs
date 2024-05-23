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
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationship for HomeAddress
            modelBuilder.Entity<Customers>()
                .HasOne(c => c.HomeAddress)
                .WithMany(a => a.Customers)
                .HasForeignKey(c => c.HomeAddressId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure relationship for Agent
            modelBuilder.Entity<Customers>()
                .HasOne(c => c.Agent)
                .WithMany()
                .HasForeignKey(c => c.AgentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure other relationships if needed
        }


    }
}
