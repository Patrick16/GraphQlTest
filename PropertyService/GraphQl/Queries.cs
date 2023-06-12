using PropertyService.Database.Models;
using PropertyService.Repositories.Interfaces;

namespace PropertyService.GraphQl
{
    public class Queries
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Property> ReadProperties([Service] IPropertyRepository repository)
            => repository.GetAll();
    }
}
