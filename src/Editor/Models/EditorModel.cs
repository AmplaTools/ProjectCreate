
using AmplaTools.ProjectCreate.Messages;
using AmplaTools.ProjectCreate.Messages.Configuration;

namespace AmplaTools.ProjectCreate.Editor.Models
{
    public class EditorModel : IModel
    {
        public string Filename { get; private set; }

        public ProjectMaster Project { get; private set; }

        public Hierarchy EquipmentHierarchy { get; private set; }

        public static EditorModel CreateNewModel()
        {
            EditorModel model = new EditorModel
                {
                    Filename = "Project.xml",
                    EquipmentHierarchy = Hierarchy.Empty(),
                    Project = ProjectMaster.NewProject()
                };
            return model;
        }
    }
}