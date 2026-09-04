using ExpenceTracker.Entities;
using ExpenceTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenceTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Expence> Expences { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Id)
                .IsUnique();

            modelBuilder.Entity<Expence>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);
        }
    }
}
