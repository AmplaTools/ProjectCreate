using System;
using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Validation
{
    [TestFixture]
    public class NameIsSpecifiedValidationUnitTests : ValidationTestFixture<NameIsSpecifiedValidation>
    {

        protected override NameIsSpecifiedValidation Create(ValidationMessages validationMessages)
        {
            return new NameIsSpecifiedValidation(validationMessages);
        }

         [Test]
         public void ValidateNullItem()
         {
             Assert.Throws<ArgumentNullException>(() => Validation.Validate(null));
         }

         [Test]
         public void ValidateWithName()
         {
             Enterprise enterprise = new Enterprise();

             Assert.That(Validation.Validate(enterprise), Is.True);
             Assert.That(Messages, Is.Empty);
         }

         [Test]
         public void ValidateWithEmptyName()
         {
             Enterprise enterprise = new Enterprise {name = ""};

             Assert.That(Validation.Validate(enterprise), Is.False);
             Assert.That(Messages.Count, Is.EqualTo(1));
             Assert.That(Messages[0].Message, Is.StringContaining("Name"));
         }


 
    }
}