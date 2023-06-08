//using DataAccessLayer.Repositories.Interfaces;
//using GraphQL.Types;
//using Types.PropertyTypes;

//namespace GraphQlTest.Queries
//{
//    public class PropertyQuery : ObjectGraphType
//    { 
//        public PropertyQuery(IPropertyRepository propertyRepository)
//        {
//            Field<ListGraphType<PropertyType>>(
//                "properties",
//                resolve: ctx => propertyRepository.GetAll());
//        }
//    }
//}
