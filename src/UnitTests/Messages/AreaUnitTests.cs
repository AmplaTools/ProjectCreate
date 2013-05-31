
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    [TestFixture]
    public class AreaUnitTests : TestFixture
    {
        [Test]
        public void Area()
        {
            Area area = new Area();
            Assert.That(area.name, Is.EqualTo("Area 1"));
            Assert.That(area.id, Is.Null);
            Assert.That(area.Area1, Is.Empty);
            Assert.That(area.WorkCentre, Is.Empty);
        }


    }
}