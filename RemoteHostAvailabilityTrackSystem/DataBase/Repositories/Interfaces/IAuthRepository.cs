using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task Auth(UserModel userModel, CancellationToken cancellationToken);
    }
}
