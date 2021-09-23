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
{   /// <summary>
    /// Контроллер для работы.
    /// </summary>
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
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="checkApiService"></param>
        /// <param name="addJobService"></param>
        /// <param name="getJobsService"></param>
        /// <param name="checkAllApiService"></param>
        /// <param name="getCheckInPeriodService"></param>
        /// <param name="checkAuthService"></param>
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
        /// <summary>
        /// Проверяем сайт указанный в запросе.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="api"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// true - доступен, false - недоступен.
        /// </returns>
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
        /// <summary>
        /// Добавление новой службы.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Возможные ошибки:
        /// * Не валидный сайт.
        /// </returns>
        [HttpPost]
        [Route("add-job/{key}")]
        public async Task AddJob([FromRoute] string key, [FromBody] AddJobRequest model, CancellationToken cancellationToken)
        {
            var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
            await _addJobService.AddJob(model, userId, cancellationToken);
        }
        /// <summary>
        /// Получение списка всех служб.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Все существующие службы.
        /// </returns>
        [HttpGet]
        [Route("get-jobs/{key}")]
        public async Task<ICollection<CheckApiJobModel>> GetJobs([FromRoute] string key, CancellationToken cancellationToken)
        {
            var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
            var jobs = await _getJobsService.GetJobs(cancellationToken);
            return jobs.Where(q => q.UserId == userId).ToList();
        }
        /// <summary>
        /// Проверка всех служб пользователя.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("check-all/{key}")]
        public async Task<ICollection<CheckAllApiResponse>> CheckAll([FromRoute] string key,CancellationToken cancellationToken)
        {
            var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
            return await _checkAllApiService.CheckAll(userId, cancellationToken);
        }
        /// <summary>
        /// Получение списка проверок в промежутке времени.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// список всех служб в интервале времени.
        /// </returns>
        [HttpGet]
        [Route("get-check-in-periods/{key}")]
        public async Task<ICollection<GetCheckInPeriodResponse>> GetJobs([FromRoute] string key,[FromQuery]GetCheckInPeriodRequest request, CancellationToken cancellationToken)
        {
            var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
            return await _getCheckInPeriodService.GetCheckInPeriod(userId,request, cancellationToken);
        }

    }
}
