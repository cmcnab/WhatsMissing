namespace WhatsMissing.Web
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Threading.Tasks;

    public interface IHttpRequest
    {
        string ContentType { get; set; }

        CookieContainer CookieContainer { get; set; }

        WebHeaderCollection Headers { get; set; }

        string Host { get; set; }

        string Method { get; set; }

        string Referer { get; set; }

        Uri RequestUri { get; }

        string UserAgent { get; set; }

        RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; set; }

        Stream GetRequestStream();

        Task<Stream> GetRequestStreamAsync();

        IHttpResponse GetResponse();

        Task<IHttpResponse> GetResponseAsync();
    }
}
