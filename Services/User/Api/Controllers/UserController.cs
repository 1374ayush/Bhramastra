using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using User.Service.Api.Producer;

namespace User.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            await KafkaProducer.CreateMessage();
            return Ok("User Service is running...");
        }
    }
}
