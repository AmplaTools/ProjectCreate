using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class WorkCentreCollectionUnitTests : TestFixture
    {
        [Test]
        public void AddWorkCentre()
        {
            Area area = new Area("Area 1");
            WorkCentre wc = area.WorkCentre.AddWorkCentre("WorkCentre 1");

            Assert.That(wc, Is.Not.Null);
            Assert.That(area.WorkCentre, Contains.Item(wc));
            Assert.That(wc.FullName, Is.EqualTo("Area 1.WorkCentre 1"));
        }
    }
}