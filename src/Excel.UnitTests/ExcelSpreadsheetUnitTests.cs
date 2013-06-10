using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.UnitTests.Helper;
using AmplaTools.ProjectCreate.Excel.Writer;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests
{
    [TestFixture]
    public class ExcelSpreadsheetUnitTests : TestFixture
    {
        private readonly TempDirectory tempDirectory = new TempDirectory(@"Files\ExcelSpreadsheetUnitTests", "UnitTest_{0:00}.xlsx");
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
        public void NullFilename()
        {
            Assert.Throws<ArgumentNullException>(() => new ExcelSpreadsheet(null));
        }

        [Test]
        public void EmptyFilename()
        {
            Assert.Throws<ArgumentException>(() => new ExcelSpreadsheet(""));
        }

        public void ReadOnlyWorksheet()
        {
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(filename))
            {
                Assert.That(spreadsheet.IsReadOnly, Is.False);
                IWorksheetWriter worksheet = spreadsheet.WriteToWorksheet("New sheet");
                worksheet.WriteRow(new List<string>(){"One", "Two", "Three"});
                Assert.That(worksheet, Is.Not.Null);
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(filename))
            {
                Assert.That(spreadsheet.IsReadOnly, Is.True);
            } 
        }

        [Test]
        public void ReadAndWrite()
        {
            List<string> list = new List<string>() {"One", "Two", "Three"};
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(filename))
            {
                IWorksheetWriter worksheet = spreadsheet.WriteToWorksheet("New sheet");
                Assert.That(worksheet, Is.Not.Null);
                worksheet.WriteRow(list);
            }

            List<string> result;

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(filename))
            {
                IWorksheetReader worksheet = spreadsheet.ReadWorksheet("New sheet");
                Assert.That(worksheet, Is.Not.Null);
                result = worksheet.ReadRow();
            }

            Assert.That(result, Is.EquivalentTo(list));
        }


    }
}