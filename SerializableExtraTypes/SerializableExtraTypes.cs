using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Net.AMightyOak
{
    public sealed class SerializableExtraTypes
    {
        #region Class Parts

        #region Constructor

        private SerializableExtraTypes()
            : base()
        {
            lock (Assemblies)
            {
                // Get Currently Loaded Assemblies
                foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                    if (!Assemblies.Keys.Contains(a.FullName)) Assemblies.Add(a.FullName, a);

                // Get Web Bin directory Assemblies
                if (System.Web.HttpContext.Current != null)
                    foreach (var a in new HttpAssemblyLocator().GetBinFolderAssemblies())
                        if (!Assemblies.Keys.Contains(a.FullName)) Assemblies.Add(a.FullName, a);
            }

            foreach (var i in GetAssemblyExtraTypes(Assemblies.Values.ToArray()))
                _RegisterType(i.Item1, i.Item2);

            // Setup Assembly Load for new assemblies
            AppDomain.CurrentDomain.AssemblyLoad +=
                new AssemblyLoadEventHandler(delegate(object sender, AssemblyLoadEventArgs args)
                {
                    lock (Assemblies)
                    {
                        if (!Assemblies.Keys.Contains(args.LoadedAssembly.FullName))
                            Assemblies.Add(args.LoadedAssembly.FullName, args.LoadedAssembly);
                    }

                    foreach (var i in GetAssemblyExtraTypes(args.LoadedAssembly))
                        SerializableExtraTypes.RegisterType(i.Item1, i.Item2);
                });
        }

        private void _RegisterType(Type root, params Type[] related)
        {
            //+ Validate types.
            if (root.IsInterface || related.Count(a => a.IsInterface) > 0)
                throw new NotSupportedException("Interfaces can not be serialized");
            // Add missing associations

            lock (Associations)
            {
                // root types
                IEnumerable<Type> r = new List<Type>(related);

                // related children
                foreach (Type t in related)
                {
                    r = r.Union(from z in t.GetTypes(
                                    (c, d) => d.IsSubclassOf(c)
                                        && !d.IsAbstract
                                        && !d.IsGenericTypeDefinition
                                    , Assemblies.Values.ToArray())
                                select z);
                }

                var x = from i in r.Distinct()
                        join j in Associations.Where(a => a.Key.Item1 == root.FullName)
                        on i.FullName equals j.Key.Item2 into outer
                        from k in outer.DefaultIfEmpty()
                        where k.Key == null
                        select new
                        {
                            k = new Tuple<string, string>(root.FullName, i.FullName),
                            v = i
                        };

                foreach (var i in x)
                    Associations.Add(i.k, i.v);
            }
        }

        // Parent, Child
        private static IEnumerable<Tuple<Type, Type>> GetAssemblyExtraTypes(params Assembly[] asmblys)
        {
            foreach (Assembly a in asmblys)
                foreach (Type t in a.GetTypes())
                    foreach (SerializableExtraTypeAttribute u in
                        t.GetCustomAttributes(typeof(SerializableExtraTypeAttribute), true).Cast<SerializableExtraTypeAttribute>())
                        foreach (Type v in u.Types)
                            yield return new Tuple<Type, Type>(t, v);
        }

        #endregion Constructor

        #region Properties

        // Tuple<string, string> ~ Key<Parent,Child>, Type to include
        private Dictionary<Tuple<string, string>, Type> Associations = new Dictionary<Tuple<string, string>, Type>();
        private Dictionary<string, Assembly> Assemblies = new Dictionary<string, Assembly>();
        private static SerializableExtraTypes Context = new SerializableExtraTypes();

        #endregion Properties

        #endregion Class Parts

        #region Public Methods

        public static IEnumerable<Type> GetTypes(Type type)
        {
            string root = type.FullName;
            List<string> roots = new List<string> { root, };

            List<Tuple<string, string>> results =
                new List<Tuple<string, string>>(from i in Context.Associations
                                                where i.Key.Item1 == root
                                                select i.Key);

            if (results.Count() == 0)
                results = new List<Tuple<string, string>>(from i in Context.Associations
                                                          where i.Key.Item2 == root
                                                          select i.Key);

            while (results.Count <= Context.Associations.Count)
            {
                //+ this should only iterate the number of hierarchies deep and no more
                var x = from i in results
                        join j in Context.Associations.Where(a => !roots.Contains(a.Key.Item1))
                            on i.Item2 equals j.Key.Item1 into outer
                        from k in outer.DefaultIfEmpty()
                        where k.Key != null
                        select k.Key;
                if (x.Count() == 0) break;
                results = results.Union(x).ToList();
                //+ prevent recursive loop
                roots.AddRange(x.Select(a => a.Item1).Distinct());
            }

            return from i in Context.Associations
                   join j in results.Distinct()
                   on i.Key equals j
                   select i.Value;
        }

        public static void RegisterType(Type root, params Type[] related)
        {
            Context._RegisterType(root, related);
        }

        #endregion Public Methods
    }
}