
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Framework
{
    [TestFixture]
    public class ItemCollectionUnitTests : TestFixture
    {
        [Test]
        public void FullNameCorrectWhenAdded()
        {
            Enterprise enterprise = new Enterprise {name = "Company"};
            ItemCollection<Area> areas = new ItemCollection<Area>(enterprise);

            Area area1 = new Area {name = "Area 1"};

            Assert.That(area1.FullName, Is.EqualTo("Area 1"));

            areas.Add(area1);

            Assert.That(areas.Count, Is.EqualTo(1));
            Assert.That(area1.FullName, Is.EqualTo("Company.Area 1"));

            areas.Remove(area1);
            Assert.That(areas.Count, Is.EqualTo(0));
            Assert.That(area1.FullName, Is.EqualTo("Area 1"));
        }

        [Test]
        public void FullNameCorrectWhenSet()
        {
            Enterprise enterprise = new Enterprise { name = "Company" };
            ItemCollection<Area> areas = new ItemCollection<Area>(enterprise);

            Area area1 = new Area { name = "Area 1" };
            Area area2 = new Area { name = "Area 2" };

            Assert.That(area1.FullName, Is.EqualTo("Area 1"));

            areas.Add(area1);

            Assert.That(areas.Count, Is.EqualTo(1));
            Assert.That(area1.FullName, Is.EqualTo("Company.Area 1"));

            areas[0] = area2;

            Assert.That(areas.Count, Is.EqualTo(1));
            Assert.That(area1.FullName, Is.EqualTo("Area 1"));
            Assert.That(area2.FullName, Is.EqualTo("Company.Area 2"));
        }

        [Test]
        public void FullNameCorrectWhenClear()
        {
            Enterprise enterprise = new Enterprise { name = "Company" };
            ItemCollection<Area> areas = new ItemCollection<Area>(enterprise);

            Area area1 = new Area { name = "Area 1" };

            Assert.That(area1.FullName, Is.EqualTo("Area 1"));

            areas.Add(area1);

            Assert.That(areas.Count, Is.EqualTo(1));
            Assert.That(area1.FullName, Is.EqualTo("Company.Area 1"));

            areas.Clear();

            Assert.That(areas.Count, Is.EqualTo(0));
            Assert.That(area1.FullName, Is.EqualTo("Area 1"));
        }

    }
}