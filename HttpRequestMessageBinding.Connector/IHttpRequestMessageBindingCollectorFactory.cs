using System;
using System.Net.Http;

namespace HttpRequestMessageBinding.Connector
{
    public interface IHttpRequestMessageBindingCollectorFactory
    {
        HttpClient CreateClient();
    }
}
