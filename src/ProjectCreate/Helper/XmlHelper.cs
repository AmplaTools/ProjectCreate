using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace AmplaTools.ProjectCreate.Helper
{
    public static class XmlHelper
    {
        private static readonly Dictionary<string, XslCompiledTransform> CachedTransforms =
            new Dictionary<string, XslCompiledTransform>();

        /// <summary>
        ///     Serialise the object to XmlDocument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static XmlDocument SerializeToXmlDocument<T>(T obj)
        {
            string xml = SerializationHelper.SerializeToString(obj);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            return xmlDoc;
        }

        /// <summary>
        ///     Gets the compliled transform for the xslt file
        /// </summary>
        /// <param name="xslt"></param>
        /// <returns></returns>
        public static XslCompiledTransform GetCompiledTransform(string xslt)
        {
            XslCompiledTransform transform;
            if (!CachedTransforms.TryGetValue(xslt, out transform))
            {
                var temp = new XslCompiledTransform();

                var reader = new StringReader(xslt);
                XmlReader xmlReader = new XmlTextReader(reader);
                temp.Load(xmlReader);

                CachedTransforms[xslt] = temp;
                transform = temp;
            }

            return transform;
        }


    }
}