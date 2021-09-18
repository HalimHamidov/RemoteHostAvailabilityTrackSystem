using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface ICheckApiService
    {
        Task<CheckApiResponse> CheckApi(CheckApiRequest request, CancellationToken cancellationToken);
    }
}
