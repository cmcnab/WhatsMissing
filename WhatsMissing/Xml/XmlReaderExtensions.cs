namespace WhatsMissing.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public static class XmlReaderExtensions
    {
        public static XmlReader MoveToNextElement(this XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    break;
                }
            }

            return reader;
        }

        public static string ReadElementTextOrDefault(this XmlReader reader)
        {
            if (reader.NodeType != XmlNodeType.Element || reader.IsEmptyElement)
            {
                return null;
            }

            var initName = reader.LocalName;
            string value = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.EndElement:
                        if (reader.LocalName == initName)
                        {
                            return value;
                        }

                        break;

                    case XmlNodeType.Text:
                        value = reader.Value;
                        break;
                }
            }

            return value;
        }

        public static string ReadElementText(this XmlReader reader)
        {
            return reader.ReadElementTextOrDefault() ?? string.Empty;
        }

        // TODO: ReadObjectList with the Action<XmlReader, T> elementLoader overload
        public static List<T> ReadObjectList<T>(this XmlReader reader, string itemElementName, Action<XmlReader, IDictionary<string, Action<T>>> defineElementHandlers) where T : new()
        {
            return reader.ReadObject(new XmlListElementLoader<T>(itemElementName, defineElementHandlers));
        }

        public static T ReadObject<T>(this XmlReader reader, Action<XmlReader, T> elementLoader) where T : new()
        {
            return reader.ReadObject(new XmlObjectElementLoader<T>(elementLoader));
        }

        public static T ReadObject<T>(this XmlReader reader, Action<XmlReader, IDictionary<string, Action<T>>> defineElementHandlers) where T : new()
        {
            var handlers = new Dictionary<string, Action<T>>();
            defineElementHandlers(reader, handlers);
            return reader.ReadObject<T>((r, v) =>
                {
                    var h = handlers.GetOrDefault(r.LocalName);
                    if (h != null)
                    {
                        h(v);
                    }
                });
        }

        public static T ReadObject<T>(this XmlReader reader, IXmlObjectLoader<T> loader)
        {
            var isEmpty = reader.IsEmptyElement;
            var initName = reader.LocalName;

            loader.Begin(reader);
            if (reader.MoveToFirstAttribute())
            {
                do
                {
                    loader.Attribute(reader);
                }
                while (reader.MoveToNextAttribute());
            }

            if (isEmpty)
            {
                return loader.End(reader);
            }

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.EndElement:
                        if (reader.LocalName == initName)
                        {
                            return loader.End(reader);
                        }

                        break;

                    case XmlNodeType.Element:
                        loader.Element(reader);
                        break;

                    default:
                        break;
                }
            }

            return loader.End(reader);
        }
    }
}
