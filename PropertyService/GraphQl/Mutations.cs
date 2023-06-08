using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore.Design;
using PropertyService.Database;
using PropertyService.Database.Models;

namespace PropertyService.GraphQl
{
    public class Mutations
    {
        private readonly IDesignTimeDbContextFactory<MyDbContext> factory;
        private readonly ITopicEventSender sender;

        public Mutations([Service] IDesignTimeDbContextFactory<MyDbContext> factory)
        {
            this.factory = factory;
        }

        public async Task<Property> Upsert(Property property, [Service] ITopicEventSender sender)
        {
            using var ctx = factory.CreateDbContext(new string[0]);
            if (property.Id == 0)
            {
                ctx.Add(property);
            }
            else
            {
                ctx.Update(property);
            }
            await ctx.SaveChangesAsync();

            await sender.SendAsync(nameof(Mutations.Upsert), property);

            return property;
        }
    }
}
