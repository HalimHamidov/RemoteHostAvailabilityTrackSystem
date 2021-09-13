using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface ICheckApiService
    {
        public Task<CheckApiResponse> CheckApi(CheckApiRequest request, CancellationToken cancellationToken);
    }


}