using Microsoft.EntityFrameworkCore.Design;
using ProductService.Database;
using ProductService.Database.Models;

namespace ProductService.GraphQl
{
    public class Queries
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> Read([Service] IDesignTimeDbContextFactory<MyDbContext> factory)
            => factory.CreateDbContext(new string[0]).Orders;
    }
}
