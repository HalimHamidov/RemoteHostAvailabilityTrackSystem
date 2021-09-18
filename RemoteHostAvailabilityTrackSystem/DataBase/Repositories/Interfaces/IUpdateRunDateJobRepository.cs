using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IUpdateRunDateJobRepository
    {
        public Task UpdateRunDate(int jobId, DateTime newRunDate, CancellationToken cancellationToken);
    }
}
