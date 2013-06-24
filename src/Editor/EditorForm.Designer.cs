namespace AmplaTools.ProjectCreate.Editor
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(284, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.CausesValidation = false;
            this.listBoxMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.Location = new System.Drawing.Point(0, 119);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(284, 121);
            this.listBoxMessages.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 240);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusMessage
            // 
            this.toolStripStatusMessage.Name = "toolStripStatusMessage";
            this.toolStripStatusMessage.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusMessage.Text = "<Messages/>";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxModel.Enabled = false;
            this.textBoxModel.Location = new System.Drawing.Point(0, 24);
            this.textBoxModel.Multiline = true;
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(284, 95);
            this.textBoxModel.TabIndex = 3;
            this.textBoxModel.Text = "<xml/>";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.listBoxMessages);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuMain;
            this.Name = "EditorForm";
            this.Text = "Ampla Tools Editor";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ListBox listBoxMessages;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusMessage;
        private System.Windows.Forms.TextBox textBoxModel;

    }
}

