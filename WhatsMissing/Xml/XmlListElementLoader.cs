namespace WhatsMissing.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class XmlListElementLoader<T> : IXmlObjectLoader<List<T>> where T : new()
    {
        private readonly Action<XmlReader, IDictionary<string, Action<T>>> defineElementHandlers;
        private readonly string itemElementName;
        private List<T> list;

        public XmlListElementLoader(string itemElementName, Action<XmlReader, IDictionary<string, Action<T>>> defineElementHandlers)
        {
            this.itemElementName = itemElementName;
            this.defineElementHandlers = defineElementHandlers;
        }

        public void Begin(XmlReader reader)
        {
            this.list = new List<T>();
        }

        public void Attribute(XmlReader reader)
        {
            // No action
        }

        public void Element(XmlReader reader)
        {
            if (reader.LocalName == this.itemElementName)
            {
                this.list.Add(reader.ReadObject<T>(this.defineElementHandlers));
            }
        }

        public List<T> End(XmlReader reader)
        {
            return this.list;
        }
    }
}
