using System;
using System.Reflection;

namespace WordCounter
{
    public static class ApplicationInfo
    {
        public static string Title
        {
            get
            {
                var assembly = Assembly.GetCallingAssembly();
                return $"{GetProduct(assembly)} v{GetVersion(assembly)}";
            }
        }

        private static string GetProduct(Assembly assembly) =>
            assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;

        private static string GetVersion(Assembly assembly)
        {
            Version version = assembly.GetName().Version;
            return $"{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}
