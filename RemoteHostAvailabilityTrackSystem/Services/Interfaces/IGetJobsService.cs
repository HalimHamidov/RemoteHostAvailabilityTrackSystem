using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    /// <summary>
    /// сервис получения всех служб.
    /// </summary>
    public interface IGetJobsService
    {
        /// <summary>
        /// метод получения всех служб.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken);
    }
}
