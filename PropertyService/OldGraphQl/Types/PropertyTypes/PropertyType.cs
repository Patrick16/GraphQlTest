//using DataAccessLayer.Repositories.Interfaces;
//using Database.Models;
//using GraphQL.Types;
//using Types.PaymentTypes;

//namespace Types.PropertyTypes
//{
//    public class PropertyType : ObjectGraphType<Property>
//    {
//        public PropertyType(IPaymentRepository paymentRepository)
//        {
//            Field(x => x.Id);
//            Field(x => x.Name);
//            Field(x => x.Value);
//            Field(x => x.City);
//            Field(x => x.Family);
//            Field(x => x.Street);
//            Field<ListGraphType<PaymentType>>(
//                "payments",
//                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "last" }),
//                resolve: ctx =>
//                {
//                     var last = ctx.GetArgument<int?>("last");
//                     return last.HasValue ?
//                     paymentRepository.GetPaymentsForPropertyWithLastAmount(ctx.Source.Id, last.Value) :
//                     paymentRepository.GetPaymentsForProperty(ctx.Source.Id);
//                });
//        }
//    }
//}
