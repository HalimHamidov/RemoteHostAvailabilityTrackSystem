using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Requests;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    /// <summary>
    /// добавление сервиса служб.
    /// </summary>
    public interface IAddJobService
    {
        /// <summary>
        /// добавление метода сервиса служб
        /// </summary>
        /// <param name="job"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AddJob(AddJobRequest job, long userId,  CancellationToken cancellationToken);
    }
}
