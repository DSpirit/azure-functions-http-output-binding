using System.Net.Http;

namespace HttpRequestMessageBinding.Collector
{
    public class HttpRequestMessageBindingContext
    {
        public HttpRequestMessageAttribute ResolvedAttribute { get; set; }

        public HttpClient HttpClient { get; set; }
    }
}
