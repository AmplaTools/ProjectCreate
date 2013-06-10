using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.Writer;
using ClosedXML.Excel;

namespace AmplaTools.ProjectCreate.Excel
{
    public class ExcelWorksheet : IWorksheet
    {
        private IXLWorksheet worksheet;

        public ExcelWorksheet(IXLWorksheet worksheet)
        {
            this.worksheet = worksheet;
        }

        public IWorksheetReader Read()
        {
            return new WorksheetReader(worksheet);
        }

        public IWorksheetWriter Write()
        {
            return new WorksheetWriter(worksheet);
        }

        public void Dispose()
        {
            worksheet = null;
        }
    }
}