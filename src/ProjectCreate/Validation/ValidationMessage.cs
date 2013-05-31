using System;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Validation
{
    public class ValidationMessage
    {
        public ValidationMessage(string message)
        {
            ArgumentCheck.IsNotNull(message, "message");
            ArgumentCheck.IsNotEmpty(message, "message");

            Message = message;
        }

        public string Message 
        { 
            get; 
            private set; 
        }

        public override string ToString()
        {
            return string.Format("Validation: '{0}'", Message);
        }
    }
}