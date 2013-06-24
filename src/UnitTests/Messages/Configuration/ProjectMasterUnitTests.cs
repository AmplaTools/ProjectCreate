using AmplaTools.ProjectCreate.Helper;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages.Configuration
{
    public class ProjectMasterUnitTests : TestFixture
    {
        private const string exampleResourcePath = "AmplaTools.ProjectCreate.Resources.Messages.ProjectMaster.Example.xml";


        [Test]
        public void DefaultHierarchy()
        {
            ProjectMaster master = ProjectMasterHelper.CreateDefaultProject();
            Assert.That(master, Is.Not.Null);
            Assert.That(master.Equipment, Is.Not.Null);
            Assert.That(master.Equipment.Hierarchy, Is.Not.Null);
            Assert.That(master.Equipment.Hierarchy.href, Is.Not.Null);
        }

        [Test]
        public void ContainsNamespace()
        {
            ProjectMaster master = ProjectMasterHelper.CreateDefaultProject();

            Assert.That(ProjectMaster.Namespace, Is.StringStarting("http://"));
            Assert.That(ProjectMaster.Namespace, Is.StringContaining("github"));

            string xml = SerializationHelper.SerializeToString(master);
            Assert.That(xml, Is.StringContaining(ProjectMaster.Namespace));
        }

        [Test]
        public void Roundtrip()
        {
            ProjectMaster master = ProjectMasterHelper.CreateDefaultProject();
            master.Equipment.Hierarchy.href = "Customer.Hierarchy.xml";

            string xml = SerializationHelper.SerializeToString(master);
            ProjectMaster result = SerializationHelper.DeserializeFromString<ProjectMaster>(xml);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Equipment, Is.Not.Null);
            Assert.That(result.Equipment.Hierarchy.href, Is.EqualTo(master.Equipment.Hierarchy.href));
        }

        [Test]
        public void RoundTripFromString()
        {
            string xml = AssemblyResources.GetTextFile(typeof(ProjectMasterUnitTests).Assembly, exampleResourcePath);
            ProjectMaster projectMaster = SerializationHelper.DeserializeFromString<ProjectMaster>(xml);

            string roundTrip = SerializationHelper.SerializeToString(projectMaster);

            Assert.That(roundTrip, Is.EqualTo(xml)); 
        }

        [Test]
        public void NewProject()
        {
            ProjectMaster master = ProjectMaster.NewProject();
            Assert.That(master, Is.Not.Null);
            Assert.That(master.Equipment, Is.Not.Null);
            Assert.That(master.Equipment.Hierarchy, Is.Not.Null);
            Assert.That(master.Equipment.Hierarchy.format, Is.EqualTo(ProjectFileFormat.Excel));
            Assert.That(master.Equipment.Hierarchy.href, Is.StringEnding(".xlsx"));
        }

    }
}
