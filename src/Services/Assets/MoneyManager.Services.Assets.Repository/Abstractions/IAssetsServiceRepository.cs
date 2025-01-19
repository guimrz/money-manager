using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Repository.Abstractions
{
    public interface IAssetsServiceRepository
    {
        Task<IEnumerable<Currency>> GetCurrenciesAsync(CancellationToken cancellationToken = default);
    }
}
