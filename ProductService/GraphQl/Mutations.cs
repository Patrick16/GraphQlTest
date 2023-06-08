using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore.Design;
using ProductService.Database;
using ProductService.Database.Models;

namespace ProductService.GraphQl
{
    public class Mutations
    {
        private readonly IDesignTimeDbContextFactory<MyDbContext> factory;
        private readonly ITopicEventSender sender;

        public Mutations([Service] IDesignTimeDbContextFactory<MyDbContext> factory)
        {
            this.factory = factory;
        }

        public async Task<Order> Upsert(Order order, [Service] ITopicEventSender sender)
        {
            using var ctx = factory.CreateDbContext(new string[0]);
            if (order.Id == 0)
            {
                ctx.Add(order);
            }
            else
            {
                ctx.Update(order);
            }
            await ctx.SaveChangesAsync();

            await sender.SendAsync(nameof(Mutations.Upsert), order);

            return order;
        }
    }
}
