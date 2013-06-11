using ClosedXML.Excel;

namespace AmplaTools.ProjectCreate.Excel.Reader
{
    public class CellReader : ICellReader
    {
        public CellReader(IXLCell current)
        {
            Address = current.Address.ToStringRelative(false);
            Row = current.Address.RowNumber;
            Column = current.Address.ColumnNumber;
            Value = current.Value;
        }

        public string Address { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public object Value { get; private set; }
    }
}