

namespace AmplaTools.ProjectCreate.Editor.Views
{
    public interface IEditorView : IView
    {
        void Close();
        void ShowMessage(string message);
        void Show();
    }
}