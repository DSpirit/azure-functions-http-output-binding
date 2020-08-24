using HttpRequestMessageBinding.Collector;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpRequestMessageBinding.ConfigProvider
{
  internal class HttpRequestMessageBindingConverter<T> : IConverter<HttpRequestMessageAttribute, IAsyncCollector<T>>
    {
        private readonly HttpRequestMessageBindingConfigProvider configProvider;

        public HttpRequestMessageBindingConverter(HttpRequestMessageBindingConfigProvider configProvider)
        {
            this.configProvider = configProvider;
        }

        public IAsyncCollector<T> Convert(HttpRequestMessageAttribute attribute)
        {
            HttpRequestMessageBindingContext context = this.configProvider.CreateContext(attribute);
            return new HttpRequestMessageBindingAsyncCollector<T>(context);
        }
    }
}
