using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost("Index")]
        public IActionResult Index()
        {
            return new JsonResult(DateTime.Now);
        }

        [Authorize]
        [HttpPost("Login")]
        public IActionResult Login()
        {
            return new JsonResult(DateTime.Now);
        }

    }
}
