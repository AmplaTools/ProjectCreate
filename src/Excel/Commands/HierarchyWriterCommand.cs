using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Excel.Commands
{
    /// <summary>
    ///     Command to write the Hierarchy to the spreadsheet
    /// </summary>
    public class HierarchyWriterCommand : ExcelWriterCommand
    {
        private readonly Hierarchy hierarchy;

        private readonly List<string> header = new List<string> {"Depth", "Type", "Class", 
                "Level 1", "Level 2", "Level 3", 
                "Level 4", "Level 5", "Level 6", 
                "Level 7", "Level 8", "Level 9",
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchyWriterCommand"/> class.
        /// </summary>
        /// <param name="hierarchy">The hierarchy.</param>
        /// <param name="spreadsheet">The spreadsheet.</param>
        public HierarchyWriterCommand(Hierarchy hierarchy, IExcelSpreadsheet spreadsheet)
            : base(spreadsheet, "Hierarchy")
        {
            this.hierarchy = hierarchy;
        }

        /// <summary>
        /// Excutes the Command
        /// </summary>
        public override void Execute()
        {
            WorksheetWriter.MoveTo("A1");
            
            WorksheetWriter.WriteRow(header);
            WriteItems(hierarchy.Enterprise, 1);
        }

        /// <summary>
        /// Writes the items.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="depth">The depth.</param>
        private void WriteItems(IItem item, int depth)
        {
            List<string> row = new List<string> {Convert.ToString(depth), item.GetType().Name, string.Empty};
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