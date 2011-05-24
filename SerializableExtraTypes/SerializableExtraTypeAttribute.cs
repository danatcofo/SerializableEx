using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Xml.Serialization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class SerializableExtraTypeAttribute : Attribute
    {
        public SerializableExtraTypeAttribute(Type t) 
            : base() { _Types = new Type[] { t }; }
        public SerializableExtraTypeAttribute(Type t1, Type t2) 
            : base() { _Types = new Type[] { t1, t2 }; }
        public SerializableExtraTypeAttribute(Type t1, Type t2, Type t3) 
            : base() { _Types = new Type[] { t1, t2, t3, }; }
        public SerializableExtraTypeAttribute(Type t1, Type t2, Type t3, Type t4) 
            : base() { _Types = new Type[] { t1, t2, t3, t4, }; }
        public SerializableExtraTypeAttribute(Type t1, Type t2, Type t3, Type t4, Type t5) 
            : base() { _Types = new Type[] { t1, t2, t3, t4, t5, }; }
        public SerializableExtraTypeAttribute(Type t1, Type t2, Type t3, Type t4, Type t5, Type t6) 
            : base() { _Types = new Type[] { t1, t2, t3, t4, t5, t6, }; }

        private IEnumerable<Type> _Types = null;

        public IEnumerable<Type> Types
        {
            get { return _Types; }
        }
    }
}