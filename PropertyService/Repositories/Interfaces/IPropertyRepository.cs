using PropertyService.Database.Models;

namespace PropertyService.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
    }
}
