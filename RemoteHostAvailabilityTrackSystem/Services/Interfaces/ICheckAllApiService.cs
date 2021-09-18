using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface ICheckAllApiService
    {
        public Task<ICollection<CheckAllApiResponse>> CheckAll(CancellationToken cancellationToken);
    }
}