using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Xml.Serialization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class SerializableExtraTypeAttribute : Attribute
    {
        public SerializableExtraTypeAttribute(params Type[] types)
            : base() { _Types = types.Where(t => t != null).ToArray(); }

        private IEnumerable<Type> _Types = null;

        public IEnumerable<Type> Types
        {
            get { return _Types; }
        }
    }
}