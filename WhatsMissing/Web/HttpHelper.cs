/*namespace WhatsMissing.Web
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net;
    using System.Web;

    public static class HttpHelper
    {
        public static NameValueCollection ParseQuery(this Uri uri)
        {
            return HttpUtility.ParseQueryString(uri.Query);
        }

        public static Uri AddQuery(this Uri uri, params string[] keyValuePairs)
        {
            NameValueCollection args = !string.IsNullOrEmpty(uri.Query)
                ? HttpUtility.ParseQueryString(uri.Query)
                : CreateQuery();

            AddParams(args, keyValuePairs);
            return new Uri(uri.AbsoluteUri + "?" + CreateQuery(keyValuePairs).ToString());
        }

        public static NameValueCollection CreateQuery()
        {
            return HttpUtility.ParseQueryString(string.Empty);
        }

        public static NameValueCollection CreateQuery(params string[] keyValuePairs)
        {
            return AddParams(CreateQuery(), keyValuePairs);
        }

        public static WebHeaderCollection CreateHeaders(params string[] keyValuePairs)
        {
            return AddParams(new WebHeaderCollection(), keyValuePairs);
        }

        public static CookieCollection CreateCookies(string domain, params string[] keyValuePairs)
        {
            var collection = new CookieCollection();
            foreach (var pair in ParamsToPairs(keyValuePairs))
            {
                collection.Add(new Cookie(pair.Item1, pair.Item2, "/", domain));
            }

            return collection;
        }

        private static T AddParams<T>(T collection, params string[] keyValuePairs) where T : NameValueCollection
        {
            foreach (var pair in ParamsToPairs(keyValuePairs))
            {
                collection[pair.Item1] = pair.Item2;
            }

            return collection;
        }

        private static IEnumerable<Tuple<string, string>> ParamsToPairs(params string[] keyValuePairs)
        {
            if (keyValuePairs.Length % 2 != 0)
            {
                throw new ArgumentException("You must specify an even number of arguments", "keyValuePairs");
            }

            for (int i = 0; i + 1 < keyValuePairs.Length; i += 2)
            {
                yield return Tuple.Create(keyValuePairs[i], keyValuePairs[i + 1]);
            }
        }
    }
}
*/