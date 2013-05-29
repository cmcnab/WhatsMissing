namespace WhatsMissing.Web
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    public interface IHttpRequest
    {
        string ContentType { get; set; }

        CookieContainer CookieContainer { get; set; }

        string Host { get; set; }

        string Method { get; set; }

        string Referer { get; set; }

        Uri RequestUri { get; }

        string UserAgent { get; set; }

        Stream GetRequestStream();

        Task<IHttpResponse> GetResponseAsync();
    }
}
