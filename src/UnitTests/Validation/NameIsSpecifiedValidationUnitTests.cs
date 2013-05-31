using System;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Validation
{
    [TestFixture]
    public class NameIsSpecifiedValidationUnitTests : TestFixture
    {
         [Test]
         public void ValidateNullItem()
         {
             ValidationMessages messages = new ValidationMessages();
             
             NameIsSpecifiedValidation validation = new NameIsSpecifiedValidation(messages);
             Assert.Throws<ArgumentNullException>(() => validation.Validate(null));
         }

         [Test]
         public void ValidateWithName()
         {
             ValidationMessages messages = new ValidationMessages();

             NameIsSpecifiedValidation validation = new NameIsSpecifiedValidation(messages);

             Enterprise enterprise = new Enterprise();

             Assert.That(validation.Validate(enterprise), Is.True);
             Assert.That(messages, Is.Empty);
         }

         [Test]
         public void ValidateWithEmptyName()
         {
             ValidationMessages messages = new ValidationMessages();

             NameIsSpecifiedValidation validation = new NameIsSpecifiedValidation(messages);

             Enterprise enterprise = new Enterprise {name = ""};

             Assert.That(validation.Validate(enterprise), Is.False);
             Assert.That(messages.Count, Is.EqualTo(1));
             Assert.That(messages[0].Message, Is.StringContaining("Name"));
         }


    }
}