using AmplaTools.ProjectCreate.Editor.Events;
using AmplaTools.ProjectCreate.Editor.Messages;
using AmplaTools.ProjectCreate.Editor.Messages.Menu;
using AmplaTools.ProjectCreate.Editor.Messages.Project;
using AmplaTools.ProjectCreate.Editor.Models;
using AmplaTools.ProjectCreate.Editor.Views;
using AmplaTools.ProjectCreate.Framework;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;
using AmplaTools.ProjectCreate.Messages.Configuration;


namespace AmplaTools.ProjectCreate.Editor.Presenters
{
    public class EditorPresenter :
        Presenter<IEditorView, EditorModel>,
        IListener<NewProjectMessage>,
        IPublisher<ProjectChangedMessage>,
        IListener<AddItemMessage>,
        IListener<LogMessage>,
        IListener<ProjectChangedMessage>,
        IMainPresenter
    {
        public EditorPresenter(EditorMenuPresenter presenter, IEditorView view, EditorModel model, IEventAggregator eventAggregator)
            : base(view, model, eventAggregator)
        {
            ArgumentCheck.IsNotNull(presenter);
            eventAggregator.AddListener(this);
        }

        void IListener<NewProjectMessage>.Handle(NewProjectMessage message)
        {
            EditorModel model = EditorModel.CreateNewModel();

            Model = model;
            Publish(new ProjectChangedMessage());
        }

        public void Publish(ProjectChangedMessage message)
        {
            EventAggregator.SendMessage(message);
        }

        public void Handle(AddItemMessage message)
        {
            Item item = (Item)ActivateHelper.Activate(message.ItemType);
            Model.EquipmentHierarchy.AddItem(item);
            Publish(new ProjectChangedMessage());
        }

        public void Handle(LogMessage message)
        {
            View.ShowMessage(message.Message);
        }

        public object MainView
        {
            get { return View; }
        }

        public void Handle(ProjectChangedMessage message)
        {
            View.ShowModel(Model);
        }
    }
}