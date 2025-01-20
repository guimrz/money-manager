using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MoneyManager.Services.Assets.Repository.Abstractions;
using System.Reflection;

namespace MoneyManager.Services.Assets.Repository.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAssetsServiceRepository(this IServiceCollection services)
        {
            services.TryAddScoped<IAssetsServiceRepository, AssetsServiceRepository>();
            services.AddDbContext<AssetsServiceDbContext>((serviceProvider, options) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions => 
                {
                    sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly());
                });
            });

            return services;
        }
    }
}
