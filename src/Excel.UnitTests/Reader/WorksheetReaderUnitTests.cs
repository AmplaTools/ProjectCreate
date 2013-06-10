using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.UnitTests.Helper;
using AmplaTools.ProjectCreate.Excel.Writer;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests.Reader
{
    [TestFixture]
    public class WorksheetReaderUnitTests : TestFixture
    {
        private readonly TempDirectory tempDirectory = new TempDirectory(@"Files\WorksheetReaderUnitTests",
                                                                         "UnitTest_{0:00}.xlsx");

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
                List<string> list = new List<string> {"One", "Two", "Three"};
                writer.WriteRow(list);
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                List<string> list = reader.ReadRow();
                Assert.That(list, Is.Not.Empty);
                Assert.That(list, Is.EquivalentTo(new List<string> {"One", "Two", "Three"}));
            }
        }

        [Test]
        public void MoveTo()
        {
            WriteTestValues();
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                reader.MoveTo(1,1);
                Assert.That(reader.Read(), Is.EqualTo("A-1"));

                reader.MoveTo(2,2);
                Assert.That(reader.Read(), Is.EqualTo("B-2"));
            }
        }

        [Test]
        public void MoveToAddress()
        {
            WriteTestValues();
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                reader.MoveTo("A1");
                Assert.That(reader.Read(), Is.EqualTo("A-1"));

                reader.MoveTo("B2");
                Assert.That(reader.Read(), Is.EqualTo("B-2"));
            }
        }

        [Test]
        public void Read()
        {
            WriteTestValues();

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                reader.MoveTo("A1");
                Assert.That(reader.Read(), Is.EqualTo("A-1"));
                Assert.That(reader.Read(), Is.EqualTo("A-2"));
                Assert.That(reader.Read(), Is.EqualTo("A-3"));
                Assert.That(reader.Read(), Is.EqualTo(string.Empty));

                reader.MoveTo("B2");
                Assert.That(reader.Read(), Is.EqualTo("B-2"));
                Assert.That(reader.Read(), Is.EqualTo("B-3"));
                Assert.That(reader.Read(), Is.EqualTo(string.Empty));
                Assert.That(reader.Read(), Is.EqualTo(string.Empty));
            }
        }

        private void WriteTestValues()
        {
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(filename))
            {
                IWorksheetWriter writer = spreadsheet.WriteToWorksheet("UnitTests");
                writer.WriteRow(new List<string> {"A-1", "A-2", "A-3"});
                writer.WriteRow(new List<string> {"B-1", "B-2", "B-3"});
                writer.WriteRow(new List<string> {"C-1", "C-2", "C-3"});
            }
        }
    }
}