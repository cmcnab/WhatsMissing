namespace WhatsMissing.Web
{
    using System;
    using System.Net;

    internal class WebRequester : IWebRequester
    {
        public IHttpRequest Create(Uri uri)
        {
            return new HttpRequest(HttpWebRequest.CreateHttp(uri));
        }
    }
}
