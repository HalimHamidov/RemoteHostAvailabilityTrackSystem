using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// Получение всех пользователей из репозитория.
    /// </summary>
    public interface IGetUsersRepository
    {
        /// <summary>
        /// Получение всех пользователей.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
       public Task<ICollection<UserModel>> GetUsers(CancellationToken cancellationToken);
    }
}
