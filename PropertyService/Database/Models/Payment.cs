namespace PropertyService.Database.Models
{
    [GraphQLDescription("Payment entity")]
    public class Payment
    {
        [GraphQLDescription("Id")]
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOverdue { get; set; }
        public bool Paid { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
