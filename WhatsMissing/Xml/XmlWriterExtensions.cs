namespace WhatsMissing.Xml
{
    using System;
    using System.Xml;

    public static class XmlWriterExtensions
    {
        public static XmlWriter WriteObject<T>(this XmlWriter writer, string name, T value, Action<XmlWriter, T> action)
        {
            writer.WriteStartElement(name);
            action(writer, value);
            writer.WriteEndElement();
            return writer;
        }
    }
}
