﻿using Microsoft.AspNetCore.Mvc;

namespace PropertyServices.Controllers
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
