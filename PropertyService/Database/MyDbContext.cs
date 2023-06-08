using Microsoft.EntityFrameworkCore;
using PropertyService.Database.Models;

namespace PropertyService.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().ToTable(nameof(Property))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Payment>().ToTable(nameof(Payment))
                .HasKey(p => p.Id);

            modelBuilder.Entity<Property>().HasMany(c => c.Payments).WithOne(x => x.Property);

            //modelBuilder.Entity<Property>().HasQueryFilter(x=>x.Id == 1);
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
