using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    /// <inheritdoc />
    public class GetCheckInPeriodService : IGetCheckInPeriodService
    {
        private readonly IGetCheckAllResultRepository _getCheckAllResultRepository;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="getCheckAllResultRepository"></param>
        public GetCheckInPeriodService(IGetCheckAllResultRepository getCheckAllResultRepository)
        {
            _getCheckAllResultRepository = getCheckAllResultRepository;
        }
        /// <inheritdoc />
        public async Task<ICollection<GetCheckInPeriodResponse>> GetCheckInPeriod(long userId, GetCheckInPeriodRequest request,
            CancellationToken cancellationToken)
        {
            var all = await _getCheckAllResultRepository.GetAll(userId, cancellationToken);
            var result = all.Where(q => q.Date >= (request.DateFrom ?? q.Date) && q.Date <= (request.DateEnd ?? q.Date)).ToList();
            return result;
        }
    }
}
