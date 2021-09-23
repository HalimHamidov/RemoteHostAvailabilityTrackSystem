using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    /// <summary>
    ///  сервис добавления пользователя.
    /// </summary>
    public interface IAddUserService
    {
        /// <summary>
        /// метод добавления пользователя сервиса.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
       public Task AddUser(string login, string password, CancellationToken cancellationToken);
    }
}
