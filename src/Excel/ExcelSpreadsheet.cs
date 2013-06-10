using System;
using System.IO;
using System.Linq;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.Writer;
using AmplaTools.ProjectCreate.Helper;
using ClosedXML.Excel;

namespace AmplaTools.ProjectCreate.Excel
{

    public class ExcelSpreadsheet : IExcelSpreadsheet
    {
        private XLWorkbook workbook;
        private readonly string filename;
        private readonly bool existingFile;
        private bool disposed = true;
        private bool isReadOnly;

        public ExcelSpreadsheet(string filename)
        {
            ArgumentCheck.IsNotNull(filename);
            ArgumentCheck.IsNotEmpty(filename);

            FileInfo fileInfo = new FileInfo(filename);
            existingFile = fileInfo.Exists;

            this.filename = filename;
            if (existingFile)
            {
                workbook = new XLWorkbook(filename);
            }
            else
            {
                workbook = new XLWorkbook();
            }
            disposed = false;
        }

        public void Dispose()
        {
            if (workbook == null) return;
            if (disposed) return;
            if (!IsReadOnly)
            {
                if (existingFile)
                {
                    workbook.Save();
                }
                else
                {
                    workbook.SaveAs(filename);
                }
            }
            disposed = true;
            workbook = null;
        }


        public static IExcelSpreadsheet CreateNew(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            
            ExcelSpreadsheet excel = new ExcelSpreadsheet(filename);
            return excel;
        }

        public static IExcelSpreadsheet OpenReadOnly(string filename)
        {
            ExcelSpreadsheet spreadsheet = new ExcelSpreadsheet(filename) {IsReadOnly = true};
            return spreadsheet;
        }


        private void CheckDisposed()
        {
            if (disposed) throw new ObjectDisposedException("ExcelSpreadsheet");
        }

        public bool IsReadOnly
        {
            get
            {
                CheckDisposed();
                return isReadOnly;

            }
            private set { isReadOnly = value; }
        }

        public IWorksheet GetWorksheet(string name)
        {
            var worksheet = GetOrCreateWorksheet(name);
            return new ExcelWorksheet(worksheet);
        }

        public IWorksheetReader ReadWorksheet(string name)
        {
            var worksheet = GetOrCreateWorksheet(name);
            return new WorksheetReader(worksheet);
        }
        
        /// <summary>
        ///     Get a worksheet writer for the specified worksheet
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IWorksheetWriter WriteToWorksheet(string name)
        {
            var worksheet = GetOrCreateWorksheet(name);

            return new WorksheetWriter(worksheet);
        }

        private IXLWorksheet GetOrCreateWorksheet(string name)
        {
            IXLWorksheet worksheet = workbook.Worksheets.FirstOrDefault(ws => ws.Name == name) ??
                                     workbook.AddWorksheet(name);
            return worksheet;
        }
    }
}
