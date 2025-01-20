using MoneyManager.Services.Assets.Application.Objects.Requests;
using MoneyManager.Services.Assets.Application.Objects.Responses;

namespace MoneyManager.Services.Assets.Application.Abstractions
{
    public interface IAssetsService
    {
        Task<IEnumerable<CurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken = default);

        Task<AssetResponse> CreateAssetAsync(CreateAssetRequest assetDetails, CancellationToken cancellationToken = default);

        Task<AssetResponse?> GetAssetAsync(Guid assetId, CancellationToken cancellationToken = default);
    }
}
