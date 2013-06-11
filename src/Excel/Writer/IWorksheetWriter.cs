using System;
using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Excel.Writer
{
    /// <summary>
    ///     Allows the writing to an Excel Worksheet
    /// </summary>
    public interface IWorksheetWriter : IDisposable
    {
        /// <summary>
        ///     Writes a list of values to the current row
        /// </summary>
        /// <param name="row"></param>
        void WriteRow(List<string> row);
    }

}