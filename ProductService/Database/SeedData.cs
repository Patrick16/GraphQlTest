using Bogus;
using Microsoft.EntityFrameworkCore;
using ProductService.Database.Models;

namespace ProductService.Database
{
    public static class SeedData
    {
        public static void EnsureSeedData(this MyDbContext db)
        {
            db.Database.Migrate();

            if (!db.Orders.Any() || !db.Products.Any() || !db.Customers.Any())
            {
                var properties = new Faker<Order>()
                    .RuleFor(c => c.DateCreated, c => c.Date.Recent().ToUniversalTime())
                    .RuleFor(x => x.Products, x => x.Make(3, () =>
                    {
                        var product = new Faker<Product>()
                        .RuleFor(c => c.Name, c => c.Commerce.ProductName())
                        .RuleFor(c => c.Cost, c => c.Commerce.Price(100, 1000, 1));
                        return product.Generate();
                    }))
                    .RuleFor(x => x.Customer, c =>
                    {
                        var customer = new Faker<Customer>()
                        .RuleFor(c => c.Email, c => c.Person.Email)
                        .RuleFor(c => c.Name, c => c.Person.FirstName);
                        return customer.Generate();
                    })
                    .Generate(500);

                db.Orders.AddRange(properties);
                db.SaveChanges();

            }
        }
    }
}
