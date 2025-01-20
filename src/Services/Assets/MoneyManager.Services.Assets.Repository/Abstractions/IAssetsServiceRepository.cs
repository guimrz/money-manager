using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Repository.Abstractions
{
    public interface IAssetsServiceRepository
    {
        IQueryable<Asset> Assets { get; }

        IQueryable<Currency> Currencies { get; }

        Task<Asset> InsertAssetAsync(Asset asset, CancellationToken cancellationToken = default);

        Task<Asset> UpdateAssetAsync(Asset asset, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
