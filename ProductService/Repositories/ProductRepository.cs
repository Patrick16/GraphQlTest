using ProductService.Database;
using ProductService.Database.Models;
using ProductService.Repositories.Interfaces;

namespace ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _dbontext;

        public ProductRepository(MyDbContext dbContext)
        {
            _dbontext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbontext.Products;
        }
    }
}
