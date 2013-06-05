using System;
using AmplaTools.ProjectCreate.Messages.Configuration;
using NUnit.Framework;


namespace AmplaTools.ProjectCreate.Helper
{
    public class SerializationHelperUnitTests : TestFixture
    {

        [Test]
        public void RoundTrip()
        {
            ProjectMaster master = new ProjectMaster
                {
                    Equipment = new EquipmentDefinition {Hierarchy = {href = "Hierarchy.xml"}}
                };

            string xml = SerializationHelper.SerializeToString(master);
            Assert.That(xml, Is.StringContaining("Hierarchy.xml"));

            ProjectMaster result = SerializationHelper.DeserializeFromString<ProjectMaster>(xml);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Equipment, Is.Not.Null);
            Assert.That(result.Equipment.Hierarchy, Is.Not.Null);
            Assert.That(result.Equipment.Hierarchy.href, Is.EqualTo("Hierarchy.xml"));
        }

        [Test]
        public void WrongType()
        {
            ProjectMaster master = ProjectMasterHelper.CreateDefaultProject();

            string xml = SerializationHelper.SerializeToString(master);
            Assert.That(xml, Is.StringContaining("Hierarchy.xml"));

            Assert.Throws<InvalidOperationException>(() => SerializationHelper.DeserializeFromString<ProjectHierarchy>(xml));
        }

    }
}
