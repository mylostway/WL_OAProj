using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace WL_OA.NET
{
    public class SimpleTcpServer
    {
        public static void StartTcp(int port,string ip = "127.0.0.1")
        {
            var tcp = new TcpListener(port);
            
        }
    }
}
