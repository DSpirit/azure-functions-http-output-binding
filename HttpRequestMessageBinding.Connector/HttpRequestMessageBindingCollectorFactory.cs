using System;
using System.Net.Http;

namespace HttpRequestMessageBinding.Connector
{
    public class HttpRequestMessageBindingCollectorFactory : IHttpRequestMessageBindingCollectorFactory
    {
        private static HttpClient client = new HttpClient();

        public HttpClient CreateClient()
        {
            return client;
        }
    }
}
