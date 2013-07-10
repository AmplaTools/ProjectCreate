
namespace AmplaTools.ProjectCreate.Editor.Messages.Project
{
    public class SaveProjectMessage : IMessage
    {
        public string Filename { get; set; }
    }
}