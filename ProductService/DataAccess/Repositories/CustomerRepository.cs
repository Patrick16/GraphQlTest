using ProductService.DataAccess.Repositories.Interfaces;
using ProductService.Database;
using ProductService.Database.Models;

namespace ProductService.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        MyDbContext _dbContext;

        public CustomerRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers;
        }
    }
}
