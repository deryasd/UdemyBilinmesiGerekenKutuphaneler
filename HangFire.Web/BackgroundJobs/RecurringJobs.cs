using Hangfire;
using System.Diagnostics;

namespace HangFire.Web.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            RecurringJob.AddOrUpdate(
                recurringJobId: "reportjob1",     
                methodCall: () => EmailReport(),  
                cronExpression: Cron.Minutely             
            );
        }
        public static void EmailReport() { 

            Debug.WriteLine("Rapor, email olarak gönderildi");

        }
    }
}
