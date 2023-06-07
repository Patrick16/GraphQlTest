using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace GraphQlTest.GraphQl
{
    public class Queries
    {
        [UsePaging(IncludeTotalCount =true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Property> Read([Service] IDesignTimeDbContextFactory<MyDbContext> factory)
            => factory.CreateDbContext(new string[0]).Properties;
    }
}
