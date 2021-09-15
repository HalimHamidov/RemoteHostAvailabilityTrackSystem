using System.Collections.Generic;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Services;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Controllers
{
    [Route("api/v1/check")]
    [ApiController]
    public class CheckApiController
    {
        private readonly ICheckApiService _checkApiService;
        private readonly IAddJobService _addJobService;
        private readonly IGetJobsService _getJobsService;

        public CheckApiController(ICheckApiService checkApiService, IAddJobService addJobService, IGetJobsService getJobsService)
        {
            _checkApiService = checkApiService;
            _addJobService = addJobService;
            _getJobsService = getJobsService;
        }

        [HttpGet]
        public async Task<bool> CheckApi([FromQuery] CheckApiRequest request, CancellationToken cancellationToken)
        {
            var result = await _checkApiService.CheckApi(request, cancellationToken);
            return result.IsValid;
        }
        
        [HttpPost]
        [Route("add-job")]
        public async Task AddJob([FromBody] AddJobRequest model, CancellationToken cancellationToken)
        {
            await _addJobService.AddJob(model, cancellationToken);
        }
        
        [HttpGet]
        [Route("get-jobs")]
        public async Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken)
        {
            return await _getJobsService.GetJobs(cancellationToken);
        }
    }
}