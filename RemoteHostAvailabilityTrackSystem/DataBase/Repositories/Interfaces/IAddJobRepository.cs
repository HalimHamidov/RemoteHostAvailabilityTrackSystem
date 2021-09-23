using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    /// <summary>
    /// репозиторий добавления службы.
    /// </summary>
    public interface IAddJobRepository
    {
        /// <summary>
        /// добавление слуюбы.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Add(CheckApiJobModel request, CancellationToken cancellationToken);
    }
}
