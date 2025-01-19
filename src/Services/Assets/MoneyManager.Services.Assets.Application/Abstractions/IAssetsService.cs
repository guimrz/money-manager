using MoneyManager.Services.Assets.Application.Objects.Responses;

namespace MoneyManager.Services.Assets.Application.Abstractions
{
    public interface IAssetsService
    {
        Task<IEnumerable<CurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken);
    }
}
