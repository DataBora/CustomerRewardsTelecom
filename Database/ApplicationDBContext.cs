﻿using CustomerRewardsTelecom.DTOs;
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

        //Database Entities
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Rewards> Rewards { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Agents> Agents { get; set; }

        //DTO For PowerBI SalesReport
        public DbSet<SalesAnalysisPowerBI> SalesAnalysisPowerBI { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customers>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Rewards>().HasKey(r => r.CustomerId);
            modelBuilder.Entity<Purchases>().HasKey(p => p.Id);
            modelBuilder.Entity<Agents>().HasKey(a => a.AgentId);

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

            //PowerBI Keyless DTO
            modelBuilder.Entity<SalesAnalysisPowerBI>()
               .HasNoKey();

        }

     
    }
}
