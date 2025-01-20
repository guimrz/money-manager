using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MoneyManager.Services.Assets.Application.Abstractions;
using MoneyManager.Services.Assets.Application.Mapping;

namespace MoneyManager.Services.Assets.Application.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAssetsServiceApplication(this IServiceCollection services)
        {
            services.TryAddScoped<IAssetsService, AssetsService>();

            services.AddAutoMapper(config =>
            {
                config.AddProfile<CurrencyMapProfile>();
                config.AddProfile<AssetMapProfile>();
            });

            return services;
        }
    }
}
