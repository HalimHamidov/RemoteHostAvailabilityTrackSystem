using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    public class CheckAllApiService : ICheckAllApiService
    {
        private readonly IGetJobsRepository _getJobsRepository;
        private readonly ICheckApiService _checkApiService;
        private readonly IAddResultCheckRepository _addResultCheckRepository;

        public CheckAllApiService(IGetJobsRepository getJobsRepository, ICheckApiService checkApiService,
            IAddResultCheckRepository addResultCheckRepository)
        {
            _getJobsRepository = getJobsRepository;
            _checkApiService = checkApiService;
            _addResultCheckRepository = addResultCheckRepository;
        }

        public async Task<ICollection<CheckAllApiResponse>> CheckAll(CancellationToken cancellationToken)
        {
            var results = new List<CheckAllApiResponse>();
            var jobs = await _getJobsRepository.GetJobs(cancellationToken);
            foreach (var one  in jobs)
            {
                var result = await _checkApiService.CheckApi(new CheckApiRequest
                {
                    Api = one.Api
                }, cancellationToken);
                results.Add(new CheckAllApiResponse
                {
                    Api = one.Api,
                    IsValid = result.IsValid
                });
                await _addResultCheckRepository.AddResult(new CheckApiResult
                {
                    CheckApiJobId = one.Id,
                    IsValid = result.IsValid,
                    RunDate = DateTime.Now
                }, cancellationToken);
            }
            return results;
        }
    }
}