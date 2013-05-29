namespace WhatsMissing.Web
{
    using System;
    using System.IO;
    using System.Net;

    internal class HttpResponse : IHttpResponse
    {
        private readonly HttpWebResponse response;

        public HttpResponse(HttpWebResponse response)
        {
            this.response = response;
        }

        public CookieCollection Cookies
        {
            get { return this.response.Cookies; }
            set { this.response.Cookies = value; }
        }

        public WebHeaderCollection Headers
        {
            get { return this.response.Headers; }
        }

        public Uri ResponseUri
        {
            get { return this.response.ResponseUri; }
        }

        public HttpStatusCode StatusCode
        {
            get { return this.response.StatusCode; }
        }

        public Stream GetResponseStream()
        {
            return this.response.GetResponseStream();
        }
    }
}
