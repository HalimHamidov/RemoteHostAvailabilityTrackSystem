using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace RemoteHostAvailabilityTrackSystem.Jobs
{
    /// <summary>
    /// Фабрика Служб
    /// </summary>
    public class JobFactory : IJobFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="serviceScopeFactory"></param>
        public JobFactory(IServiceScopeFactory serviceScopeFactory)
        {
            this._serviceScopeFactory = serviceScopeFactory;
        }
        /// <summary>
        /// Новая служба
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="scheduler"></param>
        /// <returns></returns>
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var job = scope.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
            return job;
        }
        /// <summary>
        /// Удалить службу
        /// </summary>
        /// <param name="job"></param>
        public void ReturnJob(IJob job)
        {
           // throw new NotImplementedException();
        }
    }
}
