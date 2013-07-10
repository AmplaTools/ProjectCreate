namespace AmplaTools.ProjectCreate.Editor.Views
{
    public interface IModelView<in TModel> : IView
    {
        void SetModel(TModel model);
    }
}