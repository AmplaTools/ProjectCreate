using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Helper;
using ClosedXML.Excel;

namespace AmplaTools.ProjectCreate.Excel.Writer
{
    public interface IWorksheetWriter : IDisposable
    {
        void WriteRow(List<string> row);
    }

    public class WorksheetWriter : IWorksheetWriter
    {
        private IXLWorksheet xlWorksheet;
        private IXLCell current;

        public WorksheetWriter(IXLWorksheet xlWorksheet)
        {
            ArgumentCheck.IsNotNull(xlWorksheet);
            this.xlWorksheet = xlWorksheet;
            current = xlWorksheet.FirstRow().FirstCell();
        }

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