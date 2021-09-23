using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    /// <inheritdoc />
    public class GetJobsService : IGetJobsService
    {
        private readonly IGetJobsRepository _getJobsRepository;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="getJobsRepository"></param>
        public GetJobsService(IGetJobsRepository getJobsRepository)
        {
            _getJobsRepository = getJobsRepository;
        }
        /// <inheritdoc />
        public async Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken)
        {
            var result =  await _getJobsRepository.GetJobs(cancellationToken);
            return result;
        }
    }
}
