namespace WhatsMissing.Web
{
    using System;
    using System.Net;

    internal class WebRequester : IWebRequester
    {
        public IHttpRequest Create(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            return new HttpRequest(request);
        }
    }
}
