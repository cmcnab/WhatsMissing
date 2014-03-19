namespace WhatsMissing.Web
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public static class HttpResponseExtensions
    {
        public static T Deserialize<T>(this IHttpResponse response, Func<Stream, T> responseParser)
        {
            using (var responseStream = response.GetResponseStream())
            {
                return responseParser(responseStream);
            }
        }

        public static Task<T> DeserializeAsync<T>(this IHttpResponse response, Func<Stream, Task<T>> responseParser)
        {
            using (var responseStream = response.GetResponseStream())
            {
                return responseParser(responseStream);
            }
        }
    }
}
