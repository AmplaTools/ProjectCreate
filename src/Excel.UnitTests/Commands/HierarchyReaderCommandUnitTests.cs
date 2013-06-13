using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Excel.Commands;
using AmplaTools.ProjectCreate.Excel.Writer;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests.Commands
{
    [TestFixture]
    public class HierarchyReaderCommandUnitTests : ExcelTestFixture
    {
        private readonly List<string> header = new List<string>
            {
                "Depth", "Type","Class",
                "Level 1","Level 2","Level 3",
                "Level 4","Level 5","Level 6",
                "Level 7","Level 8","Level 9"
            };
        
        [Test]
        public void ReadNoHeader()
        {
            using (SetupWorksheet("Hierarchy"))
            {
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (HierarchyReaderCommand command = new HierarchyReaderCommand(spreadsheet, hierarchy))
                {
                    Assert.Throws<InvalidOperationException>(command.Execute);                    
                }
            }
        }

        [Test]
        public void ReadInvalidDepth()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(header);
                WriteRow(writer, "A2", 10, "Enterprise", "", "My Enterprise");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (HierarchyReaderCommand command = new HierarchyReaderCommand(spreadsheet, hierarchy))
                {
                    Assert.Throws<InvalidOperationException>(command.Execute);
                }
            }
        }

        [Test]
        public void ReadEmpty()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(header);
            }
            
            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (HierarchyReaderCommand command = new HierarchyReaderCommand(spreadsheet, hierarchy))
                {
                    command.Execute();
                }

                Assert.That(hierarchy, Is.Not.Null);
                Assert.That(hierarchy.Enterprise, Is.Null);
                Assert.That(hierarchy.GetCount(), Is.EqualTo(0));
            }
        }

        [Test]
        public void ReadEnterprise()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(header);
                WriteRow(writer, "A2", 1, "Enterprise", "", "My Enterprise");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (HierarchyReaderCommand command = new HierarchyReaderCommand(spreadsheet, hierarchy))
                {
                    command.Execute();
                }

                Assert.That(hierarchy, Is.Not.Null);
                Assert.That(hierarchy.Enterprise, Is.Not.Null);
                Assert.That(hierarchy.Enterprise.Name, Is.EqualTo("My Enterprise"));
                Assert.That(hierarchy.GetCount(), Is.EqualTo(1));
            }
        }
        [Test]
        public void ReadEnterpriseSite()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(header);
                WriteRow(writer, "A2", 1, "Enterprise", "", "My Enterprise");
                WriteRow(writer, "A3", 2, "Site", "", "My Site");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (HierarchyReaderCommand command = new HierarchyReaderCommand(spreadsheet, hierarchy))
                {
                    command.Execute();
                }

                Assert.That(hierarchy, Is.Not.Null);
                Assert.That(hierarchy.GetCount(), Is.EqualTo(2));
                Assert.That(hierarchy.Enterprise, Is.Not.Null);
                Assert.That(hierarchy.Enterprise.Name, Is.EqualTo("My Enterprise"));
                Assert.That(hierarchy.Enterprise.Site, Is.Not.Empty);
                Assert.That(hierarchy.Enterprise.Site[0].Name, Is.EqualTo("My Site"));
            }
        }

        [Test]
        public void ReadEnterpriseSiteArea()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(header);
                WriteRow(writer, "A2", 1, "Enterprise", "", "My Enterprise");
                WriteRow(writer, "A3", 2, "Site", "", "My Site");
                WriteRow(writer, "A4", 3, "Area", "", "My Area");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (HierarchyReaderCommand command = new HierarchyReaderCommand(spreadsheet, hierarchy))
                {
                    command.Execute();
                }

                Assert.That(hierarchy, Is.Not.Null);
                Assert.That(hierarchy.GetCount(), Is.EqualTo(3));
                Assert.That(hierarchy.Enterprise, Is.Not.Null);
                Assert.That(hierarchy.Enterprise.Name, Is.EqualTo("My Enterprise"));
                Assert.That(hierarchy.Enterprise.Site, Is.Not.Empty);
                Assert.That(hierarchy.Enterprise.Site.Count, Is.EqualTo(1));
                Assert.That(hierarchy.Enterprise.Site[0].Name, Is.EqualTo("My Site"));
                Assert.That(hierarchy.Enterprise.Site[0].Area, Is.Not.Empty);
                Assert.That(hierarchy.Enterprise.Site[0].Area[0].Name, Is.EqualTo("My Area"));
                Assert.That(hierarchy.Enterprise.Site[0].Area[0].Area1, Is.Empty);
            }
        }

        [Test]
        public void Read2SitesWithAreas()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(header);
                WriteRow(writer, "A2", 1, "Enterprise", "", "My Enterprise");
                WriteRow(writer, "A3", 2, "Site", "", "Site 1");
                WriteRow(writer, "A4", 3, "Area", "", "Area A");
                WriteRow(writer, "A5", 2, "Site", "", "Site 2");
                WriteRow(writer, "A6", 3, "Area", "", "Area B");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (HierarchyReaderCommand command = new HierarchyReaderCommand(spreadsheet, hierarchy))
                {
                    command.Execute();
                }

                Assert.That(hierarchy, Is.Not.Null);
                Assert.That(hierarchy.GetCount(), Is.EqualTo(5));
                Assert.That(hierarchy.Enterprise.FullName, Is.EqualTo("My Enterprise"));
                Assert.That(hierarchy.Enterprise.Site[0].FullName, Is.EqualTo("My Enterprise.Site 1"));
                Assert.That(hierarchy.Enterprise.Site[0].Area[0].FullName, Is.EqualTo("My Enterprise.Site 1.Area A"));
                Assert.That(hierarchy.Enterprise.Site[1].FullName, Is.EqualTo("My Enterprise.Site 2"));
                Assert.That(hierarchy.Enterprise.Site[1].Area[0].FullName, Is.EqualTo("My Enterprise.Site 2.Area B"));
            }
        }

        private static void WriteRow(IWorksheetWriter writer, string address, int depth, string isa95Type, string isa95Class, string name)
        {
            writer.MoveTo(address);
            writer.Write(depth.ToString("0"));
            writer.Write(isa95Type);
            writer.Write(isa95Class);
            for (int i = 1; i < depth; i++)
            {
                writer.Write("");
            }
            writer.Write(name);
        }
    }
}