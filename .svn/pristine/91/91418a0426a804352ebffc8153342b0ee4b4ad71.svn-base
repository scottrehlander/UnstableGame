using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Unstable
{
    public partial class UnstableGUI : Form
    {
        public UnstableGUI()
        {
            InitializeComponent();
        }

        public void MessageReceived(string msg)
        {
            logwindow.Text += msg +"\r\n";
        }

        private Unstable UnstableServer;

        private void StartServer_Click(object sender, EventArgs e)
        {
            UnstableServer = new Unstable();
            UnstableServer.chat += newChat;
            StartServer.Enabled = false;
            StopServer.Enabled = true;
            logwindow.Text += "Server started.\r\n";
        }

        delegate void setnewChatCallback(string msg);
        private void newChat(string msg)
        {
            if (this.logwindow.InvokeRequired)
            {
                setnewChatCallback d = new setnewChatCallback(newChat);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                this.logwindow.Text += "\r\n" + msg;
                this.logwindow.SelectionStart = this.logwindow.Text.Length;
                this.logwindow.ScrollToCaret();
            }
        }

        private void StopServer_Click(object sender, EventArgs e)
        {
            try
            {
                UnstableServer.Stop();
            }
            catch (Exception x) { return; }

            StartServer.Enabled = true;
            StopServer.Enabled = false;
            logwindow.Text += "Server stopped.\r\n";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void logwindow_TextChanged(object sender, EventArgs e)
        {

        }

        private void UnstableGUI_Load(object sender, EventArgs e)
        {

        }

        private void UnstableGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}