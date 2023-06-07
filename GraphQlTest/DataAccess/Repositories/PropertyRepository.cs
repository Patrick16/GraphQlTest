using DataAccessLayer.Repositories.Interfaces;
using Database;
using Database.Models;

namespace DataAccessLayer.Repositories
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
