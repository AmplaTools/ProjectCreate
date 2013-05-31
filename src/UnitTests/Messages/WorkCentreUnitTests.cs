
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class WorkCentreUnitTests : TestFixture
    {
        [Test]
        public void Default()
        {
            WorkCentre workCentre = new WorkCentre();
            Assert.That(workCentre.Name, Is.EqualTo("WorkCentre"));
            Assert.That(workCentre.id, Is.Null);
        }

    }
}