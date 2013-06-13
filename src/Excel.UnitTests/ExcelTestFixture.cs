
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.UnitTests.Helper;
using AmplaTools.ProjectCreate.Excel.Writer;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests
{
    [TestFixture]
    public abstract class ExcelTestFixture : TestFixture
    {
        protected override void OnFixtureSetUp()
        {
            base.OnFixtureSetUp();
            string directory = @"Files\" + GetType().Name;
            TempDirectory = new TempDirectory(directory, "UnitTest_{0:00}.xlsx");
            TempDirectory.DeleteAllFiles();
        }

        protected override void OnSetUp()
        {
            base.OnSetUp();
            Filename = TempDirectory.GetNextTemporaryFile();
        }

        protected string Filename { get; private set; }
    
        protected TempDirectory TempDirectory { get; private set; }

        protected IWorksheetWriter SetupWorksheet(string name)
        {
            return new Worksheet(Filename, name);
        }

        public class Worksheet : IWorksheetWriter
        {
            private IExcelSpreadsheet spreadsheet;
            private IWorksheetWriter writer;

            public Worksheet(string filename, string name)
            {
                spreadsheet = ExcelSpreadsheet.CreateNew(filename);
                writer = spreadsheet.WriteToWorksheet(name);
            }

            public void Dispose()
            {
                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }

                if (spreadsheet != null)
                {
                    spreadsheet.Dispose();
                    spreadsheet = null;
                }
            }

            public ICellReader GetCurrentCell()
            {
                return writer.GetCurrentCell();
            }

            public void MoveTo(string address)
            {
                writer.MoveTo(address);
            }

            public void MoveTo(int row, int column)
            {
                writer.MoveTo(row, column);
            }

            public void WriteRow(List<string> row)
            {
                writer.WriteRow(row);
            }

            public void Write(string value)
            {
                writer.Write(value);
            }
        }

    }
}