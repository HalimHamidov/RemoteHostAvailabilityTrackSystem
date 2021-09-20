using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController
    {

        private readonly IAddUserService _addUserService;
        private readonly IAuthService _authService;

        public AuthController(IAddUserService addUserService, IAuthService authService)
        {
            _addUserService = addUserService;
            _authService = authService;

        }

        [HttpPost]
        [Route("add-user")]
        public async Task AddUser([FromQuery] string login,[FromQuery] string password, CancellationToken cancellationToken)
        {
            await _addUserService.AddUser(login, password, cancellationToken);
        }

        [HttpGet]
        [Route("auth-user")]
        public async Task<string> Authorize([FromQuery] string login,[FromQuery] string password, CancellationToken cancellationToken)
        {
            return await _authService.Authorize(login, password, cancellationToken);
        }
    }
}
