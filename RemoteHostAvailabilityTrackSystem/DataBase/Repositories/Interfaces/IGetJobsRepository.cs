using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IGetJobsRepository
    {
        public Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken);
    }
}