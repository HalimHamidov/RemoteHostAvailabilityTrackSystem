using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authorize(string login, string password, CancellationToken cancellationToken);
    }
}
