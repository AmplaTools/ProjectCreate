
using AmplaTools.ProjectCreate.Framework;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class AreaUnitTests : TestFixture
    {
        [Test]
        public void Area()
        {
            Area area = new Area();
            Assert.That(area.name, Is.EqualTo("Area 1"));
            Assert.That(area.id, Is.Null);
            Assert.That(area.Area1, Is.Empty);
            Assert.That(area.WorkCentre, Is.Empty);
        }

        [Test]
        public void ItemCollection()
        {
            Area area = new Area();
            Assert.That(area.WorkCentre, Is.InstanceOf<ItemCollection<WorkCentre>>());
            Assert.That(area.Area1, Is.InstanceOf<ItemCollection<Area>>());
        }

        [Test]
        public void FullName()
        {
            Site site = new Site {name = "Site A"};
            Area area = new Area {name = "Area 1"};

            Assert.That(site.FullName, Is.EqualTo("Site A"));
            Assert.That(area.FullName, Is.EqualTo("Area 1"));
            site.Area.Add(area);
            Assert.That(site.FullName, Is.EqualTo("Site A"));
            Assert.That(area.FullName, Is.EqualTo("Site A.Area 1"));
        }


    }
}