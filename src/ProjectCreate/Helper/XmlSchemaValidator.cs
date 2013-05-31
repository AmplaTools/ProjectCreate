using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AmplaTools.ProjectCreate.Helper
{
    public class XmlSchemaValidator<T>
    {
        public XmlSchemaValidator(string xmlSchema)
        {
            this.xmlSchema = xmlSchema;
        }

        public T Deserialize(string xml)
        {
            //List<XmlSchemaException> exceptions = new List<XmlSchemaException>();
            ValidationEventHandler validationHandler = (s, e) =>
            {
                //you could alternatively catch all the exceptions
                //exceptions.Add(e.Exception);
                throw e.Exception;
            };

            XmlReaderSettings settings = new XmlReaderSettings();
            XmlSchemaSet schemas = GetXmlSchema();
            settings.Schemas.Add(schemas);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += validationHandler;

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xml))
            using (XmlReader reader = XmlReader.Create(sr, settings))
                return (T)serializer.Deserialize(reader);
        }

        public string Serialize(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(stream, obj);
                stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        private readonly string xmlSchema;

        public XmlSchemaSet GetXmlSchema()
        {
            using (StringReader reader = new StringReader(xmlSchema))
            {
                using (XmlReader schemaReader = XmlReader.Create(reader))
                {
                    XmlSchemaSet schemaSet = new XmlSchemaSet();

                    //add the schema to the schema set
                    schemaSet.Add(XmlSchema.Read(schemaReader, delegate
                    {
                    }));

                    return schemaSet;
                }
            }
        }
    }
}