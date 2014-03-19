namespace WhatsMissing.Web
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public static class HttpRequestExtensions
    {
        #region Http Options

        public static IHttpRequest BasicAuthentication(this IHttpRequest request, string username, string password)
        {
            var token = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
            request.Headers["Authorization"] = "Basic " + token;
            return request;
        }

        public static IHttpRequest IgnoreInvalidSslCertificates(this IHttpRequest request)
        {
            request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            return request;
        }

        #endregion

        public static Task<IHttpResponse> HttpGetAsync(this IHttpRequest request)
        {
            request.Method = "GET";
            return request.GetResponseAsync();
        }

        public static async Task<T> HttpGetAsync<T>(this IHttpRequest request, Func<Stream, T> responseParser)
        {
            var response = await request.HttpGetAsync();
            return response.Deserialize(responseParser);
        }

        public static async Task<T> HttpGetAsync<T>(this IHttpRequest request, Func<Stream, Task<T>> responseParser)
        {
            var response = await request.HttpGetAsync();
            return await response.DeserializeAsync(responseParser);
        }

        public static Task<IHttpResponse> HttpPostAsync(this IHttpRequest request)
        {
            request.Method = "POST";
            return request.GetResponseAsync();
        }

        public static async Task<IHttpResponse> HttpPostAsync(this IHttpRequest request, string contentType, Action<Stream> contentWriter)
        {
            request.Method = "POST";
            await request.SetContentType(contentType).SendContent(contentWriter);
            return await request.GetResponseAsync();
        }

        public static async Task<IHttpResponse> HttpPostAsync(this IHttpRequest request, string contentType, Func<Stream, Task> contentWriter)
        {
            request.Method = "POST";
            await request.SetContentType(contentType).SendContent(contentWriter);
            return await request.GetResponseAsync();
        }

        public static async Task<T> HttpPostAsync<T>(this IHttpRequest request, string contentType, Action<Stream> contentWriter, Func<Stream, T> responseParser)
        {
            var response = await request.HttpPostAsync(contentType, contentWriter);
            return response.Deserialize(responseParser);
        }

        public static async Task<T> HttpPostAsync<T>(this IHttpRequest request, string contentType, Func<Stream, Task> contentWriter, Func<Stream, Task<T>> responseParser)
        {
            var response = await request.HttpPostAsync(contentType, contentWriter);
            return await response.DeserializeAsync(responseParser);
        }

        private static IHttpRequest SetContentType(this IHttpRequest request, string contentType)
        {
            if (contentType != null)
            {
                request.ContentType = contentType;
            }

            return request;
        }

        private static async Task<IHttpRequest> SendContent(this IHttpRequest request, Action<Stream> contentWriter)
        {
            if (contentWriter != null)
            {
                using (var requestStream = await request.GetRequestStreamAsync())
                {
                    contentWriter(requestStream);
                }
            }

            return request;
        }

        private static async Task<IHttpRequest> SendContent(this IHttpRequest request, Func<Stream, Task> contentWriter)
        {
            if (contentWriter != null)
            {
                using (var requestStream = await request.GetRequestStreamAsync())
                {
                    await contentWriter(requestStream);
                }
            }

            return request;
        }
    }
}
