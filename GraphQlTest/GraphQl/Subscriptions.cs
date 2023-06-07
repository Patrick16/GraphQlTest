using Database.Models;

namespace GraphQlTest.GraphQl
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
