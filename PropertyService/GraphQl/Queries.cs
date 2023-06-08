﻿using Microsoft.EntityFrameworkCore.Design;
using PropertyService.Database;
using PropertyService.Database.Models;

namespace PropertyService.GraphQl
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