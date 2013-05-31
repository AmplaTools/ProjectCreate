
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
            Assert.That(hierarchy.Enterprise.name, Is.EqualTo("Enterprise"));

            Assert.That(hierarchy.GetCount(), Is.EqualTo(1));
        }
        
        [Test]
        public void Count()
        {
            Hierarchy hierarchy = new Hierarchy();
            Assert.That(hierarchy.GetCount(), Is.EqualTo(1));
            hierarchy.Enterprise = null;
            Assert.That(hierarchy.GetCount(), Is.EqualTo(0));

            hierarchy.Enterprise = new Enterprise() {Site = {new Site {name = "Site A", id = "enterprise.site a"}}};
            Assert.That(hierarchy.GetCount(), Is.EqualTo(2));
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

            Assert.That(hierarchy.GetCount(), Is.EqualTo(2));
        }
    }
}