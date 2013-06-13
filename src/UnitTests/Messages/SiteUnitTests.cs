
using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class SiteUnitTests : TestFixture
    {
        [Test]
        public void Default()
        {
            Site site = new Site();
            Assert.That(site.name, Is.EqualTo("Site 1"));
            Assert.That(site.id, Is.Null);
            Assert.That(site.Area, Is.Empty);
        }

        [Test]
        public void ItemCollection()
        {
            Site site = new Site();
            Assert.That(site.Area, Is.InstanceOf<AreaCollection>());

        }

        [Test]
        public void ConstructorWithName()
        {
            Site site = new Site("Site 4");
            Assert.That(site.Name, Is.EqualTo("Site 4"));
            Assert.That(site.id, Is.Null);
            Assert.That(site.Area, Is.InstanceOf<AreaCollection>());
        }

        [Test]
        public void AddItemEnterprise()
        {
            Site site = new Site("Site 1");
            Assert.Throws<ArgumentException>(() => site.AddItem(new Enterprise("My Enterprise")));
        }

        [Test]
        public void AddItemNull()
        {
            Site site = new Site("Site 1");
            Assert.Throws<ArgumentNullException>(() => site.AddItem(null));
        }

        [Test]
        public void AddItemSite()
        {
            Site site = new Site("Site 1");
            Assert.Throws<ArgumentException>(() => site.AddItem(new Site("Site 2")));
        }

        [Test]
        public void AddItemArea()
        {
            Site site = new Site("Site 1");
            site.AddItem(new Area("Area 1"));

            Assert.That(site.Area.Count, Is.EqualTo(1));
            Assert.That(site.Area[0].Name, Is.EqualTo("Area 1"));

            site.AddItem(new Area("Area 2"));

            Assert.That(site.Area.Count, Is.EqualTo(2));
            Assert.That(site.Area[1].Name, Is.EqualTo("Area 2"));
        }

        [Test]
        public void AddItemWorkCentre()
        {
            Site site = new Site("Site 1");
            Assert.Throws<ArgumentException>(() => site.AddItem(new WorkCentre("Work Centre 1")));
        }

        [Test]
        public void TestToString()
        {
            Site site = new Site("My Site");
            Assert.That(site.ToString(), Is.EqualTo("Site 'My Site'"));

            site.Area.AddArea("Area 1");
            Assert.That(site.ToString(), Is.EqualTo("Site 'My Site'"));
        }
    }
}