
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
    }
}