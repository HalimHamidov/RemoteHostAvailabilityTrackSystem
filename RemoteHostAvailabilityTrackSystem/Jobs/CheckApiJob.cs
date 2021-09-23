using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Jobs
{
    /// <summary>
    /// служба по проверке удаленного хоста(сайта)
    /// </summary>
    public class CheckApiJob : IJob
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="serviceScopeFactory"></param>
        public CheckApiJob(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        /// <summary>
        /// вызов метода.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Execute(IJobExecutionContext context)
        {
            var dateTime = DateTime.Now;
            using var scope = _serviceScopeFactory.CreateScope();
            var getJobsService = scope.ServiceProvider.GetService<IGetJobsService>();
            if (getJobsService == null)
                throw new Exception("IGetJobsService is null");
            var checkApiService = scope.ServiceProvider.GetService<ICheckApiService>();
            if (checkApiService == null)
                throw new Exception("ICheckApiService is null");

            var getJobId = scope.ServiceProvider.GetService<IGetJobIdAndDateByParamsRepository>();
            if (getJobId == null)
                throw new Exception("IGetJobIdAndDateByParamsRepository is null");
            var jobs = await getJobsService.GetJobs(CancellationToken.None);

            async Task Check(string api, int jobId)
            {
                await checkApiService.CheckApi(new CheckApiRequest
                {
                    Api = api,
                    JobId = jobId
                }, CancellationToken.None);
            }

            var groupJobs = jobs
                .GroupBy(q => new {q.Api, q.HoursInterval, q.MinutesInterval})
                .Select(s => new
                {
                    s.Key.Api,
                    s.Key.HoursInterval,
                    s.Key.MinutesInterval
                });
            foreach (var one in groupJobs)
            {
                var jobInfo = await getJobId.GetId(one.Api, one.MinutesInterval, one.HoursInterval,
                    CancellationToken.None);
                if (jobInfo.Item2 == null)
                    await Check(one.Api, jobInfo.Item1);
                else if ((one.MinutesInterval != null || one.HoursInterval != null)
                         && jobInfo.Item2.Value
                             .AddMinutes(one.MinutesInterval ?? 0)
                             .AddMinutes((double) (one.HoursInterval ?? 0) * 60) <= dateTime)
                    await Check(one.Api, jobInfo.Item1);
            }
        }
    }
}
