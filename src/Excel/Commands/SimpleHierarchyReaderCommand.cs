using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Excel.Commands
{
    public class SimpleHierarchyReaderCommand : ExcelReaderCommand
    {
        private readonly Hierarchy hierarchy;
        private readonly List<string> header = new List<string> {
                "Level 1", "Level 2", "Level 3", 
                "Level 4", "Level 5", "Level 6", 
                "Level 7", "Level 8", "Level 9",
            };

        public SimpleHierarchyReaderCommand(IExcelSpreadsheet spreadsheet, Hierarchy hierarchy) : base(spreadsheet, "Hierarchy")
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
            
            int maxDepth = ValidateHeader(WorksheetReader);

            if (maxDepth == 0)
            {
                throw new InvalidOperationException("Unable to load hierarchy - spreadsheet is empty.");   
            }

            row++;
            Item item = ReadFromRow(row, WorksheetReader, history, maxDepth);
            while (item != null)
            {
                row++;
                item = ReadFromRow(row, WorksheetReader, history, maxDepth);
            }
        }

        private Item ReadFromRow(int row, IWorksheetReader reader, Item[] history, int maxDepth)
        {
            Item item = null;
            reader.MoveTo(row, 1);

            int depth = 1;
            string value = reader.Read();

            while (value == string.Empty && depth <= maxDepth)
            {
                depth++;
                value = reader.Read();
            }

            if (depth <= maxDepth)
            {
                string name = value;

                switch (depth)
                {
                    case 1:
                        {
                            item = new Enterprise(name);
                            break;
                        }
                    case 2:
                        {
                            item = new Site(name);
                            break;
                        }
                    case 3:
                        {
                            item = new Area(name);
                            break;
                        }
                    case 4:
                        {
                            item = new WorkCentre(name);
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException("Maximum depth currently supported is 4");
                        }
                }
                history[depth] = item;
                Item parent = history[depth - 1];
                if (parent == null)
                {
                    string message = string.Format("Unable to add {0} at Level {1} as there is no parent.", item,
                                                   depth);
                    throw new InvalidOperationException(message);
                }
                parent.AddItem(item);
            }
            else
            {
                reader.MoveTo(row, 1);
                if (!reader.IsEndOfData())
                {
                    string message = string.Format("Unable to read item from row {0}", row);
                    throw new InvalidOperationException(message);
                }
            }
        

            return item;
        }

        private int ValidateHeader(IWorksheetReader worksheetReader)
        {
            worksheetReader.MoveTo("A1");
            int depth = 0;

            foreach (string expected in header)
            {
                string address = worksheetReader.GetCurrentCell().Address;
                string column = worksheetReader.Read();
                if (column == string.Empty)
                {
                    return depth;
                }

                if (column != expected)
                {
                    string message = string.Format("Invalid header at {0}: Expected: '{1}' Actual: '{2}'", address, expected, column);
                    throw new InvalidOperationException(message);
                }
                depth++;
            }
            if (depth == 9)
            {
                List<string> nextColumns = worksheetReader.ReadRow();
                {
                    if (nextColumns.Count > 0)
                    {
                        string message = string.Format("Invalid header. No more columns expected but found {0}",
                                                       string.Join(",", nextColumns));
                        throw new InvalidOperationException(message);
                    }
                }
            }
            return depth;
        }

    }
}