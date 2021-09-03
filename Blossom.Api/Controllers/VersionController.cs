using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiThrottle;

namespace Blossom.Api.Controllers
{
    [Route("api/version")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public VersionController(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetVersion()
        {
            var version = _configuration["Version"];
            return Ok($"Blossom Careers, {version}");
        }
    }
}
