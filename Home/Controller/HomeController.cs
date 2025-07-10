using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Home.Controller
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [HttpGet("test")]
        public string Test()
        {
            return "Test";
        }
    }
}