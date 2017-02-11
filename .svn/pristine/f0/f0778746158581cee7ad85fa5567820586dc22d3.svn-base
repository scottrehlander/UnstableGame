using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unstable
{
    class LoginManager : IManager
    {
        Queue<IMessage> dbgmsgs;
        SortedList<int, int> Players;
        Queue<IMessage> msgsfrommgr;

        public LoginManager()
        {
            msgsfrommgr = new Queue<IMessage>();
            Players = new SortedList<int, int>();
            dbgmsgs = new Queue<IMessage>();
        }

        public Queue<IMessage> GetDebugMessages()
        {
            if (dbgmsgs == null) { return new Queue<IMessage>(); }
            else { return dbgmsgs; }
        }

        public bool MsgsToMgr(Queue<IMessage> messages)
        {
            int i = 0;
            while (i < messages.Count)
            {
                IMessage msg = messages.Dequeue();
                if(msg is LoginMessage)
                {
                    login(msg as LoginMessage);
                }
            }
            return true;
        }

        void login(LoginMessage lmsg)
        {
            if (lmsg.login != "FAIL" && lmsg.password != "FAIL")
            {
                msgsfrommgr.Enqueue(new LoginMessage(0,lmsg.GetSourceID(), "SUCCESS/SUCCESS",-1));
            }
            else
            {
                msgsfrommgr.Enqueue(new LoginMessage(0,lmsg.GetSourceID(), "FAIL/FAIL",-1));
            }
        }

        public Queue<IMessage> MsgsFromMgr()
        {
            if (msgsfrommgr == null)
            {
                Queue<IMessage> msgs = new Queue<IMessage>();
                return msgs;
            }
            else
            {
                return msgsfrommgr;
            }
        }
    }
}
