using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Services;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorld)
        {
            _helloWorldService = helloWorld;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_helloWorldService.GetHelloWorld());
        }
    }
}
