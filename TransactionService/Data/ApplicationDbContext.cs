using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TransactionService.Models;

namespace TransactionService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);  

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();  

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18,2)")  
                    .HasPrecision(18, 2);  

                entity.Property(e => e.Type)
                    .IsRequired()  
                    .HasMaxLength(50);  

                entity.Property(e => e.Date)
                    .HasColumnType("datetime");  
            });

            base.OnModelCreating(modelBuilder);
        }

    }

}
