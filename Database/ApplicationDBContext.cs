using CustomerRewardsTelecom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customers>().HasKey(c => c.Id);
            modelBuilder.Entity<Rewards>().HasKey(r => r.Id);
            modelBuilder.Entity<Purchases>().HasKey(p => p.Id);

            // Relationship for Agent
            modelBuilder.Entity<Customers>()
                .HasOne(c => c.Agent)
                .WithMany()
                .HasForeignKey(c => c.AgentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Purchases>()
               .HasOne(p => p.Customer)
               .WithMany(c => c.Purchases)
               .HasForeignKey(p => p.CustomerId);

            //modelBuilder.Entity<Rewards>()
            //        .HasCheckConstraint("CK_Reward_Level", "[RewardLevel] IN ('Bronze', 'Silver', 'Gold')");
            modelBuilder.Entity<Rewards>(entity =>
            {
                entity.ToTable(tb => tb.HasCheckConstraint("CK_Reward_Level", "[RewardLevel] IN ('Bronze', 'Silver', 'Gold')"));
            });

            // Specify column type and precision for Amount in Purchases table
            modelBuilder.Entity<Purchases>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");

            // Specify column type and precision for Value in Rewards table
            modelBuilder.Entity<Rewards>()
                .Property(r => r.Discount)
                .HasColumnType("decimal(18, 2)");


        }
    }
}
