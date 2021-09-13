using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Controllers
{
    [Route("api/v1/check")]
    [ApiController]
    public class CheckApiController
    {
        private readonly ICheckApiService _checkApiService;
        public CheckApiController(ICheckApiService checkApiService)
        {
            _checkApiService = checkApiService;
        }

        [HttpGet]
        public async Task<bool> CheckApi([FromQuery] CheckApiRequest request, CancellationToken cancellationToken)
        {
            var result = await _checkApiService.CheckApi(request, cancellationToken);
            return result.IsValid;
        }
    }
}