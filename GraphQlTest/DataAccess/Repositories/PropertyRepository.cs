using PropertyServices.DataAccess.Repositories.Interfaces;
using PropertyServices.Database;
using PropertyServices.Database.Models;

namespace PropertyServices.DataAccess.Repositories
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
