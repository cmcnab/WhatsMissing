namespace WhatsMissing.Web
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Threading.Tasks;

    internal class HttpRequest : IHttpRequest
    {
        private readonly HttpWebRequest request;

        public HttpRequest(HttpWebRequest request)
        {
            this.request = request;
        }

        public string ContentType
        {
            get { return this.request.ContentType; }
            set { this.request.ContentType = value; }
        }

        public CookieContainer CookieContainer
        {
            get { return this.request.CookieContainer; }
            set { this.request.CookieContainer = value; }
        }

        public WebHeaderCollection Headers
        {
            get { return this.request.Headers; }
            set { this.request.Headers = value; }
        }

        public string Host
        {
            get { return this.request.Host; }
            set { this.request.Host = value; }
        }

        public string Method
        {
            get { return this.request.Method; }
            set { this.request.Method = value; }
        }

        public string Referer
        {
            get { return this.request.Referer; }
            set { this.request.Referer = value; }
        }

        public Uri RequestUri
        {
            get { return this.request.RequestUri; }
        }

        public string UserAgent
        {
            get { return this.request.UserAgent; }
            set { this.request.UserAgent = value; }
        }

        public RemoteCertificateValidationCallback ServerCertificateValidationCallback
        {
            get { return this.request.ServerCertificateValidationCallback; }
            set { this.request.ServerCertificateValidationCallback = value; }
        }

        public Stream GetRequestStream()
        {
            return this.request.GetRequestStream();
        }

        public Task<Stream> GetRequestStreamAsync()
        {
            return this.request.GetRequestStreamAsync();
        }

        public IHttpResponse GetResponse()
        {
            var response = (HttpWebResponse)this.request.GetResponse();
            return new HttpResponse(response);
        }

        public async Task<IHttpResponse> GetResponseAsync()
        {
            var response = (HttpWebResponse)await this.request.GetResponseAsync();
            return new HttpResponse(response);
        }
    }
}
