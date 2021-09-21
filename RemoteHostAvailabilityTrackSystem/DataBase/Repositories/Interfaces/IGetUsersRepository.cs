using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IGetUsersRepository
    {
       public Task<ICollection<UserModel>> GetUsers(CancellationToken cancellationToken);
    }
}
