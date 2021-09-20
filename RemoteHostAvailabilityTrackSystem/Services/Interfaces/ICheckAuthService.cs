using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface ICheckAuthService
    {
        public Task<long> CheckAuth(string key, CancellationToken cancellationToken);
    }
}
