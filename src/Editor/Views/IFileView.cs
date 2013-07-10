namespace AmplaTools.ProjectCreate.Editor.Views
{
    public interface IFileView: IView
    {
        string Filename { get; set; }
        void Open();
    }
}