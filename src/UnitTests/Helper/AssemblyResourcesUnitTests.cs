using System;
using System.Reflection;
using AmplaTools.ProjectCreate.Messages;
using AmplaTools.ProjectCreate.Schema;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Helper
{
    public class AssemblyResourcesUnitTest : TestFixture
    {
        [Test]
        public void GetResource()
        {
            string xsd = AssemblyResources.GetTextFile("AmplaTools.ProjectCreate.Schema.TestProject.xsd");
            Assert.That(xsd, Is.Not.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidPath()
        {
            AssemblyResources.GetTextFile("Invalid.Path");
        }

        [Test]
        public void GetEmbeddedSchemas()
        {
            string[] schemas = AssemblyResources.GetSchemaNames(Assembly.GetExecutingAssembly());
            Assert.That(schemas.Length, Is.EqualTo(1));
            Assert.That(schemas[0], Is.EqualTo("AmplaTools.ProjectCreate.Schema.TestProject.xsd"));
        }

        [Test]
        public void GetProjectMasterSchema()
        {
            string schema = AssemblyResources.GetSchema<ProjectMaster>();
            Assert.That(schema, Is.Not.Empty);
        }

        [Test]
        public void GetTestProject()
        {
            TestProject project = AssemblyResources.GetResource<TestProject>("AmplaTools.ProjectCreate.Schema.TestProject.xml");
            Assert.That(project, Is.Not.Null);
            Assert.That(project.Hierarchy, Is.Not.Null);
            Assert.That(project.Hierarchy.href, Is.EqualTo("Test.Hierarchy.xml"));
        }
    }
}