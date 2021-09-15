using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IAddJobRepository
    {
        public Task Add(CheckApiJobModel request, CancellationToken cancellationToken);
    }
}