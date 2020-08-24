using HttpRequestMessageBinding;
using HttpRequestMessageBinding.ConfigProvider;
using HttpRequestMessageBinding.Connector;
using HttpRequestMessageBinding.WebJobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: WebJobsStartup(typeof(HttpRequestMessageWebJobsStartup))]

namespace HttpRequestMessageBinding.WebJobs
{
    public static class HttpRequestMessageWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddHttpClient(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<HttpRequestMessageBindingConfigProvider>();

            builder.Services.AddSingleton<IHttpRequestMessageBindingCollectorFactory, HttpRequestMessageBindingCollectorFactory>();

            return builder;
        }
    }
}
