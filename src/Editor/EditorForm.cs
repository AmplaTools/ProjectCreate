
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AmplaTools.ProjectCreate.Editor.Events;

using AmplaTools.ProjectCreate.Editor.Messages;
using AmplaTools.ProjectCreate.Editor.Models;
using AmplaTools.ProjectCreate.Editor.Views;


namespace AmplaTools.ProjectCreate.Editor
{
    public partial class EditorForm : Form, IEditorView, IEditorMenuView
    {
        private IEventAggregator eventAggregator;

        public EditorForm()
        {
            InitializeComponent();
        }

        void IView.SetEventAggregator(IEventAggregator aggregator)
        {
            eventAggregator = aggregator;
        }

        public void InitializeMenu(List<MenuCommand> commands)
        {
            foreach (MenuCommand command in commands)
            {
                ToolStripMenuItem category = GetCategoryMenu(command.Category);

                Func<IMessage> action = command.Message;
                string text = command.Label;
                EventHandler handler = (o, e) => eventAggregator.SendMessage(action());
                category.DropDownItems.Add(text, null, handler);
            }
            
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
    }
}
