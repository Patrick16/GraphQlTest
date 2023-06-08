using Microsoft.AspNetCore.Mvc;

namespace PropertyService.Controllers
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
