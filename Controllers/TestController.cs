
using Microsoft.AspNetCore.Mvc;

namespace classcheckin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "API funcionando!" });
        }
    }
}
