using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Repository.Configurations
{
    public class AssetEntityTypeConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("Assets")
                .HasKey(asset => asset.Id);

            builder.Property(asset => asset.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasOne<Currency>()
                .WithMany()
                .HasForeignKey(p => p.CurrencyId)
                .IsRequired();

            builder.Metadata.FindNavigation(nameof(Asset.Transactions))!.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(p => p.Transactions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
