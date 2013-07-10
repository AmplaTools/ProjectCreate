using System;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Models.EquipmentModel
{
    [TestFixture]
    public class ProjectUnitTests : TestFixture
    {
        private const string exampleResourcePath = "AmplaTools.ProjectCreate.Resources.Models.Equipment.Equipment.Example.xml";

        [Test]
        public void EmptyProject()
        {
            Project project = Project.Empty();
            Assert.That(project.Items, Is.Empty);
            Assert.That(project.GetCount(), Is.EqualTo(0));
        }

        [Test]
        public void Count()
        {
            Project project = new Project();
            Assert.That(project.GetCount(), Is.EqualTo(0));
            Equipment enterprise = project.Items.AddEquipment("Enterprise");
            Assert.That(project.GetCount(), Is.EqualTo(1));

            enterprise.Items.AddEquipment("Site A");
            Assert.That(project.GetCount(), Is.EqualTo(2));
        }

        [Test]
        public void CountMultiple()
        {
            Project project = new Project();
            project.Items.AddEquipment("Enterprise").Items.AddEquipment("Site A");
            Assert.That(project.GetCount(), Is.EqualTo(2));
        }


        [Test]
        public void LoadFromString()
        {
            string xml = AssemblyResources.GetTextFile(GetType().Assembly, exampleResourcePath);
            Assert.That(xml, Is.Not.Empty);

            string schema = AssemblyResources.GetSchema<Equipment>();

            XmlSchemaValidator<Project> validator = new XmlSchemaValidator<Project>(schema);
            Project projectResource = validator.Deserialize(xml);
            Assert.That(projectResource.GetCount(), Is.EqualTo(5));
            
            Project project = SerializationHelper.DeserializeFromString<Project>(xml);
            Assert.That(project, Is.Not.Null);
            Assert.That(project.Items, Is.Not.Empty);
            Assert.That(project.Items[0].Name, Is.EqualTo("Mining Company"));
            Assert.That(project.Items[0].Items, Is.Not.Empty);
            Assert.That(project.Items[0].Items[0].Name, Is.EqualTo("Remote Site"));
            Assert.That(project.Items[0].Items[0].Items, Is.Not.Empty);
            Assert.That(project.Items[0].Items[0].Items[0].Name, Is.EqualTo("Mining"));
            Assert.That(project.Items[0].Items[0].Items[1].Name, Is.EqualTo("Processing"));
            Assert.That(project.Items[0].Items[0].Items[1].Items, Is.Not.Empty);
            Assert.That(project.Items[0].Items[0].Items[1].Items[0].Name, Is.EqualTo("ROM"));
        }

        [Test]
        public void RoundTripFromString()
        {
            string xml = AssemblyResources.GetTextFile(GetType().Assembly, exampleResourcePath);
            Assert.That(xml, Is.Not.Empty);

            Project project = SerializationHelper.DeserializeFromString<Project>(xml);

            string roundTrip = SerializationHelper.SerializeToString(project);

            Assert.That(roundTrip, Is.EqualTo(xml));
        }

        [Test]
        public void RoundTripViaString()
        {
            Project project = new Project();
            project.Items.AddEquipment("Enterprise").Items.AddEquipment("Site").Items.AddEquipment("Area");

            Assert.That(project.GetCount(), Is.EqualTo(3));

            string xml = SerializationHelper.SerializeToString(project);
            Assert.That(xml, Is.StringContaining("Enterprise"));
            Assert.That(xml, Is.StringContaining("Site"));
            Assert.That(xml, Is.StringContaining("Area"));

            Project reloaded = SerializationHelper.DeserializeFromString<Project>(xml);
            Assert.That(reloaded.GetCount(), Is.EqualTo(3));
            Assert.That(reloaded.Items[0].Name, Is.EqualTo("Enterprise"));
            Assert.That(reloaded.Items[0].Items[0].Name, Is.EqualTo("Site"));
            Assert.That(reloaded.Items[0].Items[0].Items[0].Name, Is.EqualTo("Area"));

            string serialized = SerializationHelper.SerializeToString(reloaded);
            Assert.That(serialized, Is.EqualTo(xml));



        }

        [Test]
        public void Default()
        {
            Project project = new Project();
            Assert.That(project.Items, Is.Empty);
        }

        [Test]
        public void AddItemEnterprise()
        {
            Project project = Project.Empty();
            project.AddItem(new Equipment("My Enterprise"));

            Assert.That(project.Items, Is.Not.Empty);
            Assert.That(project.Items[0].Name, Is.EqualTo("My Enterprise"));

            Assert.DoesNotThrow(() => project.AddItem(new Equipment("Another Enterprise")));
        }

        [Test]
        public void AddItemNull()
        {
            Project project = Project.Empty();
            Assert.Throws<ArgumentNullException>(() => project.AddItem(null));
        }

        [Test]
        public void AddItemSite()
        {
            Project project = Project.Empty();
            Assert.DoesNotThrow(() => project.AddItem(new Equipment("Site")));
        }

        [Test]
        public void AddItemArea()
        {
            Project project = Project.Empty();
            Assert.DoesNotThrow(() => project.AddItem(new Equipment("Area 1")));
        }

        [Test]
        public void AddItemWorkCentre()
        {
            Project project = Project.Empty();
            Assert.DoesNotThrow(() => project.AddItem(new Equipment("WorkCentre")));
        }

        [Test]
        public void TestToString()
        {
            Project project = Project.Empty();
            Assert.That(project.ToString(), Is.EqualTo("Project (0 items)"));

            Equipment enterprise = project.Items.AddEquipment("Enterprise");
            Assert.That(project.ToString(), Is.EqualTo("Project (1 item)"));

            enterprise.Items.AddEquipment("Site 1");
            Assert.That(project.ToString(), Is.EqualTo("Project (2 items)"));
        }
    }
}