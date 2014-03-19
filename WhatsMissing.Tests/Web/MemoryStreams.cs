namespace WhatsMissing.Tests.Web
{
    using System.IO;

    public static class MemoryStreams
    {
        public static MemoryStream CreateWith(string value)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(value);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string ReadToEnd(this Stream stream)
        {
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
