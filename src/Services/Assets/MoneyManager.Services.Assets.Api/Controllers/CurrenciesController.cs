using Microsoft.AspNetCore.Mvc;
using MoneyManager.Services.Assets.Application.Abstractions;
using MoneyManager.Services.Assets.Application.Objects.Responses;
using System.Net;

namespace MoneyManager.Services.Assets.Api.Controllers
{
    [Route("api/currencies")]
    public class CurrenciesController : ControllerBase
    {
        private readonly IAssetsService _service;

        public CurrenciesController(IAssetsService service)
        {
            ArgumentNullException.ThrowIfNull(service);

            _service = service;
        }

        /// <summary>
        /// Retrieves a list of available currencies.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to monitor for cancellation requests. Defaults to <see cref="CancellationToken.None"/> if not provided.
        /// </param>
        /// <response code="200">
        /// Returns a collection of <see cref="CurrencyResponse"/> objects.
        /// </response>
        [HttpGet]
        [ProducesResponseType<CurrencyResponse[]>((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<CurrencyResponse> currencies = await _service.GetCurrenciesAsync(cancellationToken);

            return Ok(currencies);
        }
    }
}
