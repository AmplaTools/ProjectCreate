using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Xsl;

namespace AmplaTools.ProjectCreate.Helper
{
    public static class AssemblyResources
    {
        public static string GetTextFile(Assembly assembly, string resourcePath)
        {
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    string[] resources = assembly.GetManifestResourceNames();
                    string message = string.Format("{0} is not one of the following:\r\n - {1}", resourcePath, string.Join("\r\n - ", resources));
                    throw new ArgumentException(message);
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string GetTextFile(string resourcePath)
        {
            return GetTextFile(Assembly.GetCallingAssembly(), resourcePath);
        }

        public static string[] GetSchemaNames()
        {
            return GetSchemaNames(Assembly.GetCallingAssembly());
        }

        public static string[] GetSchemaNames(Assembly assembly)
        {
            string[] resources = assembly.GetManifestResourceNames();
            return resources.Where(resource => resource.EndsWith(".xsd")).ToArray();
        }

        public static string GetSchema<T>()
        {
            Assembly assembly = typeof(T).Assembly;
            string schemaResource = typeof(T).FullName + ".xsd";
            return GetTextFile(assembly, schemaResource);
        }

        public static T GetResource<T>(string resourcePath)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            string schema = GetSchema<T>();
            XmlSchemaValidator<T> validator = new XmlSchemaValidator<T>(schema);
            string resouceXml = GetTextFile(assembly, resourcePath);
            return validator.Deserialize(resouceXml);
        }

        public static XslCompiledTransform GetXsltStylesheet(string resourcePath)
        {
            string xslt = GetTextFile(resourcePath);
            return XmlHelper.GetCompiledTransform(xslt);
        }
    }
}