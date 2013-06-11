using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Helper;
using ClosedXML.Excel;

namespace AmplaTools.ProjectCreate.Excel.Writer
{

    /// <summary>
    ///     Allows the writing of values to an Excel Spreadsheet
    /// </summary>
    public class WorksheetWriter : IWorksheetWriter
    {
        private IXLWorksheet xlWorksheet;
        private IXLCell current;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorksheetWriter"/> class.
        /// </summary>
        /// <param name="xlWorksheet">The xl worksheet.</param>
        public WorksheetWriter(IXLWorksheet xlWorksheet)
        {
            ArgumentCheck.IsNotNull(xlWorksheet);
            this.xlWorksheet = xlWorksheet;
            current = xlWorksheet.FirstRow().FirstCell();
        }

        /// <summary>
        /// Writes a list of values to the current row
        /// </summary>
        /// <param name="row"></param>
        public void WriteRow(List<string> row)
        {
            IXLCell start = current;
            foreach (string value in row)
            {
                current.Value = value;
                current = current.CellRight();
            }
            current = start.CellBelow();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (xlWorksheet != null)
            {
                xlWorksheet.Dispose();
                xlWorksheet = null;
            }
            current = null;
        }
    }
}