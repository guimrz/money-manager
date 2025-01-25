using MoneyManager.Services.Assets.Application.Objects.Requests;
using MoneyManager.Services.Assets.Application.Objects.Responses;

namespace MoneyManager.Services.Assets.Application.Abstractions
{
    public interface IAssetsService
    {
        Task<IEnumerable<CurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken = default);

        Task<AssetResponse> CreateAssetAsync(CreateAssetRequest asset, CancellationToken cancellationToken = default);

        Task<AssetResponse?> GetAssetAsync(Guid assetId, CancellationToken cancellationToken = default);

        Task CreateAssetTransactionAsync(Guid assetId, CreateTransactionRequest transaction, CancellationToken cancellationToken = default);

        Task<IEnumerable<TransactionResponse>> GetAssetTransactionsAsync(Guid assetId, DateTimeOffset? dateFrom = null, DateTimeOffset? dateTo = null, CancellationToken cancellationToken = default);

        Task<IEnumerable<AssetResponse>> GetAssetsAsync(string? name, CancellationToken cancellationToken = default);

        Task DeleteAssetTransactionAsync(Guid assetId, Guid transactionId, CancellationToken cancellationToken = default);
    }
}
