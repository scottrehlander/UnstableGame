using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Unstable
{
    /*
     * 
     * 
     * 
     * 
     */
    class Unstable
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UnstableGUI());
        }
       

        public static bool running = false;
        System.Threading.Thread serverinstance;

        public delegate void LogMsgReceivedHandler(string message);
        public event LogMsgReceivedHandler chat;
        private void logMsgeceived(string msg)
        {
            if (chat!= null)
            {
                chat(msg);
            }
        }


        Router RTMgr;
        ClientManager CLMgr;
        AIManager AIMgr;

        public Unstable()
        {
            serverinstance = new System.Threading.Thread(ServerLoop);
            serverinstance.Start();
        }

        public void ServerLoop()
        {
            try
            {
                running = true;
                CLMgr = new ClientManager();
                RTMgr = new Router();
                AIMgr = new AIManager();
                // Create managers here
                List<IManager> allmanagers = new List<IManager>();
                allmanagers.Add(RTMgr);
                allmanagers.Add(CLMgr);
                allmanagers.Add(AIMgr);

                CLMgr.Start();
                Queue<IMessage> msgsFromCLMgr = new Queue<IMessage>();
                Queue<IMessage> msgsToCLMgr = new Queue<IMessage>();
                Queue<IMessage> msgsFromAIMgr = new Queue<IMessage>();
                Queue<IMessage> msgsToAIMgr = new Queue<IMessage>();

                while (running == true)
                {
                    // Check for client connections
                    // Spawn client threads
                    msgsFromCLMgr = CLMgr.MsgsFromMgr();
                    msgsFromAIMgr = AIMgr.MsgsFromMgr();
                    // Receive Client Messages
                    try
                    {
                        for (int i =0;i<allmanagers.Count;i++)
                        {
                            IManager dmgr = allmanagers[i];
                            Queue<IMessage> dmsgs = dmgr.GetDebugMessages();
                            while (dmsgs.Count > 0)
                            {
                                IMessage tmsg = dmsgs.Dequeue();
                                chat("DEBUG " + dmgr.GetType().ToString() + ":" + tmsg.GetType().ToString() + ":  " + tmsg.GetPayload());
                            }
                        }
                    }
                    catch (Exception x) { chat("Exception in serverloop debug fetch: " + x.Message); }
                    // Pass Messages from clients to router
                    RTMgr.MsgsToMgr(msgsFromCLMgr);
                    // Pass Messages from router to clients
                    msgsToCLMgr = RTMgr.MsgsFromMgr();

                    CLMgr.MsgsToMgr(msgsToCLMgr);
                    AIMgr.MsgsToMgr(msgsToAIMgr);
                }

                CleanupManagers(); // Free up manager resources
            }
            catch (Exception ex)
            {
                chat("Exception in main server loop: " + ex.Message);
                CleanupManagers();
                // We should have a safe stop signal, but for now this should be okay.
                if (ex is System.Threading.ThreadAbortException)
                {
                    return;
                }
            }
        }


        // Free up manager resources
        private void CleanupManagers()
        {
            if (CLMgr != null)
            {
                CLMgr.Dispose();
                CLMgr = null;
            }
        }

        // Stop the Server
        public void Stop()
        {
            running = false;
            System.Threading.Thread.Sleep(33);
            Application.DoEvents();
            // should issue safe stop signal at some point
            serverinstance.Abort();
        }
    }
}
