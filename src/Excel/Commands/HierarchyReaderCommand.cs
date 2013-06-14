using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Excel.Commands
{
    public class HierarchyReaderCommand : ExcelReaderCommand
    {
        private readonly Hierarchy hierarchy;
        private readonly List<string> header = new List<string> {"Depth", "Type", "Class", 
                "Level 1", "Level 2", "Level 3", 
                "Level 4", "Level 5", "Level 6", 
                "Level 7", "Level 8", "Level 9",
            };

        public HierarchyReaderCommand(IExcelSpreadsheet spreadsheet, Hierarchy hierarchy) : base(spreadsheet, "Hierarchy")
        {
            this.hierarchy = hierarchy;
        }

        /// <summary>
        /// Excutes the Command
        /// </summary>
        public override void Execute()
        {
            int row = 1;
            Item[] history = new Item[10];
            history[0] = hierarchy;
            
            ValidateHeader(WorksheetReader);
            
            row++;
            Item item = ReadFromRow(row, WorksheetReader, history);
            while (item != null)
            {
                row++;
                item = ReadFromRow(row, WorksheetReader, history);
            }
        }

        private Item ReadFromRow(int row, IWorksheetReader reader, Item[] history)
        {
            Item item = null;
            reader.MoveTo(row, 1);
            string firstValue = reader.Read();
            if (firstValue != string.Empty)
            {
                int depth;
                int.TryParse(firstValue, out depth);
                string isa95Type = reader.Read();
                string isa95Class = reader.Read();

                if ((depth < 1) || (depth > 9))
                {
                    throw new InvalidOperationException("Depth must be between 1 and 9");
                }

                reader.MoveTo(row, depth + 3);
                string name = reader.Read();

                switch (isa95Type)
                {
                    case "Enterprise":
                        {
                            item = new Enterprise(name);
                            break;
                        }
                    case "Site":
                        {
                            item = new Site(name);
                            break;
                        }
                    case "Area":
                        {
                            item = new Area(name);
                            break;
                        }
                    case "WorkCentre":
                        {
                            item = new WorkCentre(name);
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException("Invalid ISA95 type:" + isa95Type);
                        }
                }

                history[depth] = item;
                history[depth - 1].AddItem(item);
            }
            return item;
        }

        private void ValidateHeader(IWorksheetReader worksheetReader)
        {
            worksheetReader.MoveTo("A1");
            
            foreach (string expected in header)
            {
                string address = worksheetReader.GetCurrentCell().Address;
                string column = worksheetReader.Read();
                if (column != expected)
                {
                    string message = string.Format("Invalid header at {0}: Expected: '{1}' Actual: '{2}'", address, expected, column);
                    throw new InvalidOperationException(message);
                }
            }
        }
    }
}