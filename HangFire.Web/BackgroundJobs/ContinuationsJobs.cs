using System.Diagnostics;

namespace HangFire.Web.BackgroundJobs
{
    public class ContinuationsJobs
    {
        public static void WriteWatemarkStatusJob(string id, string fileName) { 
        
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{fileName}: resime watermark eklenmiştir."));
        }
    }
}
