using AmplaTools.ProjectCreate.Commands;
using AmplaTools.ProjectCreate.Excel.Reader;

namespace AmplaTools.ProjectCreate.Excel.Commands
{
    /// <summary>
    /// Excel Writer Command base class
    /// </summary>
    public abstract class ExcelReaderCommand : ICommand
    {
        private IWorksheetReader worksheetReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelReaderCommand"/> class.
        /// </summary>
        /// <param name="spreadsheet">The spreadsheet.</param>
        /// <param name="name">The name.</param>
        protected ExcelReaderCommand(IExcelSpreadsheet spreadsheet, string name)
        {
            worksheetReader = spreadsheet.ReadWorksheet(name);
        }

        /// <summary>
        /// Gets the worksheet writer.
        /// </summary>
        /// <value>
        /// The worksheet writer.
        /// </value>
        protected IWorksheetReader WorksheetReader
        {
            get { return worksheetReader; }
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
            if (worksheetReader == null) return;
            
            worksheetReader.Dispose();
            worksheetReader = null;
        }
    }
}