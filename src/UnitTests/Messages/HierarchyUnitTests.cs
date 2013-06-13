
using System;
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
            Assert.That(hierarchy.Enterprise, Is.Null);
           
            Assert.That(hierarchy.GetCount(), Is.EqualTo(0));
        }
        
        [Test]
        public void Count()
        {
            Hierarchy hierarchy = new Hierarchy();
            Assert.That(hierarchy.GetCount(), Is.EqualTo(0));
            hierarchy.Enterprise = new Enterprise();
            Assert.That(hierarchy.GetCount(), Is.EqualTo(1));

            hierarchy.Enterprise = new Enterprise {Site = {new Site {name = "Site A", id = "enterprise.site a"}}};
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

        [Test]
        public void Empty()
        {
            Hierarchy hierarchy = Hierarchy.Empty();
            Assert.That(hierarchy, Is.Not.Null);
            Assert.That(hierarchy.Enterprise, Is.Null);
            Assert.That(hierarchy.GetCount(), Is.EqualTo(0));
        }

        [Test]
        public void EmptyRoundTrip()
        {
            Hierarchy hierarchy = Hierarchy.Empty();

            string xml = SerializationHelper.SerializeToString(hierarchy);
            Hierarchy result = SerializationHelper.DeserializeFromString<Hierarchy>(xml);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Enterprise, Is.Null);
            Assert.That(result.GetCount(), Is.EqualTo(0));
        }

        [Test]
        public void AddItemEnterprise()
        {
            Hierarchy hierarchy = Hierarchy.Empty();
            hierarchy.AddItem(new Enterprise("My Enterprise"));

            Assert.That(hierarchy.Enterprise, Is.Not.Null);
            Assert.That(hierarchy.Enterprise.Name, Is.EqualTo("My Enterprise"));

            Assert.Throws<InvalidOperationException>(() => hierarchy.AddItem(new Enterprise("Another Enterprise")));
        }

        [Test]
        public void AddItemNull()
        {
            Hierarchy hierarchy = Hierarchy.Empty();
            Assert.Throws<ArgumentNullException>(() => hierarchy.AddItem(null));
        }

        [Test]
        public void AddItemSite()
        {
            Hierarchy hierarchy = Hierarchy.Empty();
            Assert.Throws<ArgumentException>(() => hierarchy.AddItem(new Site("Site 1")));
        }

        [Test]
        public void AddItemArea()
        {
            Hierarchy hierarchy = Hierarchy.Empty();
            Assert.Throws<ArgumentException>(() => hierarchy.AddItem(new Area("Area 1")));
        }

        [Test]
        public void AddItemWorkCentre()
        {
            Hierarchy hierarchy = Hierarchy.Empty();
            Assert.Throws<ArgumentException>(() => hierarchy.AddItem(new WorkCentre("Work Centre")));
        }

        [Test]
        public void TestToString()
        {
            Hierarchy hierarchy = Hierarchy.Empty();
            Assert.That(hierarchy.ToString(), Is.EqualTo("Hierarchy (0 items)"));

            hierarchy.Enterprise = new Enterprise();
            Assert.That(hierarchy.ToString(), Is.EqualTo("Hierarchy (1 item)"));

            hierarchy.Enterprise.Site.AddSite("Site 1");
            Assert.That(hierarchy.ToString(), Is.EqualTo("Hierarchy (2 items)"));
        }
    }
}