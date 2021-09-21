using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IAuthRepository
    {
       public Task Auth(UserModel userModel, CancellationToken cancellationToken);
    }
}
