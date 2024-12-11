using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryingJWT.Services;

namespace TryingJWT.Controllers
{
    [Route("JWT")]
    [ApiController]
    public class Controller_JWTs(IConfiguration config) : ControllerBase
    {
        private readonly IConfiguration _config = config;
        private readonly Service_JWTGenerator jwtGenerator = new(config);
        
        [HttpGet("{uname}")]
        public IActionResult GetJWT([FromRoute] string uname) {
            return Ok(jwtGenerator.GenerateToken(uname));
        }
    }
}