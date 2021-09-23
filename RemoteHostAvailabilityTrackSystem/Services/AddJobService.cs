using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    /// <inheritdoc />
    public class AddJobService : IAddJobService
    {
        private readonly IAddJobRepository _addJobRepository;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="addJobRepository"></param>
        public AddJobService(IAddJobRepository addJobRepository)
        {
            _addJobRepository = addJobRepository;
        }
        /// <inheritdoc />
        public async Task AddJob(AddJobRequest job, long userId, CancellationToken cancellationToken)
        {
            if (!Uri.IsWellFormedUriString(job.Api, UriKind.Absolute))
            {
                throw new Exception("invalid Api");
            }

            if (CheckZeroOrNullValue(job.HoursInterval) && CheckZeroOrNullValue(job.MinutesInterval))
            {
                throw new Exception("Please set the correct interval period ");
            }
            
            var request = new CheckApiJobModel
            {
                Api = job.Api,
                UserId = (int?)userId,
                HoursInterval = job.HoursInterval,
                MinutesInterval = job.MinutesInterval
            };
            await _addJobRepository.Add(request, cancellationToken);
        }

        private bool CheckZeroOrNullValue(int? value)
        {
            return value <= 0 || value == null;
        }
    }
}
