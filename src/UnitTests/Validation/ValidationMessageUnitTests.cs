using System;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Validation
{
    [TestFixture]
    public class ValidationMessageUnitTests : TestFixture
    {
        [Test]
        public void MessageSetInConstructor()
        {
            const string message = "This is a validation message";
            ValidationMessage vm = new ValidationMessage(message);
            Assert.That(vm.Message, Is.EqualTo(message));
        }

        [Test]
        public void ToStringShowsMessage()
        {
            const string message = "This is a message";
            ValidationMessage vm = new ValidationMessage(message);
            string toString = vm.ToString();
            Assert.That(toString, Is.StringContaining(message));
        }

        [Test]
        public void NullOrEmptyMessage()
        {
            Assert.Throws<ArgumentNullException>(() => new ValidationMessage(null), "Null message");
            Assert.Throws<ArgumentException>(() => new ValidationMessage(string.Empty), "Empty message");
        }
    }
}