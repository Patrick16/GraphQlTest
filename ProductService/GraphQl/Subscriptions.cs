using ProductService.Database.Models;

namespace ProductService.GraphQl
{
    public class Subscriptions
    {
        [Subscribe]
        [Topic(nameof(Mutations.Upsert))]
        public Order OnPropertyChanged([EventMessage] Order property)
        {
            Console.WriteLine("Publish");
            return property;
        }
    }
}
