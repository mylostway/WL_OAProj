using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WL_OA.NET
{
    public class UdpSession
    {
        public UdpSession(IPAddress ip,int port,string sessionID)
        {
            this.port = port;
            this.sessionId = sessionID;

            inSequence = 0;
            outSequence = 0;
            lastActive = DateTime.Now;
            address = ip;
        }        

        public IPAddress address;
        public int port;
        public string sessionId;
        public uint inSequence;
        public uint outSequence;
        public DateTime lastActive;
        //public IConnectedObjectUdp obj;

        public string GetKey()
        {
            return address.ToString() + ":" + port.ToString() + ":" + sessionId.ToString();
        }
    }
}
