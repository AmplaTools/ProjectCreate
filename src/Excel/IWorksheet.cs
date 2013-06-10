using System;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.Writer;

namespace AmplaTools.ProjectCreate.Excel
{
    public interface IWorksheet : IDisposable
    {
        IWorksheetReader Read();

        IWorksheetWriter Write();
    }
}