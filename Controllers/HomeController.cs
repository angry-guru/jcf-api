using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jcf_api.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace jcf_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHostingEnvironment env;

        public HomeController(IHostingEnvironment env)
        {
            this.env = env ?? throw new ArgumentNullException(nameof(env));
        }

        [HttpGet("~/")]
        public IActionResult Ping()
        {
            return Ok(new 
            {
                name = "jcf-api",
                environment = env.EnvironmentName,
                time_zone = "UTC",
                start_time = StartupHelper.StartupTime.ToString("d MMM yyyy HH:mm:ss")
            });
        }
    }
}
