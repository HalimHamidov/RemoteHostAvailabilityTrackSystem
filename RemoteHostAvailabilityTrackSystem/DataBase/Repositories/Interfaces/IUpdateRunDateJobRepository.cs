using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// Изменение последнего времени запуска службы.
    /// </summary>
    public interface IUpdateRunDateJobRepository
    {
        /// <summary>
        /// Изменение времени запуска службы.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="newRunDate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task UpdateRunDate(int jobId, DateTime newRunDate, CancellationToken cancellationToken);
    }
}
