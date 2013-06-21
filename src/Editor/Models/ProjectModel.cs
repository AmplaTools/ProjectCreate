using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Editor.Models
{
    public class ProjectModel : IModel
    {
        public string Filename { get; set; }

        public Hierarchy Hierarchy { get; set; }
    }
}