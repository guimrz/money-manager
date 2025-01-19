using Microsoft.EntityFrameworkCore;
using MoneyManager.Services.Assets.Repository.Configurations;

namespace MoneyManager.Services.Assets.Repository
{
    public class AssetsServiceDbContext : DbContext
    {
        public AssetsServiceDbContext(DbContextOptions<AssetsServiceDbContext> options)
            : base(options)
        {
            //   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AssetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
        }
    }
}
