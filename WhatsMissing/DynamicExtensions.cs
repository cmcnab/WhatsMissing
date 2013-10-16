namespace WhatsMissing
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;

    public static class DynamicExtensions
    {
        public static dynamic Extend(this object value, object other)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            AddProperties(expando, value);
            if (other != null)
            {
                AddProperties(expando, other);
            }

            return expando as ExpandoObject;
        }

        private static void AddProperties(IDictionary<string, object> expando, object value)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
            {
                expando.Add(property.Name, property.GetValue(value));
            }
        }
    }
}
