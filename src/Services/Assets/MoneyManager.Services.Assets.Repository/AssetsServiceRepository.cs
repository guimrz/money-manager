﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<Asset?> GetAssetAsync(Guid assetId, CancellationToken cancellationToken = default)
        {
            Asset? assetDetails = await _dbContext.Set<Asset>()
                .Include(asset => asset.Transactions)
                .AsNoTracking()
                .SingleOrDefaultAsync(asset => asset.Id == assetId);

            return assetDetails;
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Currency> currencies = await _dbContext.Set<Currency>().ToListAsync(cancellationToken);

            return currencies;
        }

        public async Task<Currency?> GetCurrencyAsync(int currencyId, CancellationToken cancellationToken = default)
        {
            Currency? currency = await _dbContext.Set<Currency>()
                .AsNoTracking()
                .SingleOrDefaultAsync(curr => curr.Id == currencyId, cancellationToken);

            return currency;
        }

        public async Task<Asset> InsertAssetAsync(Asset asset, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(asset);

            EntityEntry<Asset> entity = await _dbContext.Set<Asset>().AddAsync(asset, cancellationToken);

            return entity.Entity;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);   
        }
    }
}
