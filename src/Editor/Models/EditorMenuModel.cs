using System.Collections.Generic;
using AmplaTools.ProjectCreate.Editor.Messages;
using AmplaTools.ProjectCreate.Editor.Messages.Menu;
using AmplaTools.ProjectCreate.Editor.Messages.Project;
using AmplaTools.ProjectCreate.Messages;


namespace AmplaTools.ProjectCreate.Editor.Models
{
    public class EditorMenuModel : IModel
    {
        public EditorMenuModel()
        {
            Commands = new List<MenuCommand>
                {
                    MenuCommand.Menu<NewProjectMessage>("New Project", "File"),
                    MenuCommand.Menu<SaveProjectMessage>("Save Project", "File"),
                    MenuCommand.Menu<ExitMessage>("Exit", "File"),
                    
                    MenuCommand.Menu<LoadFromExcelMessage>("Update from Excel", "Excel"),
                    MenuCommand.Menu<SaveProjectToExcelMessage>("Save to Excel", "Excel"),

                    MenuCommand.Menu("Add Enterprise", "Actions", () => new AddItemMessage(typeof(Enterprise))),
                    MenuCommand.Menu("Add Site", "Actions", () => new AddItemMessage(typeof(Site))),
                    MenuCommand.Menu("Add Area", "Actions", () => new AddItemMessage(typeof(Area))),
                    MenuCommand.Menu("Add Work Centre", "Actions", () => new AddItemMessage(typeof(WorkCentre))),
                    MenuCommand.Menu<HelpAboutMessage>("About", "Help")
                };
        }

        public List<MenuCommand> Commands { get; set; }
    }
}