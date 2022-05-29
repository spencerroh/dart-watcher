namespace dart_watcher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uiKeywords = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.uiKeyword = new System.Windows.Forms.TextBox();
            this.uiNotificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.uiIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiKeywords
            // 
            this.uiKeywords.FormattingEnabled = true;
            this.uiKeywords.ItemHeight = 15;
            this.uiKeywords.Location = new System.Drawing.Point(12, 38);
            this.uiKeywords.Name = "uiKeywords";
            this.uiKeywords.Size = new System.Drawing.Size(207, 139);
            this.uiKeywords.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "검색 키워드";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnKeywordAdded);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnKeywordRemoved);
            // 
            // uiKeyword
            // 
            this.uiKeyword.Location = new System.Drawing.Point(12, 183);
            this.uiKeyword.Name = "uiKeyword";
            this.uiKeyword.Size = new System.Drawing.Size(207, 23);
            this.uiKeyword.TabIndex = 5;
            this.uiKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeywordEntered);
            // 
            // uiNotificationIcon
            // 
            this.uiNotificationIcon.ContextMenuStrip = this.uiIconMenu;
            this.uiNotificationIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("uiNotificationIcon.Icon")));
            this.uiNotificationIcon.Text = "빠른 공시 알림";
            this.uiNotificationIcon.Visible = true;
            // 
            // uiIconMenu
            // 
            this.uiIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.uiIconMenu.Name = "uiIconMenu";
            this.uiIconMenu.Size = new System.Drawing.Size(99, 48);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 249);
            this.Controls.Add(this.uiKeyword);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiKeywords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "빠른 공시 알림";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.uiIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uiKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox uiKeyword;
        private System.Windows.Forms.NotifyIcon uiNotificationIcon;
        private System.Windows.Forms.ContextMenuStrip uiIconMenu;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
    }
}
