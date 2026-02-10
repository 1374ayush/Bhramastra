using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DpendencyInjection
{
    public static void AddSqlServerDb<TContext>(this IServiceCollection services, IConfiguration configuration)
        where TContext : DbContext
    {
        services.AddDbContext<TContext>(options => options.UseSqlServer(configuration.GetConnectionString("BrahmastraDb")));
    }
}
