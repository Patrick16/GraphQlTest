using Microsoft.AspNetCore.Mvc;

namespace GraphQlTest.Controllers
{

    [Route("[controller]")]
    public class GraphQlNewController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }
    }
}
