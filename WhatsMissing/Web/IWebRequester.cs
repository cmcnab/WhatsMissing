namespace WhatsMissing.Web
{
    using System;

    public interface IWebRequester
    {
        IHttpRequest Create(Uri uri);
    }
}
