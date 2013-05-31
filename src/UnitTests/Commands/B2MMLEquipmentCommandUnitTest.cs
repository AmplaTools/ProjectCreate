using System.Text;
using System.Xml;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Commands
{
    [TestFixture]
    public class B2MMLEquipmentCommandUnitTests : TestFixture
    {
        [Test]
        public void Execute()
        {
            Hierarchy hierarchy = HierarchyHelper.CreateDefaultHierarchy();
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(sb))
            {
                B2MMLEquipmentCommand command = new B2MMLEquipmentCommand(hierarchy, xmlWriter);
                command.Execute();    
            }
            string result = sb.ToString();

            Assert.That(result, Is.StringContaining(B2MML.V500Namespace));
            Assert.That(result, Is.Not.StringContaining(B2MML.V400Namespace ));
        }

    }
}