using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;
using System.Collections.Generic;

namespace AmplaTools.ProjectCreate.Validation
{
    public abstract class ItemValidation : IValidation
    {
        private readonly IValidationMessages validationMessages;

        protected ItemValidation(IValidationMessages validationMessages)
        {
            this.validationMessages = validationMessages;
        }

        public bool Validate(IItem item)
        {
            ArgumentCheck.IsNotNull(item);
            List<ValidationMessage> messages = OnValidate(item);

            bool result = messages.Count == 0;
            foreach (ValidationMessage validationMessage in messages)
            {
                validationMessages.Add(validationMessage);
            }
            return result;
        }

        protected abstract List<ValidationMessage> OnValidate(IItem item);
    }
}