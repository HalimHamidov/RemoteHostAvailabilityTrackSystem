using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// репозиторий получения служб по трем параметрам.
    /// </summary>
    public interface IGetJobIdAndDateByParamsRepository
    {
        /// <summary>
        /// Получение идентификатор.
        /// </summary>
        /// <param name="api"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<(int, DateTime?)> GetId(string api, int? minutes, int? hours,
            CancellationToken cancellationToken);
    }
}
