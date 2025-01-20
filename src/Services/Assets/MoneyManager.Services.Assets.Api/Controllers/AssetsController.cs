using Microsoft.AspNetCore.Mvc;
using MoneyManager.Services.Assets.Application.Abstractions;
using MoneyManager.Services.Assets.Application.Objects.Requests;

namespace MoneyManager.Services.Assets.Api.Controllers
{
    [Route("api/assets")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsService _service;

        public AssetsController(IAssetsService service)
        {
            ArgumentNullException.ThrowIfNull(service);

            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssets(string? name, CancellationToken cancellationToken = default)
        {
            var assets = await _service.GetAssetsAsync(name, cancellationToken);

            return Ok(assets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsset([FromBody] CreateAssetRequest request, CancellationToken cancellationToken = default)
        {
            var assetCreated = await _service.CreateAssetAsync(request, cancellationToken);

            return CreatedAtAction(nameof(GetAsset), new { assetId = assetCreated.Id }, assetCreated);
        }

        [HttpGet("{assetId:guid}")]
        public async Task<IActionResult> GetAsset(Guid assetId, CancellationToken cancellationToken = default)
        {
            var asset = await _service.GetAssetAsync(assetId, cancellationToken);

            return asset is null ? NotFound() : Ok(asset);
        }

        [HttpPost("{assetId:guid}/transactions")]
        public async Task<IActionResult> CreateAssetTransaction(Guid assetId, [FromBody] CreateTransactionRequest request, CancellationToken cancellationToken = default)
        {
            await _service.CreateAssetTransactionAsync(assetId, request, cancellationToken);

            return Created();
        }

        [HttpGet("{assetId:guid}/transactions")]
        public async Task<IActionResult> GetAssetTransactions(Guid assetId, [FromQuery] DateTimeOffset? dateFrom = null, [FromQuery] DateTimeOffset? dateTo = null, CancellationToken cancellationToken = default)
        {
            var transactions = await _service.GetAssetTransactionsAsync(assetId, dateFrom, dateTo, cancellationToken);

            return Ok(transactions);
        }
    }
}
