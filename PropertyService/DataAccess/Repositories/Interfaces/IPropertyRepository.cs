using PropertyService.Database.Models;

namespace PropertyService.DataAccess.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
    }
}
