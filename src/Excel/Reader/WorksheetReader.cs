using System.Collections.Generic;
using ClosedXML.Excel;

namespace AmplaTools.ProjectCreate.Excel.Reader
{
    public class WorksheetReader : IWorksheetReader
    {
        private IXLCell current;

        public WorksheetReader(IXLWorksheet worksheet)
        {
            current = worksheet.FirstRow().FirstCell();
        }

        public void Dispose()
        {
            current = null;
        }

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

        public void MoveTo(string address)
        {
            current = current.Worksheet.Cell(address);
        }

        public void MoveTo(int row, int column)
        {
            current = current.Worksheet.Cell(row, column);
        }

        public string Read()
        {
            string value = current.GetString();

            current = current.CellRight();
            return value;
        }

        public ICellReader GetCurrentCell()
        {
            return new CellReader(current);
        }
    }
}