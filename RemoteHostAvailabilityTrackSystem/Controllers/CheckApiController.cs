using System.Collections.Generic;
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

        public CheckApiController(ICheckApiService checkApiService, IAddJobService addJobService,
            IGetJobsService getJobsService, ICheckAllApiService checkAllApiService, IGetCheckInPeriodService getCheckInPeriodService)
        {
            _checkApiService = checkApiService;
            _addJobService = addJobService;
            _getJobsService = getJobsService;
            _checkAllApiService = checkAllApiService;
            _getCheckInPeriodService = getCheckInPeriodService;
        }

        [HttpGet]
        public async Task<bool> CheckApi([FromQuery] string api, CancellationToken cancellationToken)
        {
            var request = new CheckApiRequest
            {
                Api = api
            };
            
            var result = await _checkApiService.CheckApi(request, cancellationToken);
            return result.IsValid;
        }
        
        [HttpGet]
        [Route("get-jobs")]
        public async Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken)
        {
            return await _getJobsService.GetJobs(cancellationToken);
        }

        [HttpPost]
        [Route("add-job")]
        public async Task AddJob([FromBody] AddJobRequest model, CancellationToken cancellationToken)
        {
            await _addJobService.AddJob(model, cancellationToken);
        }
        
        [HttpPost]
        [Route("check-all")]
        public async Task<ICollection<CheckAllApiResponse>> CheckAll(CancellationToken cancellationToken)
        {
            return await _checkAllApiService.CheckAll(cancellationToken);
           
        }
        
                        
        [HttpGet]
        [Route("get-check-in-periods")]
        public async Task<ICollection<GetCheckInPeriodResponse>> GetJobs([FromQuery]GetCheckInPeriodRequest request, CancellationToken cancellationToken)
        {
            return await _getCheckInPeriodService.GetCheckInPeriod(request, cancellationToken);
        }

        
        
    }
}
