
using AmplaTools.ProjectCreate.Helper;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public class HierarchyUnitTests : TestFixture
    {
        private const string exampleResourcePath = "AmplaTools.ProjectCreate.Resources.Messages.Hierarchy.Example.xml";

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

        [Test]
        public void LoadFromString()
        {
            string xml = AssemblyResources.GetTextFile(typeof (HierarchyUnitTests).Assembly, exampleResourcePath);

            Hierarchy hierarchy = SerializationHelper.DeserializeFromString<Hierarchy>(xml);
            Assert.That(hierarchy, Is.Not.Null);
            Assert.That(hierarchy.Enterprise, Is.Not.Null);
            Assert.That(hierarchy.Enterprise.Name, Is.EqualTo("Mining Company"));
            Assert.That(hierarchy.Enterprise.Site, Is.Not.Empty);
            Assert.That(hierarchy.Enterprise.Site[0].Name, Is.EqualTo("Remote Site"));
            Assert.That(hierarchy.Enterprise.Site[0].Area, Is.Not.Empty);
            Assert.That(hierarchy.Enterprise.Site[0].Area[0].Name, Is.EqualTo("Mining"));
            Assert.That(hierarchy.Enterprise.Site[0].Area[1].Name, Is.EqualTo("Processing"));
            Assert.That(hierarchy.Enterprise.Site[0].Area[1].WorkCentre, Is.Not.Empty);
            Assert.That(hierarchy.Enterprise.Site[0].Area[1].WorkCentre[0].Name, Is.EqualTo("ROM"));
        }

        [Test]
        public void RoundTripFromString()
        {
            string xml = AssemblyResources.GetTextFile(typeof(HierarchyUnitTests).Assembly, exampleResourcePath);

            Hierarchy hierarchy = SerializationHelper.DeserializeFromString<Hierarchy>(xml);

            string roundTrip = SerializationHelper.SerializeToString(hierarchy);

            Assert.That(roundTrip, Is.EqualTo(xml));
        }


    }
}