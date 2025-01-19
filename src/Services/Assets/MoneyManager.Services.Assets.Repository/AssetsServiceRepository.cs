using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoneyManager.Services.Assets.Domain;
using MoneyManager.Services.Assets.Repository.Abstractions;

namespace MoneyManager.Services.Assets.Repository
{
    public class AssetsServiceRepository : IAssetsServiceRepository
    {
        private readonly ILogger _logger;
        private readonly AssetsServiceDbContext _dbContext;

        public AssetsServiceRepository(ILogger<AssetsServiceRepository> logger, AssetsServiceDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(dbContext);

            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Currency> currencies = await _dbContext.Set<Currency>().ToListAsync(cancellationToken);

            return currencies;
        }
    }
}
