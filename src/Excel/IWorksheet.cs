using System;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.Writer;

namespace AmplaTools.ProjectCreate.Excel
{
    /// <summary>
    ///     Excel worksheet that allows either reading or writing
    /// </summary>
    public interface IWorksheet : IDisposable
    {
        /// <summary>
        ///     Open the worksheet for Reading
        /// </summary>
        /// <returns></returns>
        IWorksheetReader Read();

        /// <summary>
        ///     Open the worksheet for Writing
        /// </summary>
        /// <returns></returns>
        IWorksheetWriter Write();
    }
}