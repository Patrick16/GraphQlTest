using ProductService.Database.Models;

namespace ProductService.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Task<Order> GetOrder(int id);
    }
}
