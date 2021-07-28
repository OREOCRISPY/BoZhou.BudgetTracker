using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoZhou.BudgetTracker.ApplicationCore.Entities;

namespace BoZhou.BudgetTracker.Infrastructure.Data
{
    public class BudgetTrackerDbContext:DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options) {  
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Income>(ConfigureIncome);
            modelBuilder.Entity<Expenditure>(ConfigureExpenditure);
        }
        private void ConfigureExpenditure(EntityTypeBuilder<Expenditure> builder) {
            builder.ToTable("Expenditure");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Amount).HasColumnType("money").IsRequired();
            builder.Property(m => m.Remarks).HasMaxLength(500);
            builder.Property(m => m.Description).HasMaxLength(100);
            builder.HasOne(m => m.User).WithMany(n => n.Expenditures).HasForeignKey(m => m.UserId);
        }
        private void ConfigureIncome(EntityTypeBuilder<Income> builder){
            builder.ToTable("Income");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Amount).HasColumnType("money").IsRequired();
            builder.Property(m => m.Description).HasMaxLength(100);
            builder.Property(m => m.Remarks).HasMaxLength(500);
            builder.HasOne(m => m.User).WithMany(n => n.Incomes).HasForeignKey(m => m.UserId);
        }
        private void ConfigureUser(EntityTypeBuilder<User> builder) {
            builder.ToTable("User");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(m => m.Password).HasMaxLength(500).IsRequired(true);
            builder.Property(m => m.Fullname).HasMaxLength(50);
            builder.Property(m => m.JoinOn);
            builder.Property(m => m.Salt).IsRequired();
        }
    }
}
