using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unstable
{
    /*
     * 
     * 
     * 
     * 
     */
    class ChatManager : IManager
    {
        public Queue<IMessage> debugMessages;

        public Queue<IMessage> GetDebugMessages()
        {
            if (debugMessages != null)
            {
                return debugMessages;
            }
            else return new Queue<IMessage>();
        }

        public bool MsgsToMgr(Queue<IMessage> messages) { return false; }

        public Queue<IMessage> MsgsFromMgr() { return new Queue<IMessage>(); }
    }
}
