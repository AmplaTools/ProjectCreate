using System.Windows.Forms;
using AmplaTools.ProjectCreate.Editor.Events;
using AmplaTools.ProjectCreate.Editor.Messages.Project;
using AmplaTools.ProjectCreate.Editor.Views;

namespace AmplaTools.ProjectCreate.Editor.Controls
{
    public partial class FileTabPage : TabPage, IFileContentView
    {
        private IEventPublisher eventPublisher;

        public FileTabPage() : base("Project")
        {
            InitializeComponent();
        }

        public void SetEventPublisher(IEventPublisher publisher)
        {
            eventPublisher = publisher;
        }

        public string Filename
        {
            get { return linkFilename.Text; }
            set { linkFilename.Text = value; }
        }

        public void OpenFile()
        {
            eventPublisher.SendMessage(new ViewFileMessage { Filename = Filename });
        }

        public void ShowView()
        {
            Enabled = true;
            Show();
        }

        public string Contents
        {
            get { return textBoxContents.Text; } 
            set { textBoxContents.Text = value; }
        }
    }
}