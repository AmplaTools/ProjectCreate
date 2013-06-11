using System.Collections.Generic;
using ClosedXML.Excel;

namespace AmplaTools.ProjectCreate.Excel.Reader
{
    /// <summary>
    ///     Allows reading the values from a worksheet
    /// </summary>
    public class WorksheetReader : IWorksheetReader
    {
        private IXLCell current;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorksheetReader"/> class.
        /// </summary>
        /// <param name="worksheet">The worksheet.</param>
        public WorksheetReader(IXLWorksheet worksheet)
        {
            current = worksheet.FirstRow().FirstCell();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            current = null;
        }

        /// <summary>
        /// Reads a row of values from the current position and moves down a row
        /// </summary>
        /// <returns></returns>
        public List<string> ReadRow()
        {
            IXLCell position = current;
            var values = new List<string>();
            string value = current.GetString();

            while (!string.IsNullOrEmpty(value))
            {
                values.Add(value);

                current = current.CellRight();
                value = current.GetString();
            }
            current = position.CellBelow();
            return values;
        }

        /// <summary>
        /// Moves to the specified cell using the address
        /// </summary>
        /// <param name="address"></param>
        public void MoveTo(string address)
        {
            current = current.Worksheet.Cell(address);
        }

        /// <summary>
        /// Moves to the specified row and column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void MoveTo(int row, int column)
        {
            current = current.Worksheet.Cell(row, column);
        }

        /// <summary>
        /// Reads the current cell and moves to the right
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            string value = current.GetString();

            current = current.CellRight();
            return value;
        }

        /// <summary>
        /// Gets the current cell
        /// </summary>
        /// <returns></returns>
        public ICellReader GetCurrentCell()
        {
            return new CellReader(current);
        }
    }
}