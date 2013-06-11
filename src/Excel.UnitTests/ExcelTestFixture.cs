using AmplaTools.ProjectCreate.Excel.UnitTests.Helper;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Excel.UnitTests
{
    [TestFixture]
    public class ExcelTestFixture : TestFixture
    {
        protected override void OnFixtureSetUp()
        {
            base.OnFixtureSetUp();
            string directory = @"Files\" + GetType().Name;
            TempDirectory = new TempDirectory(directory, "UnitTest_{0:00}.xlsx");
            TempDirectory.DeleteAllFiles();
        }

        protected override void OnSetUp()
        {
            base.OnSetUp();
            Filename = TempDirectory.GetNextTemporaryFile();
        }

        protected string Filename { get; private set; }
    
        protected TempDirectory TempDirectory { get; private set; }
    }
}