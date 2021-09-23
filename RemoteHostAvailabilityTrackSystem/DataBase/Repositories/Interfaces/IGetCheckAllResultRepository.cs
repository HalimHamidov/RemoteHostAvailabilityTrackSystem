using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// репозиторий получения всех результатов.
    /// </summary>
    public interface IGetCheckAllResultRepository
    {
        /// <summary>
        /// получения всех результатов.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ICollection<GetCheckInPeriodResponse>> GetAll(long userId, CancellationToken cancellationToken);
    }
}
