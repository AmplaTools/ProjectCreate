using System;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.Writer;

namespace AmplaTools.ProjectCreate.Excel
{
    public interface IExcelSpreadsheet : IDisposable
    {
        IWorksheet GetWorksheet(string name);

        IWorksheetReader ReadWorksheet(string name);

        IWorksheetWriter WriteToWorksheet(string name);

        bool IsReadOnly { get; }
    }
}