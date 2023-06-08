using ProductService.Database.Models;

namespace ProductService.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}
