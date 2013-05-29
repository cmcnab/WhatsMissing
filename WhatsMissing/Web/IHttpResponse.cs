namespace WhatsMissing.Web
{
    using System;
    using System.IO;
    using System.Net;

    public interface IHttpResponse
    {
        CookieCollection Cookies { get; set; }

        WebHeaderCollection Headers { get; }

        Uri ResponseUri { get; }

        HttpStatusCode StatusCode { get; }

        Stream GetResponseStream();
    }
}
