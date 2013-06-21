using AmplaTools.ProjectCreate.Editor.Events;
using AmplaTools.ProjectCreate.Editor.Messages;
using AmplaTools.ProjectCreate.Editor.Models;
using AmplaTools.ProjectCreate.Editor.Views;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;
using Autofac;

namespace AmplaTools.ProjectCreate.Editor.Presenters
{
    public class EditorPresenter :
        Presenter<IEditorView, ProjectModel>,
        IListener<NewProjectMessage>,
        IPublisher<ProjectChangedMessage>,
        IListener<AddItemMessage>,
        IListener<LogMessage>,
        IMainPresenter
    {
        public EditorPresenter(EditorMenuPresenter presenter, IEditorView view, ProjectModel model, IEventAggregator eventAggregator)
            : base(view, model, eventAggregator)
        {
            ArgumentCheck.IsNotNull(presenter);
        }

        void IListener<NewProjectMessage>.Handle(NewProjectMessage message)
        {
            ProjectModel model = new ProjectModel
                {
                    Filename = "New Project.xml",
                    Hierarchy = Hierarchy.Empty()
                };

            Model = model;
            Publish(new ProjectChangedMessage());
        }

        public void Publish(ProjectChangedMessage message)
        {
            EventAggregator.SendMessage(message);
        }

        public void Handle(AddItemMessage message)
        {
        }

        public void Handle(LogMessage message)
        {
            View.ShowMessage(message.Message);
        }

        public object MainView
        {
            get { return View; }
        }
    }
}