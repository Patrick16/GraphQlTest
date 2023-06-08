using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
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
