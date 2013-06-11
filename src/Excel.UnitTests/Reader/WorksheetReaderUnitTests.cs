using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.Writer;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests.Reader
{
    [TestFixture]
    public class WorksheetReaderUnitTests : ExcelTestFixture
    {
        [Test]
        public void NullConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new WorksheetWriter(null));
        }

        [Test]
        public void ReadRow()
        {
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(Filename))
            {
                IWorksheetWriter writer = spreadsheet.WriteToWorksheet("UnitTests");
                List<string> list = new List<string> {"One", "Two", "Three"};
                writer.WriteRow(list);
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
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
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
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
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
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

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                reader.MoveTo("A1");
                Assert.That(reader.Read(), Is.EqualTo("A-1"));
                Assert.That(reader.Read(), Is.EqualTo("B-1"));
                Assert.That(reader.Read(), Is.EqualTo("C-1"));
                Assert.That(reader.Read(), Is.EqualTo(string.Empty));

                reader.MoveTo("B2");
                Assert.That(reader.Read(), Is.EqualTo("B-2"));
                Assert.That(reader.Read(), Is.EqualTo("C-2"));
                Assert.That(reader.Read(), Is.EqualTo(string.Empty));
                Assert.That(reader.Read(), Is.EqualTo(string.Empty));
            }
        }

        [Test]
        public void ReadRowAfterMoveUsingRowColumn()
        {
            WriteTestValues();
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                reader.MoveTo(1, 2);
                List<string> row1 = reader.ReadRow();
                List<string> row2 = reader.ReadRow();
                Assert.That(row1, Is.EquivalentTo(new List<string> { "B-1", "C-1" }));
                Assert.That(row2, Is.EquivalentTo(new List<string> { "B-2", "C-2" }));
            }
        }

        [Test]
        public void ReadRowAfterMoveUsingAddress()
        {
            WriteTestValues();
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                reader.MoveTo("B1");
                List<string> row1 = reader.ReadRow();
                List<string> row2 = reader.ReadRow();
                Assert.That(row1, Is.EquivalentTo(new List<string> { "B-1", "C-1" }));
                Assert.That(row2, Is.EquivalentTo(new List<string> { "B-2", "C-2" }));

                reader.MoveTo("A1");
                Assert.That(reader.ReadRow(), Is.EquivalentTo(new List<string> { "A-1", "B-1", "C-1" }));
                Assert.That(reader.ReadRow(), Is.EquivalentTo(new List<string> { "A-2", "B-2", "C-2" }));
            }
        }

        [Test]
        public void GetCurrentCellAfterMoveAddress()
        {
            WriteTestValues();
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                Assert.That(reader.GetCurrentCell().Address, Is.EqualTo("A1"));
                Assert.That(reader.GetCurrentCell().Row, Is.EqualTo(1));
                Assert.That(reader.GetCurrentCell().Column, Is.EqualTo(1));
                Assert.That(reader.GetCurrentCell().Value, Is.EqualTo("A-1"));

                reader.MoveTo("A2");
                
                Assert.That(reader.GetCurrentCell().Address, Is.EqualTo("A2"));
                Assert.That(reader.GetCurrentCell().Row, Is.EqualTo(2));
                Assert.That(reader.GetCurrentCell().Column, Is.EqualTo(1));
                Assert.That(reader.GetCurrentCell().Value, Is.EqualTo("A-2"));

                reader.MoveTo("C1");

                Assert.That(reader.GetCurrentCell().Address, Is.EqualTo("C1"));
                Assert.That(reader.GetCurrentCell().Row, Is.EqualTo(1));
                Assert.That(reader.GetCurrentCell().Column, Is.EqualTo(3));
                Assert.That(reader.GetCurrentCell().Value, Is.EqualTo("C-1"));
            }
        }

        [Test]
        public void GetCurrentCellAfterMoveRowColumn()
        {
            WriteTestValues();
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                IWorksheetReader reader = spreadsheet.ReadWorksheet("UnitTests");
                Assert.That(reader.GetCurrentCell().Address, Is.EqualTo("A1"));
                Assert.That(reader.GetCurrentCell().Row, Is.EqualTo(1));
                Assert.That(reader.GetCurrentCell().Column, Is.EqualTo(1));
                Assert.That(reader.GetCurrentCell().Value, Is.EqualTo("A-1"));

                reader.MoveTo(2, 1);

                Assert.That(reader.GetCurrentCell().Address, Is.EqualTo("A2"));
                Assert.That(reader.GetCurrentCell().Row, Is.EqualTo(2));
                Assert.That(reader.GetCurrentCell().Column, Is.EqualTo(1));
                Assert.That(reader.GetCurrentCell().Value, Is.EqualTo("A-2"));

                reader.MoveTo(1, 3);

                Assert.That(reader.GetCurrentCell().Address, Is.EqualTo("C1"));
                Assert.That(reader.GetCurrentCell().Row, Is.EqualTo(1));
                Assert.That(reader.GetCurrentCell().Column, Is.EqualTo(3));
                Assert.That(reader.GetCurrentCell().Value, Is.EqualTo("C-1"));
            }
        }

        private void WriteTestValues()
        {
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(Filename))
            {
                IWorksheetWriter writer = spreadsheet.WriteToWorksheet("UnitTests");
                writer.WriteRow(new List<string> {"A-1", "B-1", "C-1"});
                writer.WriteRow(new List<string> {"A-2", "B-2", "C-2"});
                writer.WriteRow(new List<string> {"A-3", "B-3", "C-3"});
            }
        }
    }
}