using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// репозиторий добавления пользователя.
    /// </summary>
    public interface IAddUserRepository
    {
        /// <summary>
        /// добавление пользователя.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AddUser(string login, string password, CancellationToken cancellationToken);
    }
}
