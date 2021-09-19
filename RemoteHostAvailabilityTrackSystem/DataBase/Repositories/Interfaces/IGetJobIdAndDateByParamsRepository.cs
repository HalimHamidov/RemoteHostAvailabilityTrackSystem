using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IGetJobIdAndDateByParamsRepository
    {
        public Task<(int, DateTime?)> GetId(string api, int? minutes, int? hours,
            CancellationToken cancellationToken);
    }
}
