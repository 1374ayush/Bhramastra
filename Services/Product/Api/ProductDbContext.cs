using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Service.Api;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Products> Products { get; set; }
}
