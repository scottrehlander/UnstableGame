using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unstable
{
    class Router : IManager
    {
        Queue<IMessage> outgoingMsgs;
        Queue<IMessage> debugMessages;
        ProximityManager PROXMgr;
        LoginManager LogMgr;

        public Queue<IMessage> GetDebugMessages()
        {
            if (debugMessages != null)
            {
                return debugMessages;
            }
            else return new Queue<IMessage>();
        }

        public Router()
        {
            outgoingMsgs = new Queue<IMessage>();
            PROXMgr = new ProximityManager();
            LogMgr = new LoginManager();
        }

        public bool MsgsToMgr(Queue<IMessage> messages)
        {
            while(messages.Count > 0)
            {
                route(messages.Dequeue());
            }
            return true;
        }

        public Queue<IMessage> MsgsFromMgr()
        {
            return outgoingMsgs;
        }

        public void route(IMessage msg)
        {
            string type = msg.GetType().ToString();
            switch (type)
            {
                case "Unstable.ChatMessage":
                    {
                        outgoingMsgs.Enqueue(new ChatMessage((msg as ChatMessage).GetSourceID(), (msg as ChatMessage).GetSourceID(), "CHAT", "This is a chat reply. \n\r", "pappas rules"));
                        break;
                    }
                case "Unstable.MoveMessage":
                    {
                        
                        PROXMgr.MsgToMgr(msg);
                        Queue<IMessage> msgsFromProx = PROXMgr.MsgsFromMgr();
                        while (msgsFromProx.Count > 0)
                        {
                            outgoingMsgs.Enqueue(msgsFromProx.Dequeue());
                        }
                        break;
                    }
                case "Unstable.LoginMessage":
                    {
                        Queue<IMessage> toLogin = new Queue<IMessage>();
                        toLogin.Enqueue(msg);
                        LogMgr.MsgsToMgr(toLogin);
                        Queue<IMessage> msgsFromLogin = LogMgr.MsgsFromMgr();
                        while (msgsFromLogin.Count > 0)
                        {
                            outgoingMsgs.Enqueue(msgsFromLogin.Dequeue());
                        }
                        break;
                    }
            }
        }
    }
}
