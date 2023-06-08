using ProductService.DataAccess.Repositories.Interfaces;
using ProductService.Database;
using ProductService.Database.Models;

namespace ProductService.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        MyDbContext _dbContext;

        public OrderRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders;
        }
    }
}
