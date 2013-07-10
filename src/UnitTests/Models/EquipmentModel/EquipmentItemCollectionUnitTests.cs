using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Models.EquipmentModel
{
    [TestFixture]
    public class EquipmentItemCollectionUnitTests : TestFixture
    {
        [Test]
        public void AddEquipmentItem()
        {
            Equipment site = new Equipment("Site");
            Equipment area = site.Items.AddEquipment("Area");

            Assert.That(area, Is.Not.Null);
            Assert.That(site.Items, Contains.Item(area));
            Assert.That(area.FullName, Is.EqualTo("Site.Area"));
        }
    }
}