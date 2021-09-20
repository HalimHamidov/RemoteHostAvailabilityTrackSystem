using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IGetUsersRepository
    {
        Task<ICollection<UserModel>> GetUsers(CancellationToken cancellationToken);
    }
}
