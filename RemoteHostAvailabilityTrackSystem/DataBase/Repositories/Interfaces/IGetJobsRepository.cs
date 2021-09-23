using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий получения всех служб.
    /// </summary>
    public interface IGetJobsRepository
    {
        /// <summary>
        /// Получение всех служб.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken);
    }
}
