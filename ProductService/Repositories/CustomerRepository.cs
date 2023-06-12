using ProductService.Database;
using ProductService.Database.Models;
using ProductService.Repositories.Interfaces;

namespace ProductService.Repositories
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
