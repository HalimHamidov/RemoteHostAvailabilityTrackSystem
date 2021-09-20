using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Requests;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface IAddJobService
    {
        public Task AddJob(AddJobRequest job, long userId,  CancellationToken cancellationToken);
    }
}
