using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        //add sql server 
        services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(connectionString));
        // services.AddScoped<IApplicationDbContext,ApplicationDbContext>();
        
        return services;
    }
    
}