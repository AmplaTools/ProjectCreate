
using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class WorkCentreUnitTests : TestFixture
    {
        [Test]
        public void Default()
        {
            WorkCentre workCentre = new WorkCentre();
            Assert.That(workCentre.Name, Is.EqualTo("WorkCentre 1"));
            Assert.That(workCentre.id, Is.Null);
        }

        [Test]
        public void ConstructorWithName()
        {
            WorkCentre workCentre = new WorkCentre("WorkCentre A");
            Assert.That(workCentre.Name, Is.EqualTo("WorkCentre A"));
            Assert.That(workCentre.id, Is.Null);
        }

        [Test]
        public void AddItemEnterprise()
        {
            WorkCentre workCentre = new WorkCentre("Work Centre");
            Assert.Throws<ArgumentException>(() => workCentre.AddItem(new Enterprise("My Enterprise")));
        }

        [Test]
        public void AddItemNull()
        {
            WorkCentre workCentre = new WorkCentre("Work Centre");
            Assert.Throws<ArgumentNullException>(() => workCentre.AddItem(null));
        }

        [Test]
        public void AddItemSite()
        {
            WorkCentre workCentre = new WorkCentre("Work Centre");
            Assert.Throws<ArgumentException>(() => workCentre.AddItem(new Site("My Site")));
        }

        [Test]
        public void AddItemArea()
        {
            WorkCentre workCentre = new WorkCentre("Work Centre");
            Assert.Throws<ArgumentException>(() => workCentre.AddItem(new Area("My Area")));
        }

        [Test]
        public void AddItemWorkCentre()
        {
            WorkCentre workCentre = new WorkCentre("Work Centre");
            Assert.Throws<ArgumentException>(() => workCentre.AddItem(new WorkCentre("My Work Centre")));
        }

        [Test]
        public void TestToString()
        {
            WorkCentre wc = new WorkCentre("My Work Centre");
            Assert.That(wc.ToString(), Is.EqualTo("WorkCentre 'My Work Centre'"));
        }
    }
}