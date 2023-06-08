using PropertyServices.Database.Models;

namespace PropertyServices.DataAccess.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
    }
}
