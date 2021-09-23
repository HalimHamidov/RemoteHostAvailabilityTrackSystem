using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Controllers
{
    /// <summary>
    /// Контроллер для авторизации
    /// </summary>
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController
    {

        private readonly IAddUserService _addUserService;
        private readonly IAuthService _authService;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="addUserService"></param>
        /// <param name="authService"></param>
        public AuthController(IAddUserService addUserService, IAuthService authService)
        {
            _addUserService = addUserService;
            _authService = authService;

        }
        /// <summary>
        /// Добавления нового пользователя
        /// ---
        /// * Обязательные поля для ввода: логин, пароль
        /// * Если пользователь с таким логином уже существует - будет исключение
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>add-user</returns>
        [HttpPost]
        [Route("add-user")]
        public async Task AddUser([FromQuery] string login,[FromQuery] string password, CancellationToken cancellationToken)
        {
            await _addUserService.AddUser(login, password, cancellationToken);
        }
        /// <summary>
        /// Авторизация пользователя
        /// ---
        /// * Логин и пароль обязательны
        /// * Если пользователя нет - будет исключение
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>auth-user</returns>
        [HttpGet]
        [Route("auth-user")]
        public async Task<string> Auth([FromQuery] string login,[FromQuery] string password, CancellationToken cancellationToken)
        {
            return await _authService.Auth(login, password, cancellationToken);
        }
    }
}
