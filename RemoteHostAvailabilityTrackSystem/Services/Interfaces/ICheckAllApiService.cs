using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{   /// <summary>
    ///  сервис проверки всех сайтов. 
    /// </summary>
    public interface ICheckAllApiService
    {
        /// <summary>
        /// метод сервиса проверки всех апи.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ICollection<CheckAllApiResponse>> CheckAll(long userId, CancellationToken cancellationToken);
    }
}
