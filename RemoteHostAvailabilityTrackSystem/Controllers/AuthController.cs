using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RemoteHostAvailabilityTrackSystem.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController
    {
        [HttpPost]
        [Route("add-user")]
        public async Task AddUser(CancellationToken cancellationToken)
        {
        }

        [HttpGet]
        [Route("user")]
        public async Task<string> Authorize(CancellationToken cancellationToken)
        {
            return "user";
        }
    }
}
