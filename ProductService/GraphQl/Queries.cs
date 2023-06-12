using ProductService.Database.Models;
using ProductService.Repositories.Interfaces;

namespace ProductService.GraphQl
{
    public class Queries
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Order> ReadOrders([Service] IOrderRepository _orderRepository)
            => _orderRepository.GetOrders();

        [UseProjection]
        public async Task<Order> ReadOrder([Service] IOrderRepository _orderRepository, int id)
            => await _orderRepository.GetOrder(id);

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Product> ReadProducts([Service] IProductRepository _productRepository)
            => _productRepository.GetProducts();

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Customer> ReadCustomers([Service] ICustomerRepository _customerRepository)
            => _customerRepository.GetCustomers();
    }
}
