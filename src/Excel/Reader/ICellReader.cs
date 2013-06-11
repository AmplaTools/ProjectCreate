namespace AmplaTools.ProjectCreate.Excel.Reader
{
    public interface ICellReader
    {
        string Address { get; }
        int Row { get; }
        int Column { get; }
        object Value { get; }
    }
}