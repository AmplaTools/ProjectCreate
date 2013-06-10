using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.UnitTests.Helper;
using AmplaTools.ProjectCreate.Excel.Writer;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests.Writer
{
    [TestFixture]
    public class WorksheetWriterUnitTests : TestFixture
    {
        private readonly TempDirectory tempDirectory = new TempDirectory(@"Files\WorksheetWriterUnitTests", "UnitTest_{0:00}.xlsx");
        private string filename;

        protected override void OnFixtureSetUp()
        {
            base.OnFixtureSetUp();
            tempDirectory.DeleteAllFiles();
        }

        protected override void OnSetUp()
        {
            base.OnSetUp();
            filename = tempDirectory.GetNextTemporaryFile();

        }

        [Test]
        public void NullConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new WorksheetWriter(null));
        }

        [Test]
        public void WriteRow()
        {
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(filename))
            {
                IWorksheetWriter writer = spreadsheet.WriteToWorksheet("UnitTests");
                List<string> list = new List<string>() {"One", "Two", "Three"};
                writer.WriteRow(list);
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                List<string> list = reader.ReadRow();
                Assert.That(list, Is.Not.Empty);
                Assert.That(list, Is.EquivalentTo(new List<string>() { "One", "Two", "Three" }));
            }
        }

        [Test]
        public void Write2Rows()
        {
            using (IExcelSpreadsheet spreadsheet = new ExcelSpreadsheet(filename))
            {
                IWorksheetWriter writer = spreadsheet.WriteToWorksheet("UnitTests");
                writer.WriteRow(new List<string> { "One", "Two", "Three" });
                writer.WriteRow(new List<string> { "Four", "Five", "Six" });
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                List<string> list = reader.ReadRow();
                Assert.That(list, Is.Not.Empty);
                Assert.That(list, Is.EquivalentTo(new List<string>() { "One", "Two", "Three" }));
                list = reader.ReadRow();
                Assert.That(list, Is.Not.Empty);
                Assert.That(list, Is.EquivalentTo(new List<string>() { "Four", "Five", "Six" }));
            }
        }

    }
}