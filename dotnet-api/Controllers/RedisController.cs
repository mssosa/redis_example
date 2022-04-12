using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisController(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        [HttpGet("foo")]
        public async Task<IActionResult> Foo()
        {
            var db = _redis.GetDatabase();
            var foo = await db.StringGetAsync("foo");
            return Ok(foo.ToString());
        }
    }
}
