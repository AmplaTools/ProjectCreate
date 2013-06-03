using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class ItemExtenderUnitTests : TestFixture
    {
        [Test]
        public void WorkCentreGetDescendants()
        {
            WorkCentre workCentre = new WorkCentre();
            Assert.That(workCentre.GetDescendants(), Is.Empty);
        }

        [Test]
        public void AreaGetDescendants()
        {
            Area area = new Area();
            Assert.That(area.GetDescendants(), Is.Empty);

            WorkCentre wc1 = new WorkCentre() {name = "WC1"};
            area.WorkCentre.Add(wc1);

            Assert.That(area.GetDescendants(), Is.Not.Empty);
            Assert.That(area.GetDescendants().Count, Is.EqualTo(1));
            Assert.That(area.GetDescendants()[0], Is.EqualTo(wc1));

            WorkCentre wc2 = new WorkCentre() { name = "WC2" };
            area.WorkCentre.Add(wc2);

            Assert.That(area.GetDescendants(), Is.Not.Empty);
            Assert.That(area.GetDescendants().Count, Is.EqualTo(2));
            Assert.That(area.GetDescendants()[0], Is.EqualTo(wc1));
            Assert.That(area.GetDescendants()[1], Is.EqualTo(wc2));
        }

        [Test]
        public void SiteGetDescendants()
        {
            Site site = new Site();
            Assert.That(site.GetDescendants(), Is.Empty);

            Area area1 = new Area();
            site.Area.Add(area1);

            Assert.That(site.GetDescendants(), Is.Not.Empty);
            Assert.That(site.GetDescendants().Count, Is.EqualTo(1));
            Assert.That(site.GetDescendants()[0], Is.EqualTo(area1));

            WorkCentre wc2 = new WorkCentre() { name = "WC2" };
            area1.WorkCentre.Add(wc2);

            Assert.That(site.GetDescendants(), Is.Not.Empty);
            Assert.That(site.GetDescendants().Count, Is.EqualTo(2));
            Assert.That(site.GetDescendants()[0], Is.EqualTo(area1));
            Assert.That(site.GetDescendants()[1], Is.EqualTo(wc2));
        }

        [Test]
        public void HiearchyGetDescendants()
        {
            Hierarchy hierarchy = Helper.HierarchyHelper.CreateDefaultHierarchy();
            List<IItem> descendants = hierarchy.GetDescendants();
            Assert.That(descendants, Is.Not.Empty);

            Assert.That(descendants.Count, Is.EqualTo(hierarchy.GetCount()));
        }
    }
}