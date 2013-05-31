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
  
    }
}