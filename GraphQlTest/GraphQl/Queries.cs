using Microsoft.EntityFrameworkCore.Design;
using PropertyServices.Database;
using PropertyServices.Database.Models;

namespace PropertyServices.GraphQl
{
    public class Queries
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Property> Read([Service] IDesignTimeDbContextFactory<MyDbContext> factory)
            => factory.CreateDbContext(new string[0]).Properties;
    }
}
