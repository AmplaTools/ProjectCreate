using AmplaTools.ProjectCreate.Editor.Events;
using AmplaTools.ProjectCreate.Editor.Models;
using AmplaTools.ProjectCreate.Editor.Views;

namespace AmplaTools.ProjectCreate.Editor.Presenters
{
    public class OpenFilePresenter : Presenter<IFileView, FileModel>
    {
        public OpenFilePresenter(IFileView view, FileModel model, IEventAggregator eventAggregator)
            : base(view, model, eventAggregator)
        {
        }
    }
}