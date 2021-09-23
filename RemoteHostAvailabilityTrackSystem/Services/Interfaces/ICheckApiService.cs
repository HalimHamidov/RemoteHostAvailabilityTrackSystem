using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    /// <summary>
    /// сервис проверки статуса сайта.
    /// </summary>
    public interface ICheckApiService
    {
        /// <summary>
        /// Метод проверки сайта
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
       public Task<CheckApiResponse> CheckApi(CheckApiRequest request, CancellationToken cancellationToken);
    }
}
