using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces
{
    public interface IGetCheckAllResultRepository
    {
        public Task<ICollection<GetCheckInPeriodResponse>> GetAll(CancellationToken cancellationToken);
    }
}