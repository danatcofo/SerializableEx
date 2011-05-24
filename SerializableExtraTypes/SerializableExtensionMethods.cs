using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Net.AMightyOak;

namespace System
{
    public static class SerializableExtensionMethods
    {
        /// <summary>
        /// Serialize the object.
        /// </summary>
        /// <typeparam name="T">the Root type used for serialization</typeparam>
        public static string SerializeEx<T>(this T obj)
        {
            Type[] t = SerializableExtraTypes.GetTypes(typeof(T)).ToArray();
            var x = new XmlSerializer(typeof(T), t);
            StringWriter sw = new StringWriter();
            x.Serialize(sw, obj);
            return sw.ToString();
        }

        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <param name="root">the Root type used for serialization</param>
        /// <returns></returns>
        public static string SerializeEx<T>(this T obj, params Type[] root)
        {
            Type[] t = (from y in root
                        select SerializableExtraTypes.GetTypes(y))
                        .Flatten()
                        .Union(SerializableExtraTypes.GetTypes(typeof(T)))
                        .Distinct()
                        .ToArray();
            var x = new XmlSerializer(typeof(T), t);
            StringWriter sw = new StringWriter();
            x.Serialize(sw, obj);
            return sw.ToString();
        }

        /// <summary>
        /// Deserialize the object to the given type.
        /// </summary>
        public static T DeserializeEx<T>(this string xml)
        {
            Type[] t = SerializableExtraTypes.GetTypes(typeof(T)).ToArray();
            var x = new XmlSerializer(typeof(T), t);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var r = XmlReader.Create(new StringReader(xml));
            if (!x.CanDeserialize(r))
                throw new FormatException(string.Format("Unable to deserialize string into {0}, root node does not match.", typeof(T).FullName));
            return (T)x.Deserialize(r);
        }

        /// <summary>
        /// Deserialize the object to the given type.
        /// </summary>
        /// <param name="root">the root type used for deserialization</param>
        public static T DeserializeEx<T>(this string xml, params Type[] root)
        {
            Type[] t = (from y in root
                        select SerializableExtraTypes.GetTypes(y))
                        .Flatten()
                        .Union(SerializableExtraTypes.GetTypes(typeof(T)))
                        .Distinct()
                        .ToArray();
            var x = new XmlSerializer(typeof(T), t);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var r = XmlReader.Create(new StringReader(xml));
            if (!x.CanDeserialize(r))
                throw new FormatException(string.Format("Unable to deserialize string into {0}, root node does not match.", typeof(T).FullName));
            return (T)x.Deserialize(r);
        }

        /// <summary>
        /// Returns all types that match the func comparison.
        /// </summary>
        /// <typeparam name="T">they Type that is compared to</typeparam>
        /// <param name="func">comparison method</param>
        /// <param name="asmblys">assemblies to search</param>
        /// <returns>matching types</returns>
        internal static IEnumerable<Type> GetTypes<T>(this T obj, Func<T, Type, bool> func, params Assembly[] asmblys)
        {
            foreach (Assembly a in asmblys)
                foreach (Type t in a.GetTypes())
                    if (func(obj, t))
                        yield return t;
        }

        internal static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> obj)
        {
            foreach (var v in obj)
                foreach (var w in v)
                    yield return w;
        }
    }
}