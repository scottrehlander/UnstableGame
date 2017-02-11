using System;
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
    public interface IMessage 
    {
        string Unpackage();
        int GetSourceID();
        int GetDestID();
        DateTime GetCreateTime();
        string GetPayload();
        int[] GetEffectedIDs();
    }

    class MoveMessage : IMessage
    {
        private int  sourceID;
        private int destinationID;
        private string type;
        private string body;
        private string scope;
        public DateTime createtime;
        
        public string Unpackage() { return "MOVE:" + body; }

        public int GetSourceID() { return sourceID; }
        public DateTime GetCreateTime() { return createtime; }
        public string GetPayload() { return body; }
        public int[] GetEffectedIDs() { return new int[0]; }

        public MoveMessage(int Source, int DestinationID, string Type, string Body, string Scope)
        {
            this.sourceID = Source;
            this.type = Type;
            this.body = Body;
            this.scope = Scope;
            this.createtime = DateTime.Now;
            this.destinationID = DestinationID;
        }

        public int GetDestID()
        {
            return destinationID;
        }
    }

    class DebugMessage : IMessage
    {
        public DebugMessage(string msg)
        {
            message = msg;
            created =  DateTime.Now;
        }

        DateTime created;
        public string Unpackage(){ return message; }
        public int GetSourceID() { return 0; }
        public int GetDestID() { return 0; }
        public DateTime GetCreateTime() { return created; }
        public string GetPayload() { return created.Second + " " + created.Millisecond.ToString() + " " + message; }
        public int[] GetEffectedIDs() { return new int[0]; }
        public string message;
    }

    class ChatMessage : IMessage
    {
        public int sourceID;
        public int destinationID;
        private string type;
        private string body;
        private string scope;
        public DateTime createtime;

        public string Unpackage() { return "CHAT:" + body; }

        public int GetSourceID() { return sourceID; }
        public DateTime GetCreateTime() { return createtime; }
        public string GetPayload() { return body; }
        public int[] GetEffectedIDs() {return new int[0];}

        public ChatMessage(int Source, int DestinationID, string Type, string Body, string Scope)
        {
            this.sourceID = Source;
            this.destinationID = DestinationID;
            this.type = Type;
            this.body = Body;
            this.scope = Scope;
            this.createtime = DateTime.Now;
        }

        public int GetDestID()
        {
            return destinationID;
        }
    }

    class LoginMessage : IMessage
    {
        public int sourceID;
        public int destinationID;
        public int loginID;

        private string type;
        public string login;
        public string password;
        private string scope;
        public DateTime createtime;

        public LoginMessage(int srcID, int destID, string lognpass, int logID)
        {
            loginID = 0;
            sourceID = srcID;
            destinationID = destID;
            createtime = DateTime.Now;
            string[] lognpw = new string[2];
            lognpw[0] = "FAIL";
            lognpw[1] = "FAIL";
            try
            {
                lognpw = lognpass.Split('/');
                login = lognpw[0];
                password = lognpw[1];
            }
            catch (Exception x) { login = "FAIL"; password = "FAIL"; }
            loginID = logID;
        }

        public string Unpackage() { 
            string msg= "LOGIN:" + login + "/" +password;
            return msg;
        }

        public int GetSourceID() { return sourceID; }
        public int GetDestID() { return destinationID; }
        public DateTime GetCreateTime() { return createtime; }
        public string GetPayload() { return login + "/" + password; }
        public int[] GetEffectedIDs() { return new int[0]; }
    }
}