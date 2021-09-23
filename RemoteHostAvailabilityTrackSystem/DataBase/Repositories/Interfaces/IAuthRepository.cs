using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// репозиторий авторизации.
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// метод авторизации.
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
       public Task Auth(UserModel userModel, CancellationToken cancellationToken);
    }
}
