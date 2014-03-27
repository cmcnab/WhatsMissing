namespace WhatsMissing.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public static class XmlWriterExtensions
    {
        public static XmlWriter WriteElementText(this XmlWriter writer, string name, string value)
        {
            writer.WriteElementString(name, value);
            return writer;
        }

        public static XmlWriter WriteObject<T>(this XmlWriter writer, string name, T value, Action<XmlWriter, T> action)
        {
            writer.WriteStartElement(name);
            action(writer, value);
            writer.WriteEndElement();
            return writer;
        }

        public static XmlWriter WriteObjectList<T>(this XmlWriter writer, string name, string itemElementName, IEnumerable<T> items, Action<XmlWriter, T> itemWriter)
        {
            writer.WriteStartElement(name);
            foreach (var item in items)
            {
                writer.WriteObject(itemElementName, item, itemWriter);
            }

            writer.WriteEndElement();
            return writer;
        }
    }
}
