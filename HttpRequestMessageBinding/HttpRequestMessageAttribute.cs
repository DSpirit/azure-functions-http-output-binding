using Microsoft.Azure.WebJobs.Description;
using System;

namespace HttpRequestMessageBinding
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class HttpRequestMessageAttribute : Attribute
    {
        public HttpRequestMessageAttribute()
        {
        }
    }
}
