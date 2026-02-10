using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ProductDbContext dbContext;

        public WeatherForecastController(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("check")]
        public IActionResult GetProducts()
        {
            return Ok(this.dbContext.Products.ToList());
        }
    }
}
