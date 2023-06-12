using Common;
using Microsoft.EntityFrameworkCore;
using ProductService.Database;
using ProductService.Database.Models;
using ProductService.Repositories.Interfaces;

namespace ProductService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        MyDbContext _dbContext;

        public OrderRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> GetOrder(int id)
        {
            var res = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            
            return res == null ? throw new BadRequestException($"Order with id {id} does not exist") : res;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders;
        }
    }
}
