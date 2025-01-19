using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Repository.Configurations
{
    public class CurrencyEntityTypeConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies")
                .HasKey(currency => currency.Id);

            builder.Property(currency => currency.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(currency => currency.Symbol)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(currency => currency.Code)
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
