using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class CheckApiController
    {
        private readonly ICheckApiService _checkApiService;
        private readonly IAddJobService _addJobService;
        private readonly IGetJobsService _getJobsService;
        private readonly ICheckAllApiService _checkAllApiService;
        private readonly IGetCheckInPeriodService _getCheckInPeriodService;
        private readonly ICheckAuthService _checkAuthService;

        public CheckApiController(ICheckApiService checkApiService, IAddJobService addJobService,
            IGetJobsService getJobsService, ICheckAllApiService checkAllApiService, IGetCheckInPeriodService getCheckInPeriodService, ICheckAuthService checkAuthService)
        {
            _checkApiService = checkApiService;
            _addJobService = addJobService;
            _getJobsService = getJobsService;
            _checkAllApiService = checkAllApiService;
            _getCheckInPeriodService = getCheckInPeriodService;
            _checkAuthService = checkAuthService;
        }

        [HttpGet]
        [Route("{key}")]
        public async Task<bool> CheckApi([FromRoute] string key,[FromQuery] string api, CancellationToken cancellationToken)
        {
            await _checkAuthService.CheckAuth(key, cancellationToken);
            var request = new CheckApiRequest
            {
                Api = api,
            };
            var result = await _checkApiService.CheckApi(request, cancellationToken);
            return result.IsValid;
        }

        [HttpPost]
        [Route("add-job/{key}")]
        public async Task AddJob([FromRoute] string key, [FromBody] AddJobRequest model, CancellationToken cancellationToken)
        {
            var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
            await _addJobService.AddJob(model, userId, cancellationToken);
        }

        [HttpGet]
        [Route("get-jobs/{key}")]
        public async Task<ICollection<CheckApiJobModel>> GetJobs([FromRoute] string key, CancellationToken cancellationToken)
        {
            var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
            var jobs = await _getJobsService.GetJobs(cancellationToken);
            return jobs.Where(q => q.UserId == userId).ToList();
        }

        [HttpPost]
        [Route("check-all/{key}")]
        public async Task<ICollection<CheckAllApiResponse>> CheckAll([FromRoute] string key,CancellationToken cancellationToken)
        {
            var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
            return await _checkAllApiService.CheckAll(userId, cancellationToken);
        }

        [HttpGet]
        [Route("get-check-in-periods/{key}")]
        public async Task<ICollection<GetCheckInPeriodResponse>> GetJobs([FromRoute] string key,[FromQuery]GetCheckInPeriodRequest request, CancellationToken cancellationToken)
        {
            var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
            return await _getCheckInPeriodService.GetCheckInPeriod(userId,request, cancellationToken);
        }

    }
}
