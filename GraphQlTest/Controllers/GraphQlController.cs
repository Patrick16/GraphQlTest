//using Microsoft.AspNetCore.Mvc;
//using Utilities;
//using GraphQL;
//using GraphQL.Types;

//namespace GraphQlTest.Controllers
//{

//    [Route("[controller]")]
//    public class GraphQlController : Controller
//    {
//        private readonly ISchema _schema;
//        private readonly IDocumentExecuter _documentExecuter;

//        public GraphQlController(ISchema schema, IDocumentExecuter documentExecuter)
//        {
//            _schema = schema;
//            _documentExecuter = documentExecuter;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
//        {
//            if (query == null)
//            {
//                throw new ArgumentNullException(nameof(query));
//            }
//            var inputs = query.Variables?.ToInputs();
//            var executionOptions = new ExecutionOptions
//            {
//                Schema = _schema,
//                Query = query.Query,
//                Inputs = inputs
//            };

//            var result = await _documentExecuter.ExecuteAsync(executionOptions);

//            if(result.Errors?.Count>0) 
//            {
//                return BadRequest(result.Errors);
//            }

//            return Ok(result);

//        }
//    }
//}
