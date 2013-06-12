using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class SiteCollectionUnitTests : TestFixture
    {
        [Test]
        public void AddSite()
        {
            Enterprise enterprise = new Enterprise("Enterprise 1");
            Site site = enterprise.Site.AddSite("Site 1");

            Assert.That(site, Is.Not.Null);
            Assert.That(enterprise.Site, Contains.Item(site));
            Assert.That(site.FullName, Is.EqualTo("Enterprise 1.Site 1"));
        }
    }
}