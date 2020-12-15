using Papastreet.JobRunner.Jobs;
using Quartz;
using Quartz.Impl;
using System;

namespace Papastreet.JobRunner
{
    public static class JobConfig
    {
        public static void Start()
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            AddJob<AnnounceJob>(scheduler, TimeSpan.FromSeconds(15), DateTime.Now);
            scheduler.Start();
        }

        private static void AddJob<T>(IScheduler scheduler, TimeSpan repeateTimeSpan, DateTime startAt) where T : IJob
        {
            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(nameof(T), "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity($"{nameof(T)}Trigger", "group1")
                    .StartAt(startAt)
                    .WithSimpleSchedule(simpleSchedule => simpleSchedule.WithInterval(repeateTimeSpan)
                    .RepeatForever())
                    .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
