using System;
using System.Collections.Generic;
using System.Xml;

namespace AmplaTools.ProjectCreate.Helper
{
    public class Serializer
    {
        public Serializer(Type type)
        {
            serializer = new System.Xml.Serialization.XmlSerializer(type);
        }

        private readonly System.Xml.Serialization.XmlSerializer serializer;

        /// <summary>
        /// Serializes current ProjectCreate object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public string Serialize<T>(T obj)
        {
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                serializer.Serialize(stream, obj);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        /// <summary>
        ///     Deserialize from a string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public T Deserialize<T>(string xml)
        {
            using (System.IO.StringReader stringReader = new System.IO.StringReader(xml))
            {
                using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader))
                {
                    return (T) serializer.Deserialize(xmlReader);
                }
            }
        }
    }

    public static class SerializationHelper
    {
        private static Dictionary<Type, Serializer> serializers = new Dictionary<Type, Serializer>();

        /// <summary>
        ///     Serialise the object to a string using XmlSerialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToString<T>(T obj)
        {
            Serializer serializer = GetSerializer<T>();
            return serializer.Serialize(obj);
        }


        /// <summary>
        ///     Gets a Serializer for the type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static Serializer GetSerializer<T>()
        {
            Serializer serializer;
            if (!serializers.TryGetValue(typeof(T), out serializer))
            {
                serializer = new Serializer(typeof(T));
                serializers[typeof(T)] = serializer;
            }
            return serializer;
        }

        /// <summary>
        ///     Serialise the object to a string using XmlSerialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeFromString<T>(string xml)
        {
            Serializer serializer = GetSerializer<T>();
            return serializer.Deserialize<T>(xml);
        }

        public static bool TryDeserializeFromString<T>(string xml, out T obj, out Exception exception)
        {
            bool result = false;
            obj = default(T);
            exception = null;
            try
            {
                Serializer serializer = GetSerializer<T>();
                obj = serializer.Deserialize<T>(xml);
                result = true;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return result;
        }

        public static bool TrySerializeToString<T>(T obj, out string xml, out Exception exception)
        {
            bool result = false;
            xml = null;
            exception = null;
            try
            {
                Serializer serializer = GetSerializer<T>();
                xml = serializer.Serialize(obj);
                result = true;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return result;
        }

        public static void SaveToFile<T>(string filename, T obj)
        {
            Serializer serializer = GetSerializer<T>();
            string xml = serializer.Serialize(obj);

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
            using (System.IO.StreamWriter writer = fileInfo.CreateText())
            {
                writer.WriteLine(xml);
                writer.Flush();
            }
        }
    }
}
