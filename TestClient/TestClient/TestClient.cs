using System;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestClient
{
    public partial class TestClient : Form
    {
        jabber.client.JabberClient jc;

        public TestClient()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jc = new jabber.client.JabberClient();
            jc.OnMessage += new jabber.client.MessageHandler(jabberClient1_OnMessage);
            jc.OnAuthenticate += new bedrock.ObjectHandler(jc_OnAuthenticate);
            jc.OnAuthError += new jabber.protocol.ProtocolHandler(jc_OnAuthError);
            jc.OnBeforePresenceOut += new jabber.client.PresenceHandler(jc_OnBeforePresenceOut);
            jc.OnConnect += new jabber.connection.StanzaStreamHandler(jc_OnConnect);
            jc.OnDisconnect += new bedrock.ObjectHandler(jc_OnDisconnect);
            jc.OnError += new bedrock.ExceptionHandler(jc_OnError);
            jc.OnInvalidCertificate += new System.Net.Security.RemoteCertificateValidationCallback(jc_OnInvalidCertificate);
            jc.OnIQ += new jabber.client.IQHandler(jc_OnIQ);
            jc.OnLoginRequired += new bedrock.ObjectHandler(jc_OnLoginRequired);
            jc.OnPresence += new jabber.client.PresenceHandler(jc_OnPresence);
            jc.OnProtocol += new jabber.protocol.ProtocolHandler(jc_OnProtocol);
            jc.OnReadText += new bedrock.TextHandler(jc_OnReadText);
            jc.OnRegistered += new jabber.client.IQHandler(jc_OnRegistered);
            jc.OnRegisterInfo += new jabber.client.RegisterInfoHandler(jc_OnRegisterInfo);
            jc.OnStreamError += new jabber.protocol.ProtocolHandler(jc_OnStreamError);
            jc.OnStreamHeader += new jabber.protocol.ProtocolHandler(jc_OnStreamHeader);
            jc.OnStreamInit += new jabber.connection.StreamHandler(jc_OnStreamInit);
            jc.OnWriteText += new bedrock.TextHandler(jc_OnWriteText);
        }

        void jc_OnWriteText(object sender, string txt)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnWriteText: " + txt + Environment.NewLine;
                }));
            }

        }

        void jc_OnStreamInit(object sender, jabber.protocol.ElementStream stream)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnStreamInit" + Environment.NewLine;
                }));
            }

        }

        void jc_OnStreamHeader(object sender, System.Xml.XmlElement rp)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnStreamHeader" + Environment.NewLine;
                }));
            }

        }

        void jc_OnStreamError(object sender, System.Xml.XmlElement rp)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnStreamError" + Environment.NewLine;
                }));
            }

        }

        bool jc_OnRegisterInfo(object sender, jabber.protocol.iq.Register register)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnRegisterInfo" + Environment.NewLine;
                }));
            }
            return true;
        }

        void jc_OnRegistered(object sender, jabber.protocol.client.IQ iq)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnRegistered" + Environment.NewLine;
                }));
            }
  
        }

        void jc_OnReadText(object sender, string txt)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnReadText: " + txt + Environment.NewLine;
                }));
            }

        }

        void jc_OnProtocol(object sender, System.Xml.XmlElement rp)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnProtocol" + Environment.NewLine;
                }));
            }

        }

        void jc_OnPresence(object sender, jabber.protocol.client.Presence pres)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnPresence" + Environment.NewLine;
                }));
            }

        }

        void jc_OnLoginRequired(object sender)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnLoginRequired" + Environment.NewLine;
                }));
            }

        }

        void jc_OnIQ(object sender, jabber.protocol.client.IQ iq)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnIQ" + Environment.NewLine;
                }));
            }
            
        }

        bool jc_OnInvalidCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnInvalidCertificate" + Environment.NewLine;
                }));
            }
    
            return true;
        }

        void jc_OnError(object sender, Exception ex)
        {
            
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnError: " + ex.Message + Environment.NewLine;
                }));
            }
        }

        void jc_OnDisconnect(object sender)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnDisconnect" + Environment.NewLine;
                }));
            }
        }

        void jc_OnConnect(object sender, jabber.connection.StanzaStream stream)
        {
             if(InvokeRequired)        
             {            
                 this.Invoke(new MethodInvoker(delegate {
                     this.txbxLOGWINDOW.Text += "OnConnect" + Environment.NewLine;
                 }));                
             }
        }

        void jc_OnBeforePresenceOut(object sender, jabber.protocol.client.Presence pres)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnBeforePresenceOut" + Environment.NewLine;
                }));
            }
        }

        void jc_OnAuthError(object sender, System.Xml.XmlElement rp)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnAuthError" + Environment.NewLine;
                }));
            }

        }

        void jc_OnAuthenticate(object sender)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "OnAuthenticate" + Environment.NewLine;
                }));
            }

        }

        private void btnCONNECT_Click(object sender, EventArgs e)
        {
            try
            {
                jc.Port = Convert.ToInt32(txbxPORT.Text);
                jc.NetworkHost = txbxIP.Text;
                jc.User = txbxUser.Text;
                jc.Password = txbxPassword.Text;
                jc.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // public delegate void MessageHandler(object sender, Message msg);
        private void jabberClient1_OnMessage(object sender, jabber.protocol.client.Message msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.txbxLOGWINDOW.Text += "Message Received: " + msg + Environment.NewLine;
                }));
            }
        }


        private void btnDISCONNECT_Click(object sender, EventArgs e)
        {
            try
            {   
                jc.Close();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSEND_Click(object sender, EventArgs e)
        {
            try
            {
                if (jc != null)
                {
                    jabber.protocol.client.Message msg = new jabber.protocol.client.Message(jc.Document);
                    msg.Body = txbxINPUT.Text;
                    msg.To = txbxTo.Text;
                    jc.Write(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            jc.Login();
        }

        private void txbxLOGWINDOW_TextChanged(object sender, EventArgs e)
        {
            txbxLOGWINDOW.SelectionStart = txbxLOGWINDOW.Text.Length;
            txbxLOGWINDOW.ScrollToCaret();
            txbxLOGWINDOW.Refresh();
        }
    }
}