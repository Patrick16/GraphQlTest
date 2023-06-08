namespace ProductService.Database.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cost { get; set; }
    public List<Order> Orders { get; set; }
}
