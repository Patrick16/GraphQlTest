using PropertyService.Database.Models;

namespace PropertyService.GraphQl
{
    public class Subscriptions
    {
        [Subscribe]
        [Topic(nameof(Mutations.Upsert))]
        public Property OnPropertyChanged([EventMessage] Property property)
        {
            Console.WriteLine("Publish");
            return property;
        }
    }
}
