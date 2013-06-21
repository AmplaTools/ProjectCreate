using AmplaTools.ProjectCreate.Framework;


namespace AmplaTools.ProjectCreate.Validation
{
    public interface IValidation
    {
        bool Validate(IItem item);
    }
}