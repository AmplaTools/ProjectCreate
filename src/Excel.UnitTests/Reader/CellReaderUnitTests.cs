using System;
using AmplaTools.ProjectCreate.Excel.Reader;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests.Reader
{
    [TestFixture]
    public class CellReaderUnitTests : ExcelTestFixture
    {
        [Test]
        public void NullConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new CellReader(null));
        }
    }
}