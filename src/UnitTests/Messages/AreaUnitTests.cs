
using System;
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

        [Test]
        public void AddItemEnterprise()
        {
            Area area = new Area("Area 1");
            Assert.Throws<ArgumentException>(() => area.AddItem(new Enterprise("My Enterprise")));
        }

        [Test]
        public void AddItemNull()
        {
            Area area = new Area("Area 1");
            Assert.Throws<ArgumentNullException>(() => area.AddItem(null));
        }

        [Test]
        public void AddItemSite()
        {
            Area area = new Area("Area 1");
            Assert.Throws<ArgumentException>(() => area.AddItem(new Site("Site 2")));
        }

        [Test]
        public void AddItemArea()
        {
            Area area = new Area("Area 1");
            area.AddItem(new Area("Area 1a"));

            Assert.That(area.Area1.Count, Is.EqualTo(1));
            Assert.That(area.Area1[0].Name, Is.EqualTo("Area 1a"));

            area.AddItem(new Area("Area 1b"));

            Assert.That(area.Area1.Count, Is.EqualTo(2));
            Assert.That(area.Area1[1].Name, Is.EqualTo("Area 1b"));
        }

        [Test]
        public void AddItemBothAreaAndWorkCentre()
        {
            Area area = new Area("Area 1");

            Assert.That(area.GetCount(), Is.EqualTo(1));

            area.AddItem(new WorkCentre("Work Centre 1"));
            Assert.That(area.GetCount(), Is.EqualTo(2));

            Assert.That(area.WorkCentre.Count, Is.EqualTo(1));
            Assert.That(area.WorkCentre[0].Name, Is.EqualTo("Work Centre 1"));

            area.AddItem(new Area("Area 1a"));
            Assert.That(area.GetCount(), Is.EqualTo(3));

            Assert.That(area.Area1.Count, Is.EqualTo(1));
            Assert.That(area.Area1[0].Name, Is.EqualTo("Area 1a"));

            area.AddItem(new Area("Area 1b"));
            Assert.That(area.GetCount(), Is.EqualTo(4));

            Assert.That(area.Area1.Count, Is.EqualTo(2));
            Assert.That(area.Area1[1].Name, Is.EqualTo("Area 1b"));

            area.AddItem(new WorkCentre("Work Centre 2"));
            Assert.That(area.GetCount(), Is.EqualTo(5));
            
            Assert.That(area.WorkCentre.Count, Is.EqualTo(2));
            Assert.That(area.WorkCentre[1].Name, Is.EqualTo("Work Centre 2"));
        }

        [Test]
        public void AddItemWorkCentre()
        {
            Area area = new Area("Area 1");
            area.AddItem(new WorkCentre("Work Centre 1"));

            Assert.That(area.WorkCentre.Count, Is.EqualTo(1));
            Assert.That(area.WorkCentre[0].Name, Is.EqualTo("Work Centre 1"));

            area.AddItem(new WorkCentre("Work Centre 2"));

            Assert.That(area.WorkCentre.Count, Is.EqualTo(2));
            Assert.That(area.WorkCentre[1].Name, Is.EqualTo("Work Centre 2"));
        }

        [Test]
        public void TestToString()
        {
            Area area = new Area("My Area");
            Assert.That(area.ToString(), Is.EqualTo("Area 'My Area'"));

            area.Area1.AddArea("Area 1");
            Assert.That(area.ToString(), Is.EqualTo("Area 'My Area'"));

            area.WorkCentre.AddWorkCentre("Work Centre 1");
            Assert.That(area.ToString(), Is.EqualTo("Area 'My Area'"));
        }
    }
}