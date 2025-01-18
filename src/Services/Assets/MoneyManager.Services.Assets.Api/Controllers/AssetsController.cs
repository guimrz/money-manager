using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MoneyManager.Services.Assets.Api.Controllers
{
    [Route("assets")]
    public class AssetsController : ControllerBase
    {
        [HttpPost]
        public Task<IActionResult> CreateAssetAsync([FromBody]object request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
