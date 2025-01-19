using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Repository.Configurations
{
    public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions")
                .HasKey(transaction => transaction.Id);

            builder.Property(transaction => transaction.Description)
                .HasMaxLength(512);

            builder.Property(transaction => transaction.Value)
                .IsRequired();

            builder.Property(transaction => transaction.Date)
                .IsRequired();
        }
    }
}
