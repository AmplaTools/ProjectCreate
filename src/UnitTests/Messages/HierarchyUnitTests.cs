
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public class HierarchyUnitTests : TestFixture
    {
        [Test]
        public void Default()
        {
            Hierarchy hierarchy = new Hierarchy();
            Assert.That(hierarchy.Enterprise, Is.Not.Null);
            Assert.That(hierarchy.Enterprise.name, Is.Null);

            Assert.That(hierarchy.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Count()
        {
            Hierarchy hierarchy = new Hierarchy();
            Assert.That(hierarchy.Count, Is.EqualTo(1));
            hierarchy.Enterprise = null;
            Assert.That(hierarchy.Count, Is.EqualTo(0));

            hierarchy.Enterprise = new Enterprise() {Site = {new Site {name = "Site A", id = "enterprise.site a"}}};
            Assert.That(hierarchy.Count, Is.EqualTo(2));
        }

        [Test]
        public void Enterprise()
        {
            Enterprise enterprise = new Enterprise();
            Assert.That(enterprise.name, Is.Null);
            Assert.That(enterprise.id, Is.Null);
            Assert.That(enterprise.Site, Is.Empty);
        }

        [Test]
        public void Site()
        {
            Site site = new Site();
            Assert.That(site.name, Is.Null);
            Assert.That(site.id, Is.Null);
            Assert.That(site.Area, Is.Empty);
        }

        [Test]
        public void Area()
        {
            Area site = new Area();
            Assert.That(site.name, Is.Null);
            Assert.That(site.id, Is.Null);
            Assert.That(site.Area1, Is.Empty);
        }

        [Test]
        public void Workcentre()
        {
            WorkCentre workCentre = new WorkCentre();
            Assert.That(workCentre.name, Is.Null);
            Assert.That(workCentre.id, Is.Null);
        }

        [Test]
        public void CountMultiple()
        {
            Hierarchy hierarchy = new Hierarchy
                {
                    Enterprise =
                        new Enterprise
                            {
                                name = "Enterprise",
                                id = "enterprise",
                                Site =  {new Site {name = "Site A", id = "enterprise.site a"}}
                            }
                };

            Assert.That(hierarchy.Count, Is.EqualTo(2));
        }
    }
}