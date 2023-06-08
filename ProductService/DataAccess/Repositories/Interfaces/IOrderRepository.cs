using ProductService.Database.Models;

namespace ProductService.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
    }
}
