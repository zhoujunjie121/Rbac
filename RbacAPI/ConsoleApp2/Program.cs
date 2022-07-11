using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ConsoleApp2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //1、创建调度器
            ISchedulerFactory factory =new StdSchedulerFactory();
            IScheduler schedule = await factory.GetScheduler();

            //3、创建JobDetail
            var jobdetail=JobBuilder.Create<MyJob>().WithIdentity("myjob").Build();

            //键值对
            IDictionary<string, object> data = new Dictionary<string, object>();
            data.Add("a", Guid.NewGuid());
            data.Add("b", Guid.NewGuid());

            var jobdata = new JobDataMap(data);

            var job=JobBuilder.Create<MyJob>().SetJobData(jobdata).WithIdentity(new JobKey("myjob1")).Build();

            //4、创建触发器
            var trigger = TriggerBuilder.Create().WithSimpleSchedule(t =>
            {
                t.WithInterval(TimeSpan.FromSeconds(3)).WithRepeatCount(10);
            }).Build();

            //5、通过调度器调度作业执行
            await schedule.ScheduleJob(job, trigger);
            await schedule.Start();

            Console.ReadLine();
        }
        /// <summary>
        /// 创建job作业
        /// </summary>
        public class MyJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            {
                Console.WriteLine(context.JobDetail.JobDataMap.Get("a"));
                Console.WriteLine(context.JobDetail.Key.Name);
                Console.WriteLine(DateTime.Now);
            }
        }
    }
}
