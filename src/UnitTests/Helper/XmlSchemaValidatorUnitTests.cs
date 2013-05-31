using System;
using AmplaTools.ProjectCreate.Schema;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Helper
{
    public class XmlSchemaValidatorUnitTest : TestFixture
    {
        private const string xsdResourcePath = "AmplaTools.ProjectCreate.Schema.TestProject.xsd";
        private const string testProjectResourcePath = "AmplaTools.ProjectCreate.Schema.TestProject.xml";

        [Test]
        public void XmlSchema()
        {
            string testSchema = AssemblyResources.GetTextFile(xsdResourcePath);
            XmlSchemaValidator<TestProject> validator = new XmlSchemaValidator<TestProject>(testSchema);
            validator.GetXmlSchema();

            Assert.That(validator, Is.Not.Null);
        }

        [Test]
        public void ValidXml()
        {
            string testSchema = AssemblyResources.GetTextFile(xsdResourcePath);
            string xml = AssemblyResources.GetTextFile(testProjectResourcePath);
            XmlSchemaValidator<TestProject> validator = new XmlSchemaValidator<TestProject>(testSchema);
            TestProject record = validator.Deserialize(xml);

            Assert.That(record, Is.Not.Null);
            Assert.That(record.Hierarchy, Is.Not.Null);
            Assert.That(record.Hierarchy.href, Is.Not.Null);
        }

        [Test]
        public void InvalidXml()
        {
            string testSchema = AssemblyResources.GetTextFile(xsdResourcePath);
            string xml = AssemblyResources.GetTextFile(testProjectResourcePath);
            Assert.That(xml, Is.StringContaining("<Hierarchy"));
            string invalidXml = xml.Replace("<Hierarchy", "<InvalidHierarchy");
            Assert.That(invalidXml, Is.StringContaining("<InvalidHierarchy"));
            XmlSchemaValidator<TestProject> validator = new XmlSchemaValidator<TestProject>(testSchema);
            Assert.That(() => { validator.Deserialize(invalidXml); }, Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void WrongElements()
        {
            string testSchema = AssemblyResources.GetTextFile(xsdResourcePath);
            string xml = AssemblyResources.GetTextFile(testProjectResourcePath);

            string replaced = xml.Replace("TestProject", "ProjectMaster");
            XmlSchemaValidator<TestProject> validator = new XmlSchemaValidator<TestProject>(testSchema);
            Assert.That(() => { validator.Deserialize(replaced); }, Throws.TypeOf<InvalidOperationException>());
        }

    }
}