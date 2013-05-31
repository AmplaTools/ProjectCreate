using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Validation
{
    public interface IValidation
    {
        bool Validate(IItem item);
    }
}