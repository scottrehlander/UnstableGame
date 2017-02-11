namespace Unstable
{
    partial class UnstableGUI
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
            this.StartServer = new System.Windows.Forms.Button();
            this.StopServer = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.logwindow = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartServer
            // 
            this.StartServer.Location = new System.Drawing.Point(16, 15);
            this.StartServer.Margin = new System.Windows.Forms.Padding(4);
            this.StartServer.Name = "StartServer";
            this.StartServer.Size = new System.Drawing.Size(100, 28);
            this.StartServer.TabIndex = 0;
            this.StartServer.Text = "Start Server";
            this.StartServer.UseVisualStyleBackColor = true;
            this.StartServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // StopServer
            // 
            this.StopServer.Enabled = false;
            this.StopServer.Location = new System.Drawing.Point(16, 50);
            this.StopServer.Margin = new System.Windows.Forms.Padding(4);
            this.StopServer.Name = "StopServer";
            this.StopServer.Size = new System.Drawing.Size(100, 28);
            this.StopServer.TabIndex = 1;
            this.StopServer.Text = "Stop Server";
            this.StopServer.UseVisualStyleBackColor = true;
            this.StopServer.Click += new System.EventHandler(this.StopServer_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(124, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 471);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.logwindow);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(807, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "LogWindow";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // logwindow
            // 
            this.logwindow.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.logwindow.Location = new System.Drawing.Point(8, 11);
            this.logwindow.Margin = new System.Windows.Forms.Padding(4);
            this.logwindow.MaxLength = 300;
            this.logwindow.Multiline = true;
            this.logwindow.Name = "logwindow";
            this.logwindow.ReadOnly = true;
            this.logwindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logwindow.Size = new System.Drawing.Size(787, 420);
            this.logwindow.TabIndex = 0;
            this.logwindow.TextChanged += new System.EventHandler(this.logwindow_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(807, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Other";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UnstableGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 501);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.StopServer);
            this.Controls.Add(this.StartServer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UnstableGUI";
            this.Text = "ServerGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UnstableGUI_FormClosed);
            this.Load += new System.EventHandler(this.UnstableGUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartServer;
        private System.Windows.Forms.Button StopServer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox logwindow;
    }
}

