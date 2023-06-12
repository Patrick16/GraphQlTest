using ProductService.Database.Models;

namespace ProductService.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}
