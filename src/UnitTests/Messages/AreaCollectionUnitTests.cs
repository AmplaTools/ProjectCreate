using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class AreaCollectionUnitTests : TestFixture
    {
        [Test]
        public void AddArea()
        {
            Site site = new Site("Site 1");
            Area area = site.Area.AddArea("Area 1");

            Assert.That(area, Is.Not.Null);
            Assert.That(site.Area, Contains.Item(area));
            Assert.That(area.FullName, Is.EqualTo("Site 1.Area 1"));
        }
    }
}