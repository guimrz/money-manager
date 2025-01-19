using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MoneyManager.Services.Assets.Repository.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IApplicationBuilder"/>.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> MigrateAssetsDatabaseAsync(this IApplicationBuilder applicationBuilder)

        {
            ArgumentNullException.ThrowIfNull(applicationBuilder);

            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AssetsServiceDbContext>();

            await context.Database.MigrateAsync();

            return applicationBuilder;
        }
      
        public static IApplicationBuilder MigrateAssetsDatabase<TContext>(this IApplicationBuilder applicationBuilder)
        {
            ArgumentNullException.ThrowIfNull(applicationBuilder);

            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AssetsServiceDbContext>();

            context.Database.Migrate();

            return applicationBuilder;
        }
    }
}
