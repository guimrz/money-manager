using AutoMapper;
using MoneyManager.Services.Assets.Application.Abstractions;
using MoneyManager.Services.Assets.Application.Objects.Responses;
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

        public async Task<IEnumerable<CurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken)
        {
            var currencies = await _repository.GetCurrenciesAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CurrencyResponse>>(currencies);
        }
    }
}
