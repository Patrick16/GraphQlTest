using Bogus;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlTest
{
    public static class SeedData
    {
        public static void EnsureSeedData(this MyDbContext db)
        {
            db.Database.Migrate();

            if (!db.Properties.Any() || !db.Payments.Any())
            {
                var properties = new Faker<Property>()
                    .RuleFor(x => x.Street, x => x.Address.StreetName())
                    .RuleFor(x => x.Value, x => x.Random.Decimal())
                    .RuleFor(x => x.City, x => x.Address.City())
                    .RuleFor(x => x.Name, x => x.Company.CompanyName())
                    .RuleFor(x => x.Family, x => x.Person.LastName)
                    .RuleFor(x => x.Payments, x => x.Make(5, () =>
                    {
                        var paymentFaker = new Faker<Payment>()
                        .RuleFor(c => c.Paid, c => c.Random.Bool())
                        .RuleFor(c => c.Value, c => c.Random.Decimal())
                        .RuleFor(c => c.DateCreated, c => c.Date.Recent().ToUniversalTime())
                        .RuleFor(c => c.DateOverdue, c => c.Date.Recent().ToUniversalTime());
                        return paymentFaker.Generate();
                    }))
                    .Generate(500);

                db.Properties.AddRange(properties);
                db.SaveChanges();

            }
        }
    }
}
