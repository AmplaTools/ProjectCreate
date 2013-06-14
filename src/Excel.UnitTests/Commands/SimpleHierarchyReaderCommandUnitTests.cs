using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Commands;
using AmplaTools.ProjectCreate.Excel.Commands;
using AmplaTools.ProjectCreate.Excel.Writer;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests.Commands
{
    [TestFixture]
    public class SimpleHierarchyReaderCommandUnitTests : ExcelTestFixture
    {
        private readonly List<string> header = new List<string>
            {
                "Level 1","Level 2","Level 3",
                "Level 4","Level 5","Level 6",
                "Level 7","Level 8","Level 9"
            };

        private ICommand CreateCommand(IExcelSpreadsheet spreadsheet, Hierarchy hierarchy)
        {
            return new SimpleHierarchyReaderCommand(spreadsheet, hierarchy);
        }

        [Test]
        public void ReadNoHeader()
        {
            using (SetupWorksheet("Hierarchy"))
            {
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
                {
                    Exception ex = Assert.Throws<InvalidOperationException>(command.Execute);
                    Assert.That(ex.Message, Is.StringContaining("spreadsheet is empty"));
                }
            }
        }

        [Test]
        public void ReadInvalidDepth()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(header);
                WriteRow(writer, "A2", "","","", "My Enterprise");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
                {
                    Exception ex = Assert.Throws<InvalidOperationException>(command.Execute);
                    Assert.That(ex.Message, Is.StringContaining("My Enterprise").And.StringContaining("Level 4"));
                }
            }
        }

        [Test]
        public void HeaderWithExtraColumns()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(new List<string> { "Level 1", "Level 2", "Extra 1", "Extra 2"});
                WriteRow(writer, "A2","My Enterprise");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
                {
                    Exception ex = Assert.Throws<InvalidOperationException>(command.Execute);
                    Assert.That(ex.Message, Is.StringContaining("Extra 1").And.StringContaining("Level 3"));
                }
            }
        }

        [Test]
        public void HeaderWithIncorrectNames()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(new List<string> { "Column 1", "Column 2", "Column 3", "Column 4" });
                WriteRow(writer, "A2", "My Enterprise");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
                {
                    Exception ex = Assert.Throws<InvalidOperationException>(command.Execute);
                    Assert.That(ex.Message, Is.StringContaining("Column 1").And.StringContaining("Level 1"));
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
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
                {
                    command.Execute();
                }

                Assert.That(hierarchy, Is.Not.Null);
                Assert.That(hierarchy.Enterprise, Is.Null);
                Assert.That(hierarchy.GetCount(), Is.EqualTo(0));
            }
        }

        [Test]
        public void Level2HeaderEnterpriseOnly()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(new List<string>{"Level 1", "Level 2"});
                WriteRow(writer, "A2", "My Enterprise");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
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
        public void Level2HeaderWithGreaterDepth()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(new List<string> { "Level 1", "Level 2" });
                WriteRow(writer, "A2", "My Enterprise");
                WriteRow(writer, "A3", "", "My Site");
                WriteRow(writer, "A4", "", "", "My Area");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
                {
                    Exception ex = Assert.Throws<InvalidOperationException>(command.Execute);
                    Assert.That(ex.Message, Is.StringContaining("row 4"));
                }
            }
        }

        [Test]
        public void ReadEnterprise()
        {
            using (IWorksheetWriter writer = SetupWorksheet("Hierarchy"))
            {
                writer.WriteRow(header);
                WriteRow(writer, "A2", "My Enterprise");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
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
                WriteRow(writer, "A2", "My Enterprise");
                WriteRow(writer, "A3", "", "My Site");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
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
                WriteRow(writer, "A2", "My Enterprise");
                WriteRow(writer, "A3", "", "My Site");
                WriteRow(writer, "A4", "","", "My Area");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
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
                WriteRow(writer, "A2", "My Enterprise");
                WriteRow(writer, "A3", "", "Site 1");
                WriteRow(writer, "A4", "", "", "Area A");
                WriteRow(writer, "A5", "", "Site 2");
                WriteRow(writer, "A6", "", "", "Area B");
            }

            using (IExcelSpreadsheet spreadsheet = ExcelSpreadsheet.OpenReadOnly(Filename))
            {
                Hierarchy hierarchy = Hierarchy.Empty();
                using (ICommand command = CreateCommand(spreadsheet, hierarchy))
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

        private static void WriteRow(IWorksheetWriter writer, string address, params string[] values)
        {
            writer.MoveTo(address);
            foreach (string value in values)
            {
                writer.Write(value);
            }
        }
    }
}