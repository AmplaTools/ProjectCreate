
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

  
    }
}