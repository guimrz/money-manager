
using MoneyManager.Services.Assets.Application.Extensions;
using MoneyManager.Services.Assets.Repository.Extensions;

namespace MoneyManager.Services.Assets.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAssetsServiceApplication();
            builder.Services.AddAssetsServiceRepository();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            await app.MigrateAssetsDatabaseAsync();

            app.Run();
        }
    }
}
