
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
            Assert.That(workCentre.Name, Is.EqualTo("WorkCentre 1"));
            Assert.That(workCentre.id, Is.Null);
        }

        [Test]
        public void ConstructorWithName()
        {
            WorkCentre workCentre = new WorkCentre("WorkCentre A");
            Assert.That(workCentre.Name, Is.EqualTo("WorkCentre A"));
            Assert.That(workCentre.id, Is.Null);
        }

    }
}