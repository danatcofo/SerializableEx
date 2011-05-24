using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Compilation;

namespace Net.AMightyOak
{
    internal class HttpAssemblyLocator
    {
        private IEnumerable<Assembly> AllAssemblies = null;
        private IEnumerable<Assembly> BinFolderAssemblies = null;

        internal HttpAssemblyLocator()
        {
            AllAssemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            List<Assembly> binFolderAssemblies = new List<Assembly>();

            string binFolder = HttpRuntime.AppDomainAppPath + "bin\\";
            IList<string> dllFiles = Directory.GetFiles(binFolder, "*.dll",
                SearchOption.TopDirectoryOnly).ToList();

            foreach (string dllFile in dllFiles)
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(dllFile);

                Assembly locatedAssembly = AllAssemblies.FirstOrDefault(a =>
                    AssemblyName.ReferenceMatchesDefinition(a.GetName(), assemblyName));

                if (locatedAssembly != null)
                {
                    binFolderAssemblies.Add(locatedAssembly);
                }
            }

            BinFolderAssemblies = binFolderAssemblies;
        }

        internal IEnumerable<Assembly> GetAssemblies()
        {
            return AllAssemblies;
        }

        internal IEnumerable<Assembly> GetBinFolderAssemblies()
        {
            return BinFolderAssemblies;
        }
    }
}