namespace ProductService.Database.Models;

public class Order
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    public List<Product> Products { get; set; }
    public DateTime DateCreated { get; set; }
}
