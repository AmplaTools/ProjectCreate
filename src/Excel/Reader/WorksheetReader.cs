using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace AmplaTools.ProjectCreate.Excel.Reader
{

    public interface IWorksheetReader : IDisposable
    {
        List<string> ReadRow();
        void MoveTo(string address);
        void MoveTo(int row, int column);
        string Read();
    }

    public class WorksheetReader : IWorksheetReader
    {
        private IXLWorksheet worksheet;
        private IXLCell current;

        public WorksheetReader(IXLWorksheet worksheet)
        {
            this.worksheet = worksheet;
            current = worksheet.FirstRow().FirstCell();
        }

        public void Dispose()
        {
            worksheet = null;
            current = null;
        }

        public List<string> ReadRow()
        {
            IXLCell position = current;
            List<string> values = new List<string>();
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
            current = worksheet.Cell(address);
        }

        public void MoveTo(int row, int column)
        {
            current = worksheet.Cell(row, column);
        }

        public string Read()
        {
            string value = current.GetString();

            current = current.CellRight();
            return value;
        }
    }
}