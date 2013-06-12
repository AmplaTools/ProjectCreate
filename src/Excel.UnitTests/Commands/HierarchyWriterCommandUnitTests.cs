using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Commands;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests.Commands
{
    [TestFixture]
    public class HierarchyWriterCommandUnitTests : ExcelTestFixture
    {
        private readonly List<string> expectedHeader = new List<string>
            {
                "Depth", "Type","Class",
                "Level 1","Level 2","Level 3",
                "Level 4","Level 5","Level 6",
                "Level 7","Level 8","Level 9"
            };
        
        [Test]
        public void WriteEnterprise()
        {
            Hierarchy hierarchy = new Hierarchy();
            hierarchy.Enterprise = new Enterprise("My Company");
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(Filename))
            {
                HierarchyWriterCommand command = new HierarchyWriterCommand(hierarchy, spreadsheet);
                command.Execute();
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                using (IWorksheetReader reader = spreadsheet.ReadWorksheet("Hierarchy"))
                {
                    reader.MoveTo("A1");
                    Assert.That(reader.ReadRow(), Is.EquivalentTo(expectedHeader));
                    CheckRow(reader, "A2", 1, "Enterprise", string.Empty, "My Company");
                }
            }
        }

        [Test]
        public void WriteEnterpriseSite()
        {
            Hierarchy hierarchy = new Hierarchy();
            hierarchy.Enterprise = new Enterprise("My Company");
            hierarchy.Enterprise.Site.Add(new Site("My Site"));

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(Filename))
            {
                HierarchyWriterCommand command = new HierarchyWriterCommand(hierarchy, spreadsheet);
                command.Execute();
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                using (IWorksheetReader reader = spreadsheet.ReadWorksheet("Hierarchy"))
                {
                    reader.MoveTo("A1");
                    Assert.That(reader.ReadRow(), Is.EquivalentTo(expectedHeader));
                    CheckRow(reader, "A2", 1, "Enterprise", string.Empty, "My Company");
                    CheckRow(reader, "A3", 2, "Site", string.Empty, "My Site");
                }
            }
        }

        [Test]
        public void WriteEnterpriseSiteArea()
        {
            Hierarchy hierarchy = new Hierarchy();
            hierarchy.Enterprise = new Enterprise("My Company");
            hierarchy.Enterprise.Site.Add(new Site("My Site"));
            hierarchy.Enterprise.Site[0].Area.Add(new Area("My Area"));

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.CreateNew(Filename))
            {
                HierarchyWriterCommand command = new HierarchyWriterCommand(hierarchy, spreadsheet);
                command.Execute();
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                using (IWorksheetReader reader = spreadsheet.ReadWorksheet("Hierarchy"))
                {
                    reader.MoveTo("A1");
                    Assert.That(reader.ReadRow(), Is.EquivalentTo(expectedHeader));
                    CheckRow(reader, "A2", 1, "Enterprise", string.Empty, "My Company");
                    CheckRow(reader, "A3", 2, "Site", string.Empty, "My Site");
                    CheckRow(reader, "A4", 3, "Area", string.Empty, "My Area");

                }
            }
        }

        private static void CheckRow(IWorksheetReader reader, string address, int depth, string isa95Type, string isa95Class, string name)
        {
            reader.MoveTo(address);
            Assert.That(reader.Read(), Is.EqualTo(depth.ToString("0")));
            Assert.That(reader.Read(), Is.EqualTo(isa95Type));
            Assert.That(reader.Read(), Is.EqualTo(isa95Class));
            for (int i = 1; i < depth; i++)
            {
                Assert.That(reader.Read(), Is.EqualTo(string.Empty), "Skip level {0}", i);
            }
            Assert.That(reader.Read(), Is.EqualTo(name));
        }
    }
}