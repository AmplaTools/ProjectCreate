
using System.Text;
using System.Xml;
using AmplaTools.ProjectCreate.Commands.MasterData;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Commands.Equipment
{
    [TestFixture]
    public class EquipmentHierarchyCommandUnitTests : TestFixture
    {
        [Test]
        public void Execution()
        {
            Hierarchy hierarchy = HierarchyHelper.CreateDefaultHierarchy();
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(sb))
            {
                EquipmentHierarchyCommand command = new EquipmentHierarchyCommand(hierarchy, xmlWriter);
                command.Execute();    
            }
            string result = sb.ToString();

            Assert.That(result, Is.Not.StringContaining(B2MML.V500Namespace));
            Assert.That(result, Is.StringContaining(B2MML.V400Namespace ));

            Assert.That(result, Is.StringContaining("Site A"));
        }
    }
}