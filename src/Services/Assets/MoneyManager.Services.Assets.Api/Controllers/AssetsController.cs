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

        [HttpPost]
        public async Task<IActionResult> CreateAssetAsync([FromBody] CreateAssetRequest request, CancellationToken cancellationToken = default)
        {
            var assetCreated = await _service.CreateAssetAsync(request, cancellationToken);

            return CreatedAtAction(nameof(GetAssetAsync), new { assetId = assetCreated.Id }, assetCreated);
        }

        [HttpGet("{assetId:guid}")]
        public async Task<IActionResult> GetAssetAsync(Guid assetId, CancellationToken cancellationToken = default)
        {
            var asset = await _service.GetAssetAsync(assetId, cancellationToken);

            return asset is null ? NotFound() : Ok(asset);
        }
    }
}
