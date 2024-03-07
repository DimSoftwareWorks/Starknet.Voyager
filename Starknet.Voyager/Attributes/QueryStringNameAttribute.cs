using System;

namespace Starknet.Voyager.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class QueryStringNameAttribute : Attribute
    {
        public string Name { get; }

        public QueryStringNameAttribute(string name)
        {
            Name = name;
        }
    }
}
