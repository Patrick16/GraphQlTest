using Microsoft.EntityFrameworkCore;
using ProductService.Database.Models;

namespace ProductService.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable(nameof(Order))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>().ToTable(nameof(Product))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer))
                .HasKey(p => p.Id);

            modelBuilder.Entity<Order>().HasMany(c => c.Products).WithMany(x=>x.Orders);
            modelBuilder.Entity<Order>().HasOne(c => c.Customer).WithMany(x=>x.Orders);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
