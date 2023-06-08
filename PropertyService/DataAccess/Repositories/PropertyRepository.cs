using PropertyService.DataAccess.Repositories.Interfaces;
using PropertyService.Database;
using PropertyService.Database.Models;

namespace PropertyService.DataAccess.Repositories
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
