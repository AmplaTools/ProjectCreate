using AmplaTools.ProjectCreate.Commands;
using AmplaTools.ProjectCreate.Excel.Writer;

namespace AmplaTools.ProjectCreate.Excel.Commands
{
    /// <summary>
    /// Excel Writer Command base class
    /// </summary>
    public abstract class ExcelWriterCommand : ICommand
    {
        private IWorksheetWriter worksheetWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelWriterCommand"/> class.
        /// </summary>
        /// <param name="spreadsheet">The spreadsheet.</param>
        /// <param name="name">The name.</param>
        protected ExcelWriterCommand(IExcelSpreadsheet spreadsheet, string name)
        {
            worksheetWriter = spreadsheet.WriteToWorksheet(name);
        }

        /// <summary>
        /// Gets the worksheet writer.
        /// </summary>
        /// <value>
        /// The worksheet writer.
        /// </value>
        protected IWorksheetWriter WorksheetWriter
        {
            get { return worksheetWriter; }
        }

        /// <summary>
        ///     Excutes the Command
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (worksheetWriter == null) return;
            
            worksheetWriter.Dispose();
            worksheetWriter = null;
        }
    }
}