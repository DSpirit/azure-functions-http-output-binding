using HttpRequestMessageBinding.WebJobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(HttpRequestMessageWebJobsStartup))]

namespace HttpRequestMessageBinding.WebJobs
{
    public class HttpRequestMessageWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddHttpClient();
        }
    }
}