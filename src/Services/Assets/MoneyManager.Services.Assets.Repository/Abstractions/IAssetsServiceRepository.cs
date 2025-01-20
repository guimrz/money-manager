using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Repository.Abstractions
{
    public interface IAssetsServiceRepository
    {
        Task<Currency?> GetCurrencyAsync(int currencyId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Currency>> GetCurrenciesAsync(CancellationToken cancellationToken = default);

        Task<Asset> InsertAssetAsync(Asset asset, CancellationToken cancellationToken = default);

        Task<Asset?> GetAssetAsync(Guid assetId, CancellationToken cancellationToken = default);

        Task<Asset> UpdateAssetAsync(Asset asset, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
