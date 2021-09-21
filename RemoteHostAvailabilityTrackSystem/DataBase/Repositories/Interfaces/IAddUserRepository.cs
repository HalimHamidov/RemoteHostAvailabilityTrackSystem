using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IAddUserRepository
    {
        public Task AddUser(string login, string password, CancellationToken cancellationToken);
    }
}
