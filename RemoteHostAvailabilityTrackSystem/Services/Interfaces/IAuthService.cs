using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    /// <summary>
    /// сервис авторизации пользователя.
    /// </summary>
    public interface IAuthService
    {
       /// <summary>
       /// метод сервиса авторизации пользователя.
       /// </summary>
       /// <param name="login"></param>
       /// <param name="password"></param>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
       public Task<string> Auth(string login, string password, CancellationToken cancellationToken);
    }
}
