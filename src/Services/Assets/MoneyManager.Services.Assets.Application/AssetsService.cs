using AutoMapper;
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

        public async Task<AssetResponse> CreateAssetAsync(CreateAssetRequest assetDetails, CancellationToken cancellationToken = default)
        {
            var currency = await _repository.GetCurrencyAsync(assetDetails.CurrencyId, cancellationToken);

            if (currency is null)
            {
                throw new InvalidOperationException("The specified currency is invalid.");
            }

            Asset asset = new Asset(assetDetails.Name, assetDetails.CurrencyId);

            asset = await _repository.InsertAssetAsync(asset, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AssetResponse>(asset);
        }

        public async Task<AssetResponse?> GetAssetAsync(Guid assetId, CancellationToken cancellationToken = default)
        {
            var asset = await _repository.GetAssetAsync(assetId, cancellationToken);

            return _mapper.Map<AssetResponse?>(asset);            
        }

        public async Task<IEnumerable<CurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken)
        {
            var currencies = await _repository.GetCurrenciesAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CurrencyResponse>>(currencies);
        }
    }
}
