namespace AmplaTools.ProjectCreate.Editor.Controls
{
    public partial class FileTabPage
    {       
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.linkFilename = new System.Windows.Forms.LinkLabel();
            this.textBoxContents = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.linkFilename);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(200, 21);
            this.panelTop.TabIndex = 0;
            // 
            // linkFilename
            // 
            this.linkFilename.AutoSize = true;
            this.linkFilename.Location = new System.Drawing.Point(3, 0);
            this.linkFilename.Name = "linkFilename";
            this.linkFilename.Size = new System.Drawing.Size(64, 13);
            this.linkFilename.TabIndex = 0;
            this.linkFilename.TabStop = true;
            this.linkFilename.Text = "";
            // 
            // textBoxContents
            // 
            this.textBoxContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxContents.Location = new System.Drawing.Point(0, 21);
            this.textBoxContents.Multiline = true;
            this.textBoxContents.Name = "textBoxContents";
            this.textBoxContents.ReadOnly = true;
            this.textBoxContents.Size = new System.Drawing.Size(200, 79);
            this.textBoxContents.TabIndex = 1;
            // 
            // FileTabPage
            // 
            this.Controls.Add(this.textBoxContents);
            this.Controls.Add(this.panelTop);
            this.Name = "FileTabView";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.LinkLabel linkFilename;
        private System.Windows.Forms.TextBox textBoxContents;
    }
}