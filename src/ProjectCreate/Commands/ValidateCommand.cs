using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Commands
{
    public class ValidateCommand : ICommand
    {
        private Hierarchy hierarchy;

        public ValidateCommand(Hierarchy hierarchy)
        {
            this.hierarchy = hierarchy;
        }

        public void Execute()
        {
            
        }
    }
}