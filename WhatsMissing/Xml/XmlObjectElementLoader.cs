namespace WhatsMissing.Xml
{
    using System;
    using System.Xml;

    public class XmlObjectElementLoader<T> : IXmlObjectLoader<T> where T : new()
    {
        private readonly Action<XmlReader, T> elementAction;
        private T value;

        public XmlObjectElementLoader(Action<XmlReader, T> elementAction)
        {
            this.elementAction = elementAction;
        }

        public void Begin(XmlReader reader)
        {
            this.value = new T();
        }

        public void Attribute(XmlReader reader, string name)
        {
            // No action
        }

        public void Element(XmlReader reader, string name)
        {
            this.elementAction(reader, this.value);
        }

        public T End(XmlReader reader)
        {
            return this.value;
        }
    }
}
