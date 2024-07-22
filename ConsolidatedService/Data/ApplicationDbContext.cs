using ConsolidatedService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
 

namespace ConsolidatedService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }

}
