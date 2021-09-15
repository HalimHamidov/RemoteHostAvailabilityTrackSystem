using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface IGetJobsService
    {
        public Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken);
    }
}