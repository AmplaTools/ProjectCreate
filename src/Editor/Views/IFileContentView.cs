
namespace AmplaTools.ProjectCreate.Editor.Views
{
    public interface IFileContentView : IView
    {
        string Contents { get; set; }
        string Filename { get; set; }
        void OpenFile();
        void ShowView();
    }
}