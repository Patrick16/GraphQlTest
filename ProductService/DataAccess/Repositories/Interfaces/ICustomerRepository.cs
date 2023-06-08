using ProductService.Database.Models;

namespace ProductService.DataAccess.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}
