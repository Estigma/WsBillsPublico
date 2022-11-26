using Microsoft.EntityFrameworkCore;
using WsBills.Models;

namespace WSBills.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>().ToTable("Bill");
        }        
    }
}
