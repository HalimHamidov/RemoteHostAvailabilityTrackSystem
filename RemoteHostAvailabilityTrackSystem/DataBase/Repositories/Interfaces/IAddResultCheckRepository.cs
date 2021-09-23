using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// репозиторий добавления результата.
    /// </summary>
    public interface IAddResultCheckRepository
    {
        /// <summary>
        /// добавление результата.
        /// </summary>
        /// <param name="checkApiResult"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AddResult(CheckApiResult checkApiResult, CancellationToken cancellationToken);
    }
}
