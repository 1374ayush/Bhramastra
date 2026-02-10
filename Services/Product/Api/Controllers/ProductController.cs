using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext dbContext;

        public ProductController(ProductDbContext dbContext)
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
