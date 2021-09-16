using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IAddResultCheckRepository
    {
        public Task AddResult(CheckApiResult checkApiResult, CancellationToken cancellationToken);
    }
}