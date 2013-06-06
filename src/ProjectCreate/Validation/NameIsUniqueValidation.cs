using System.Collections.Generic;
using System.Linq;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Validation
{
    public class NameIsUniqueValidation : ItemValidation
    {
        
        public NameIsUniqueValidation(IValidationMessages validationMessages) : base(validationMessages)
        {
        }

        protected override List<ValidationMessage> OnValidate(IItem item)
        {
            List<ValidationMessage> messages = new List<ValidationMessage>();

            Dictionary<string, bool> childItems = new Dictionary<string, bool>();
            foreach (string name in item.GetItems().Select(child => child.Name))
            {
                bool marker;
                if (childItems.TryGetValue(name, out marker))
                {
                    messages.Add(new ValidationMessage(string.Format("'{0}' is not a unique name for '{1}'", name, item.FullName)));
                }
                childItems[name] = true;
            }

            return messages;
        }
    }
}