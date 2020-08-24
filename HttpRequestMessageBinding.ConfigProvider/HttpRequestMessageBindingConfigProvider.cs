using HttpRequestMessageBinding.Collector;
using HttpRequestMessageBinding.Connector;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;

namespace HttpRequestMessageBinding.ConfigProvider
{
    [Extension("Http")]
    public class HttpRequestMessageBindingConfigProvider : IExtensionConfigProvider
    {
        private readonly IHttpRequestMessageBindingCollectorFactory httpBindingCollectorFactory;

        private ConcurrentDictionary<string, HttpClient> CollectorCache { get; } = new ConcurrentDictionary<string, HttpClient>();

        public HttpRequestMessageBindingConfigProvider(IHttpRequestMessageBindingCollectorFactory httpBindingCollectorFactory)
        {
            this.httpBindingCollectorFactory = httpBindingCollectorFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var rule = context.AddBindingRule<HttpRequestMessageAttribute>();
        
            rule.BindToCollector<HttpRequestMessageBindingOpenType>(typeof(HttpRequestMessageBindingConverter<>), this);
        }

        internal HttpRequestMessageBindingContext CreateContext(HttpRequestMessageAttribute attribute)
        {
            HttpClient client = this.httpBindingCollectorFactory.CreateClient();

            return new HttpRequestMessageBindingContext
            {
                HttpClient = client,
                ResolvedAttribute = attribute,
            };
        }

        private class HttpRequestMessageBindingOpenType : OpenType.Poco
        {
            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return false;
                }

                if (type.FullName == "System.Net.Http.HttpRequestMessage")
                {
                    return true;
                }

                return base.IsMatch(type, context);
            }
        }
    }
}
