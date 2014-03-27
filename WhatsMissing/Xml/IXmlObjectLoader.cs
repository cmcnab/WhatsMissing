namespace WhatsMissing.Xml
{
    using System.Xml;

    public interface IXmlObjectLoader<T>
    {
        void Begin(XmlReader reader);

        void Attribute(XmlReader reader, string name);

        void Element(XmlReader reader, string name);

        T End(XmlReader reader);
    }
}
