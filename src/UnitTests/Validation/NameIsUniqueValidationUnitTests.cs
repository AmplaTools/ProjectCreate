using System;
using System.Collections.Generic;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Validation
{
    [TestFixture]
    public class NameIsUniqueValidationUnitTests : TestFixture
    {
        [Test]
        public void ValidateNullItem()
        {
            ValidationMessages messages = new ValidationMessages();

            NameIsUniqueValidation validation = new NameIsUniqueValidation(messages);
            Assert.Throws<ArgumentNullException>(() => validation.Validate(null));
        }

        [Test]
        public void ValidateWithNoChildren()
        {
            ValidationMessages messages = new ValidationMessages();

            NameIsSpecifiedValidation validation = new NameIsSpecifiedValidation(messages);

            Enterprise enterprise = new Enterprise();

            Assert.That(validation.Validate(enterprise), Is.True);
            Assert.That(messages, Is.Empty);
        }

        [Test]
        public void ValidateWithOneChild()
        {
            ValidationMessages messages = new ValidationMessages();

            NameIsSpecifiedValidation validation = new NameIsSpecifiedValidation(messages);

            Enterprise enterprise = new Enterprise
                {
                    name = "Enterprise",
                    Site = new List<Site> {new Site {name = "Site A"}}
                };

            Assert.That(validation.Validate(enterprise), Is.True);
            Assert.That(messages, Is.Empty);
        }

        [Test]
        public void ValidateWithMultipleChildren()
        {
            ValidationMessages messages = new ValidationMessages();

            NameIsSpecifiedValidation validation = new NameIsSpecifiedValidation(messages);

            Enterprise enterprise = new Enterprise
                {
                    name = "Enterprise",
                    Site = new List<Site>
                        {
                            new Site {name = "Site A"},
                            new Site {name = "Site B"},
                            new Site {name = "Site C"},
                        }
                };

            Assert.That(validation.Validate(enterprise), Is.True);
            Assert.That(messages, Is.Empty);
        }

        [Test]
        public void ValidateWithDuplicateChildren()
        {
            ValidationMessages messages = new ValidationMessages();

            NameIsUniqueValidation validation = new NameIsUniqueValidation(messages);

            Enterprise enterprise = new Enterprise
                {
                    name = "Enterprise",
                    Site = new List<Site>
                        {
                            new Site {name = "Site A"},
                            new Site {name = "Site B"},
                            new Site {name = "Site A"},
                        }
                };

            Assert.That(enterprise.GetCount(), Is.EqualTo(4));

            Assert.That(validation.Validate(enterprise), Is.False);
            Assert.That(messages[0].Message, Is.StringContaining("Site A"));
        }
    }
}