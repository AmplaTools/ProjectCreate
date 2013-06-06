using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Messages;
using AmplaTools.ProjectCreate.Validation;

namespace AmplaTools.ProjectCreate.Commands
{
    public class ValidateCommand : ICommand
    {
        private readonly Hierarchy hierarchy;
        private readonly ValidationMessages validationMessages;

        public ValidateCommand(Hierarchy hierarchy, ValidationMessages validationMessages)
        {
            this.hierarchy = hierarchy;
            this.validationMessages = validationMessages;
        }

        public void Execute()
        {
            List<IValidation> validators = new List<IValidation>
                {
                    new NameIsUniqueValidation(validationMessages),
                    new NameIsSpecifiedValidation(validationMessages)
                };

            List<IItem> itemsToValidate = hierarchy.GetDescendants();
            foreach (IItem item in itemsToValidate)
            {
                foreach (IValidation validation in validators)
                {
                    validation.Validate(item);
                }
            }
        }
    }
}