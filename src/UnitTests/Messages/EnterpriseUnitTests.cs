
using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class EnterpriseUnitTests : TestFixture
    {
        [Test]
        public void Default()
        {
            Enterprise enterprise = new Enterprise();
            Assert.That(enterprise.name, Is.EqualTo("Enterprise"));
            Assert.That(enterprise.id, Is.Null);
            Assert.That(enterprise.Site, Is.Empty);
        }

        [Test]
        public void ItemCollection()
        {
            Enterprise enterprise = new Enterprise();
            Assert.That(enterprise.Site, Is.InstanceOf<SiteCollection>());
            
        }

        [Test]
        public void ConstructorWithName()
        {
            Enterprise enterprise = new Enterprise("My Enterprise");
            Assert.That(enterprise.Name, Is.EqualTo("My Enterprise"));
            Assert.That(enterprise.id, Is.Null);
            Assert.That(enterprise.Site, Is.InstanceOf<SiteCollection>());
        }

        [Test]
        public void AddItemEnterprise()
        {
            Enterprise enterprise = new Enterprise();
            Assert.Throws<ArgumentException>(() => enterprise.AddItem(new Enterprise("My Enterprise")));
        }

        [Test]
        public void AddItemNull()
        {
            Enterprise enterprise = new Enterprise();
            Assert.Throws<ArgumentNullException>(() => enterprise.AddItem(null));
        }

        [Test]
        public void AddItemSite()
        {
            Enterprise enterprise = new Enterprise();

            enterprise.AddItem(new Site("Site 1"));

            Assert.That(enterprise.Site.Count, Is.EqualTo(1));
            Assert.That(enterprise.Site[0].Name, Is.EqualTo("Site 1"));

            enterprise.AddItem(new Site("Site 2"));

            Assert.That(enterprise.Site.Count, Is.EqualTo(2));
            Assert.That(enterprise.Site[1].Name, Is.EqualTo("Site 2"));
        }

        [Test]
        public void AddItemArea()
        {
            Enterprise enterprise = new Enterprise();
            Assert.Throws<ArgumentException>(() => enterprise.AddItem(new Area("My Area")));
        }

        [Test]
        public void AddItemWorkCentre()
        {
            Enterprise enterprise = new Enterprise();
            Assert.Throws<ArgumentException>(() => enterprise.AddItem(new WorkCentre("My Work Centre")));
        }
        
        [Test]
        public void TestToString()
        {
            Enterprise enterprise = new Enterprise("My Enterprise");
            Assert.That(enterprise.ToString(), Is.EqualTo("Enterprise 'My Enterprise'"));

            enterprise.Site.AddSite("Site 1");
            Assert.That(enterprise.ToString(), Is.EqualTo("Enterprise 'My Enterprise'"));
        }
    }
}