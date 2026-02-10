using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    
    }


    public DbSet<Products> Products { get; set; }
}