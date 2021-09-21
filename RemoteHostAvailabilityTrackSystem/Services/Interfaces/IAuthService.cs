using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface IAuthService
    {
       public Task<string> Auth(string login, string password, CancellationToken cancellationToken);
    }
}
