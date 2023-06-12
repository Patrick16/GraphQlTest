using PropertyService.Database;
using PropertyService.Database.Models;
using PropertyService.Repositories.Interfaces;

namespace PropertyService.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        MyDbContext _dbContext;

        public PropertyRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Property> GetAll()
        {
            return _dbContext.Properties;
        }
    }
}
