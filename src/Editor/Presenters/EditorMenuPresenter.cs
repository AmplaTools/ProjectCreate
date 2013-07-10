using System.Windows.Forms;
using AmplaTools.ProjectCreate.Editor.Events;
using AmplaTools.ProjectCreate.Editor.Messages;
using AmplaTools.ProjectCreate.Editor.Messages.Menu;
using AmplaTools.ProjectCreate.Editor.Models;
using AmplaTools.ProjectCreate.Editor.Views;

namespace AmplaTools.ProjectCreate.Editor.Presenters
{
    public class EditorMenuPresenter :
        Presenter<IEditorMenuView, EditorMenuModel>
        , IListener<AddItemMessage>
        , IListener<HelpAboutMessage>
    {
        public EditorMenuPresenter(IEditorMenuView view, EditorMenuModel model, IEventAggregator eventAggregator)
            : base(view, model, eventAggregator)
        {
            view.InitializeMenu(model.Commands);
        }

        void IListener<AddItemMessage>.Handle(AddItemMessage message)
        {
            EventAggregator.SendMessage(new LogMessage("Add new item: " + message.ItemType.Name));
        }

        void IListener<HelpAboutMessage>.Handle(HelpAboutMessage message)
        {
            MessageBox.Show(@"AmplaTools.ProjectCreate", @"Help About");
        }

    }
}