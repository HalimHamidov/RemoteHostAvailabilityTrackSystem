using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface IGetCheckInPeriodService
    {
        Task<ICollection<GetCheckInPeriodResponse>> GetCheckInPeriod(GetCheckInPeriodRequest request,
            CancellationToken cancellationToken);
    }
}