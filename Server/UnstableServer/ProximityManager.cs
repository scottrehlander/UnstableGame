using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unstable
{
    class ProximityManager : IManager
    {
        Queue<IMessage> debugMessages;
        Queue<IMessage> outgoingMessages;
        private SortedList<int, string> mobiles;


        public Queue<IMessage> GetDebugMessages()
        {
            if (debugMessages != null)
            {
                return debugMessages;
            }
            else return new Queue<IMessage>();
        }

        public ProximityManager()
        {
            mobiles = new SortedList<int, string>();
            debugMessages = new Queue<IMessage>();
            outgoingMessages = new Queue<IMessage>();
        }

        public bool MsgsToMgr(Queue<IMessage> messages) { return false; }
        public bool MsgToMgr(IMessage message) 
        {
            try
            {
                if (!mobiles.ContainsKey(message.GetSourceID()))
                {
                    mobiles.Add(message.GetSourceID(), message.Unpackage());
                }
                else
                {
                    mobiles[message.GetSourceID()] = message.Unpackage();
                }

                foreach (int id in mobiles.Keys)
                {
                    outgoingMessages.Enqueue(new MoveMessage(0, id, "MOVE", message.GetSourceID() + ";" + message.GetPayload(), ""));
                }
                return true;
            }
            catch (Exception x)
            {
                debugMessages.Enqueue(new DebugMessage(x.Message));
                return false;
            }

        }

        public Queue<IMessage> MsgsFromMgr() { return outgoingMessages; }
    }
}
