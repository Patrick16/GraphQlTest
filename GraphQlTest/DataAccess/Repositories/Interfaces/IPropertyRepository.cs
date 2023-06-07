using Database.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
    }
}
