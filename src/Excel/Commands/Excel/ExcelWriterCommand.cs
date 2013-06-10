using AmplaTools.ProjectCreate.Excel.Writer;

namespace AmplaTools.ProjectCreate.Excel.Commands.Excel
{
    public abstract class ExcelWriterCommand : ICommand
    {
        private readonly IWorksheetWriter worksheetWriter;

        protected ExcelWriterCommand(ExcelSpreadsheet spreadsheet, string name)
        {
            worksheetWriter = spreadsheet.WriteToWorksheet(name);
        }

        protected IWorksheetWriter WorksheetWriter
        {
            get { return worksheetWriter; }
        }

        public abstract void Execute();
    }
}