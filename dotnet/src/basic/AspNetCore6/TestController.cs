using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6
{
    [Route("api/t")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public string SearchProducts([FromQuery] string keywords)
        {
            return "hello " + keywords;
        }
    }
}
