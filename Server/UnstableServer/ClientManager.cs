using System;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unstable
{
    class ClientManager : IManager
    {
        private SortedList<int, Client> clients;
        private System.Threading.Thread connectListener;
        private TcpListener tcpListener;
        int clientcount;

        public Queue<IMessage> debugMessages;

        public Queue<IMessage> GetDebugMessages()
        {
            if (debugMessages != null)
            {
                return debugMessages;
            }
            else return new Queue<IMessage>();
        }

        public bool MsgsToMgr(Queue<IMessage> messages)
        {
            while (messages.Count > 0)
            {
                try
                {
                    IMessage msg = messages.Dequeue();
                    int destid = msg.GetDestID();
                    if(clients.ContainsKey(destid))
                    {
                        clients[destid].OUTmsgs.Enqueue(msg);
                        if (msg is LoginMessage)
                        {
                            if ((msg as LoginMessage).loginID > 0)
                            {
                                // hm....
                                clients[destid].clientID = (msg as LoginMessage).loginID;
                                Client tempcl = clients[destid];
                                clients.Remove(destid);
                                clients.Add(tempcl.clientID, tempcl);
                            }
                        }
                    }
                }
                catch (Exception x)
                {
                    debugMessages.Enqueue(new DebugMessage("Exception in sending Msgs to clients: " + x.Message));
                }
            }

            return true;
        }

        public Queue<IMessage> MsgsFromMgr()
        {
            Queue<IMessage> fromClients = new Queue<IMessage>();
            foreach (Client cli in clients.Values)
            {
                while (cli.INmsgs.Count > 0)
                {
                    IMessage imsg1 = cli.INmsgs.Dequeue();
                    fromClients.Enqueue(imsg1);
                }
            }
            return fromClients;
        }

        public ClientManager()
        {
            Unstable.running = true;
            clientcount = 0;
            debugMessages = new Queue<IMessage>();
            clients = new SortedList<int,Client>();
            this.tcpListener = new TcpListener(IPAddress.Any, 6969);
        }

        public void Dispose()
        {
            if (connectListener != null)
            {
                this.tcpListener.Stop();
                connectListener.Abort();
                connectListener = null;
            }
            for (int i = 0; i< clients.Count  ;i++)
            {
                clients[i] = null;
            }
        }

        public void Start()
        {
            this.tcpListener.Start();
            connectListener = new System.Threading.Thread(AcceptClients);
            connectListener.Start();
        }

        private void AcceptClients()
        {
            try
            {
                while (Unstable.running)
                {
                    // Wait for a new client to connect
                    TcpClient newtcpclient = this.tcpListener.AcceptTcpClient();
                    
                    string ep = newtcpclient.Client.RemoteEndPoint.ToString();
                    string []ip = ep.Split(':');

                    // Create our client based on their connection
                    clientcount++;
                    Client newclient = new Client(newtcpclient, clientcount, clientcount, ip[0], ip[1]);

                    System.Threading.Thread.Sleep(30);
                    System.Windows.Forms.Application.DoEvents();
                    // Add our client to our client list
                    newclient.INmsgs.Enqueue(new DebugMessage("New client connected: " + clientcount));
                    clients.Add(clientcount, newclient);
                }
            }
            catch (Exception x)
            {
                if (x is System.Threading.ThreadAbortException)
                {
                    return;
                }
            }
        }
    }

    class Client
    {
        public System.Net.Sockets.TcpClient com;
        private System.Threading.Thread msgListener;
        private System.Threading.Thread msgSender;

        public int clientID;
        public int characterID;
        public string username;

        private string ip;
        private int port;

        bool alive;
        public Queue<IMessage> INmsgs;
        public Queue<IMessage> OUTmsgs;
        
        public Client(TcpClient UserClient, int clientID, int characterID, string ip, string port)
        {
            INmsgs = new Queue<IMessage>();
            OUTmsgs = new Queue<IMessage>();
            this.clientID = clientID;
            this.characterID = characterID;
            this.ip = ip;
            this.port = Convert.ToInt32(port);
            com = UserClient;
            alive = true;
            msgListener = new System.Threading.Thread(ListenClient);
            msgListener.Start();
            msgSender = new System.Threading.Thread(SendClient);
            msgSender.Start();

        }

        private void send(string msg)
        {
                NetworkStream clientStream = this.com.GetStream();
                byte[] bmsg = System.Text.ASCIIEncoding.ASCII.GetBytes(msg + "\t");
                clientStream.Write(bmsg, 0, bmsg.Length);
        }
        
        private void SendClient()
        {

            NetworkStream clientStream;
            try
            {
                try
                {
                    clientStream = com.GetStream();
                }
                catch (Exception X) { return; }

                while (Unstable.running == true && alive == true)
                {

                    if (this.com.Connected == false)
                    {
                        System.Windows.Forms.MessageBox.Show("Client disconnected.");
                        return;
                    }

                    if (this.OUTmsgs.Count > 0)
                    {
                        IMessage toSendMsg = this.OUTmsgs.Dequeue();
                        this.send(toSendMsg.Unpackage());

                    }
                }
            }
            catch (Exception x)
            {
                System.Windows.Forms.MessageBox.Show("SendClient error msgbox: " + x.Message);
                return;
            }

        }

        private void ListenClient()
        {
            NetworkStream clientStream;
            try
            {
                clientStream = com.GetStream();
            }
            catch (Exception X) { return; }

            try
                {
                byte[] message = new byte[512];
                int bytesRead = 0;
                string msg = "";

            while (Unstable.running == true && alive == true)
            {

                    if (this.com.Connected == false)
                    {
                        System.Windows.Forms.MessageBox.Show("Client disconnected.");
                        return;
                    }

                    message = new byte[512];
                    if (clientStream.DataAvailable == true)
                    {
                        bytesRead = clientStream.Read(message, 0, 512);
                        
                        msg += System.Text.ASCIIEncoding.ASCII.GetString(message);
                        msg = msg.Trim('\0');

                        if (msg.Contains("\t"))
                        {
                            int last = msg.LastIndexOf('\t');
                            string[] fullmessages = msg.Substring(0, last).Split('\t');
                            msg = msg.Substring(last + 1, msg.Length - (last + 1));
                            foreach (string s in fullmessages)
                            {
                                string[] splmsg = s.Split(':');
                                if (splmsg != null)
                                {
                                    IMessage cm = new ChatMessage(this.clientID, 0, "CHAT", s, "scope");

                                    if (splmsg.Length > 1)
                                    {
                                        splmsg[0]=splmsg[0].Trim();
                                        switch (splmsg[0].ToUpper())
                                        {
                                            case "CHAT":
                                                { cm = new ChatMessage(this.clientID, 0, splmsg[0], splmsg[1], "scope"); break; }
                                            case "MOVE":
                                                {
                                                    cm = new MoveMessage(this.clientID, 0, splmsg[0], splmsg[1], "scope");
                                                    break;
                                                }
                                            case "LOGIN":
                                                {
                                                    cm = new LoginMessage(this.clientID,0, splmsg[1],-1);
                                                    break;
                                                }
                                        }

                                    }
                                    this.INmsgs.Enqueue(cm);
                                }
                            }
                        }
                    }
            }    
            }
            catch (Exception x)
            {
                System.Windows.Forms.MessageBox.Show("ListenClient error msgbox: " + x.Message);
                return;
            }
        }
    }
}
