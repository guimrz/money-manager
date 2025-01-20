using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Services.Assets.Application.Abstractions;
using MoneyManager.Services.Assets.Application.Objects.Requests;
using MoneyManager.Services.Assets.Application.Objects.Responses;
using MoneyManager.Services.Assets.Domain;
using MoneyManager.Services.Assets.Repository.Abstractions;

namespace MoneyManager.Services.Assets.Application
{
    public class AssetsService : IAssetsService
    {
        private readonly IMapper _mapper;
        private readonly IAssetsServiceRepository _repository;

        public AssetsService(IAssetsServiceRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);

            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AssetResponse> CreateAssetAsync(CreateAssetRequest asset, CancellationToken cancellationToken = default)
        {
            var currency = await _repository.Currencies
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == asset.CurrencyId, cancellationToken);

            if (currency is null)
            {
                throw new InvalidOperationException("The specified currency is invalid.");
            }

            Asset newAsset = new Asset(asset.Name, asset.CurrencyId);

            newAsset = await _repository.InsertAssetAsync(newAsset, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AssetResponse>(newAsset);
        }

        public async Task CreateAssetTransactionAsync(Guid assetId, CreateTransactionRequest transaction, CancellationToken cancellationToken = default)
        {
            Asset? asset = await _repository.Assets
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == assetId, cancellationToken);

            if (asset is null)
            {
                throw new InvalidOperationException("The specified asset could not be found.");
            }

            Transaction newTransaction = new Transaction(transaction.Amount, transaction.Description, transaction.Date);

            asset.Add(newTransaction);

            asset = await _repository.UpdateAssetAsync(asset, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task<AssetResponse?> GetAssetAsync(Guid assetId, CancellationToken cancellationToken = default)
        {
            var asset = await _repository.Assets
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == assetId, cancellationToken);

            return _mapper.Map<AssetResponse?>(asset);
        }

        public async Task<IEnumerable<AssetResponse>> GetAssetsAsync(string? name, CancellationToken cancellationToken = default)
        {
            var assets = await _repository.Assets.AsNoTracking()
                .Where(p => string.IsNullOrEmpty(name) || p.Name.Contains(name))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<AssetResponse>>(assets);

        }

        public async Task<IEnumerable<TransactionResponse>> GetAssetTransactionsAsync(Guid assetId, DateTimeOffset? dateFrom = null, DateTimeOffset? dateTo = null, CancellationToken cancellationToken = default)
        {
            var asset = await _repository.Assets
                .AsNoTracking()
                .Include(p => p.Transactions
                    .Where(t => (dateFrom == null || t.Date >= dateFrom) && (dateTo == null || t.Date <= dateTo)))
                .SingleOrDefaultAsync(p => p.Id == assetId, cancellationToken);

            if (asset is null)
            {
                throw new InvalidOperationException($"The asset with id '{assetId}' could not be found.");
            }

            return _mapper.Map<IEnumerable<TransactionResponse>>(asset.Transactions);
        }

        public async Task<IEnumerable<CurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            var currencies = await _repository.Currencies
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CurrencyResponse>>(currencies);
        }
    }
}
