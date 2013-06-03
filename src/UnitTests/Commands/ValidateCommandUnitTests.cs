using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;
using AmplaTools.ProjectCreate.Validation;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Commands
{
    [TestFixture]
    public class ValidateCommandUnitTests : TestFixture
    {
        [Test]
        public void ValidateAllMethods()
        {
            Hierarchy hierarchy = HierarchyHelper.CreateDefaultHierarchy();

            ValidationMessages messages = new ValidationMessages();
            hierarchy.Enterprise.Site.Add(new Site { name = "Site X" });
            hierarchy.Enterprise.Site.Add(new Site { name = "Site X" });

            ValidateCommand command = new ValidateCommand(hierarchy, messages);
            command.Execute();
            Assert.That(messages, Is.Not.Empty);
            Assert.That(messages.Count, Is.EqualTo(1));
            Assert.That(messages[0].Message, Is.StringContaining("Site X"));
        }
    }
}