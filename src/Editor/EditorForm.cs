
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AmplaTools.ProjectCreate.Editor.Controls;
using AmplaTools.ProjectCreate.Editor.Events;

using AmplaTools.ProjectCreate.Editor.Messages;
using AmplaTools.ProjectCreate.Editor.Messages.Project;
using AmplaTools.ProjectCreate.Editor.Models;
using AmplaTools.ProjectCreate.Editor.Views;
using AmplaTools.ProjectCreate.Helper;


namespace AmplaTools.ProjectCreate.Editor
{
    public partial class EditorForm : Form, IEditorView, IEditorMenuView
    {
        private IEventPublisher eventPublisher;
        private FileTabPage projectPage;
        private FileTabPage hierarchyPage;

        public EditorForm()
        {
            InitializeComponent();
            InitializeViews();
        }

        void IView.SetEventPublisher(IEventPublisher publisher)
        {
            eventPublisher = publisher;
            projectPage.SetEventPublisher(publisher);
            hierarchyPage.SetEventPublisher(publisher);
        }

        public void InitializeMenu(List<MenuCommand> commands)
        {
            foreach (MenuCommand command in commands)
            {
                ToolStripMenuItem category = GetCategoryMenu(command.Category);

                Func<IMessage> action = command.Message;
                string text = command.Label;
                EventHandler handler = (o, e) => eventPublisher.SendMessage(action());
                category.DropDownItems.Add(text, null, handler);
            }
        }

        private void InitializeViews()
        {
            projectPage = new FileTabPage {Text = @"Project", Enabled = false};
            tabViews.TabPages.Add(projectPage);

            hierarchyPage = new FileTabPage {Text = @"Hierarchy", Enabled = false};
            tabViews.TabPages.Add(hierarchyPage);
        }

        private ToolStripMenuItem GetCategoryMenu(string category)
        {
            ToolStripMenuItem categoryMenu = null;
            foreach (object item in menuMain.Items)
            {
                ToolStripMenuItem menu = item as ToolStripMenuItem;
                if (menu != null && menu.Text == category)
                {
                    categoryMenu = menu;
                }
            }
            if (categoryMenu == null)
            {
                categoryMenu = new ToolStripMenuItem(category);
                menuMain.Items.Add(categoryMenu);
            }

            return categoryMenu;
        }

        public void ShowMessage(string message)
        {
            toolStripStatusMessage.Text = message;
        }

        public TView GetChildView<TView>(string viewName) where TView : class
        {
            return (from TabPage page in new [] {projectPage, hierarchyPage} where page.Text == viewName select page as TView).FirstOrDefault();
        }

        public void ShowModel(EditorModel model)
        {
            IFileContentView project = projectPage;
            project.Filename = model.Filename;
            project.Contents = SerializationHelper.SerializeToString(model.Project);
            project.ShowView();

            IFileContentView hierarchy = hierarchyPage;
            hierarchy.Filename = model.Project.Equipment.Hierarchy.href;
            hierarchy.Contents = SerializationHelper.SerializeToString(model.EquipmentHierarchy);
            hierarchy.ShowView();

        }
    }
}
