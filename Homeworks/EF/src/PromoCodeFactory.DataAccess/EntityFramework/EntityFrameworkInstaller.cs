using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PromoCodeFactory.DataAccess.EntityFramework;

public static class EntityFrameworkInstaller
{
    public static IServiceCollection ConfigureEFContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(opt => opt
            .UseLazyLoadingProxies()
            .UseSqlite(connectionString));

        return services;
    }
}