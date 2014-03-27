namespace WhatsMissing.Xml
{
    using System;
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

        public static T ReadObject<T>(this XmlReader reader, Action<XmlReader, T> elementLoader) where T : new()
        {
            return reader.ReadObject(new XmlObjectElementLoader<T>(elementLoader));
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
                    loader.Attribute(reader, reader.LocalName);
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
                        loader.Element(reader, reader.LocalName);
                        break;

                    default:
                        break;
                }
            }

            return loader.End(reader);
        }
    }
}
