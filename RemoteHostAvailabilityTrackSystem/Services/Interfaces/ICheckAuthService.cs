using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    /// <summary>
    /// Проверка авторизации пользователя.
    /// </summary>
    public interface ICheckAuthService
    {
        /// <summary>
        /// метод проверки авторизации пользователя.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<long> CheckAuth(string key, CancellationToken cancellationToken);
    }
}
