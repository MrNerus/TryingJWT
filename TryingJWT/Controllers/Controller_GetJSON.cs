using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TryingJWT.Controllers
{
    [Route("Json")]
    [ApiController]
    public class Controller_GetJS : ControllerBase
    {
        [Authorize]
        [HttpGet("a")]
        public IActionResult GetJson() {
            string json = "{a: 123}";
            return Ok(json);
        }
    }
}