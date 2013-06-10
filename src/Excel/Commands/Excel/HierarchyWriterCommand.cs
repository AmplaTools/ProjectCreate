using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Writer;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Excel.Commands.Excel
{
    public class HierarchyWriterCommand : ExcelWriterCommand
    {
        private Hierarchy hierarchy;

        public HierarchyWriterCommand(Hierarchy hierarchy, ExcelSpreadsheet spreadsheet)
            : base(spreadsheet, "Hierarchy")
        {
            this.hierarchy = hierarchy;
        }

        public override void Execute()
        {
            //IWorksheetWriter worksheetWriter = WorksheetWriter.GetWorksheet("Hierarchy");
            List<string> header = new List<string> {"Depth", "Type", "Class", 
                "Level 1", "Level 2", "Level 3", "Level 4", "Level 5",
                "Level 5", "Level 6", "Level 7", "Level 8", "Level 9",
            };
            //worksheetWriter.WriteRow(header);
        }
    }
}