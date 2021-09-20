using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    public interface IAddUserRepository
    {
        Task AddUser(string login, string password, CancellationToken cancellationToken);
    }
}