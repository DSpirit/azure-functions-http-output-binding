using Microsoft.Azure.WebJobs;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpRequestMessageBinding.Collector
{
    public class HttpRequestMessageBindingAsyncCollector<T> : IAsyncCollector<T>
    {
        private HttpRequestMessageBindingContext httpContext;

        public HttpRequestMessageBindingAsyncCollector(HttpRequestMessageBindingContext httpContext) => this.httpContext = httpContext;

        public async Task AddAsync(
            T item,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            await SendAsync(this.httpContext, item);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // no-op
            return Task.FromResult(0);
        }

        private static async Task SendAsync(HttpRequestMessageBindingContext context, T item)
        {
            var convertedItem = item as HttpRequestMessage;

            await context.HttpClient.SendAsync(convertedItem);
        }
    }
}
