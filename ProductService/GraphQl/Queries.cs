using ProductService.DataAccess.Repositories.Interfaces;
using ProductService.Database.Models;

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
