using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Excel.Commands
{
    public class HierarchyReaderCommand : ExcelReaderCommand
    {
        private readonly Hierarchy hierarchy;

        public HierarchyReaderCommand(IExcelSpreadsheet spreadsheet, Hierarchy hierarchy) : base(spreadsheet, "Hierarchy")
        {
            this.hierarchy = hierarchy;
        }

        public override void Execute()
        {
            
        }
    }
}