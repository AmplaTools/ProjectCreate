using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Writer;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Excel.Commands.Excel
{
    public class HierarchyWriterCommand : ExcelWriterCommand
    {
        private Hierarchy hierarchy;

        public HierarchyWriterCommand(Hierarchy hierarchy, IExcelSpreadsheet spreadsheet)
            : base(spreadsheet, "Hierarchy")
        {
            this.hierarchy = hierarchy;
        }

        public override void Execute()
        {
            WorksheetWriter.MoveTo("A1");
            List<string> header = new List<string> {"Depth", "Type", "Class", 
                "Level 1", "Level 2", "Level 3", 
                "Level 4", "Level 5", "Level 6", 
                "Level 7", "Level 8", "Level 9",
            };
            WorksheetWriter.WriteRow(header);
            WriteItems(hierarchy.Enterprise, 1);
        }

        private void WriteItems(IItem item, int depth)
        {
            List<string> row = new List<string>();
            row.Add(Convert.ToString(depth));
            row.Add(item.GetType().Name);
            row.Add(string.Empty);
            for (int i = 1; i < depth; i++)
            {
                row.Add(string.Empty);
            }
            row.Add(item.Name);
            WorksheetWriter.WriteRow(row);
            foreach (IItem child in item.GetItems())
            {
                WriteItems(child, depth + 1);
            }
        }
    }
}