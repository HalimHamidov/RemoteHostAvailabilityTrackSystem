using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    /// <summary>
    /// Получение проверок в промежуток времени.
    /// </summary>
    public interface IGetCheckInPeriodService
    {
        /// <summary>
        /// метод сервиса для получения проверок в промежутке времени.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ICollection<GetCheckInPeriodResponse>> GetCheckInPeriod(long userId, GetCheckInPeriodRequest request,
            CancellationToken cancellationToken);
    }
}
