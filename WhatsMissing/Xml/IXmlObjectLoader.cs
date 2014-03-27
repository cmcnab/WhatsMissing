namespace WhatsMissing.Xml
{
    using System.Xml;

    public interface IXmlObjectLoader<T>
    {
        void Begin(XmlReader reader);

        void Attribute(XmlReader reader);

        void Element(XmlReader reader);

        T End(XmlReader reader);
    }
}
