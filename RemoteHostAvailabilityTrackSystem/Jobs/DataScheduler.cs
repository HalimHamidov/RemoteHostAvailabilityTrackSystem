using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

namespace RemoteHostAvailabilityTrackSystem.Jobs
{
    public static class DataScheduler
    {
        public static async void Start(IServiceProvider serviceProvider)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.JobFactory = serviceProvider.GetService<JobFactory>() ?? throw new
                InvalidOperationException();
            await scheduler.Start();

            IJobDetail jobDetail = JobBuilder.Create<CheckApiJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("MailingTrigger", "default")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
    }

    }
}
