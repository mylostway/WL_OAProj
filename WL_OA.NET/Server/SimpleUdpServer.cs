using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

using WL_OA.Data.utils;

namespace WL_OA.NET
{
    public class SimpleUdpServer : IDisposable
    {        
        public SimpleUdpServer(int port, NetHandler handler, string ip = "")
        {
            m_port = port;
            m_ip = ip;
            m_handler = handler;
            m_buff = new byte[NetBase.MAX_UDP_BUF_SIZE];

            if (string.IsNullOrWhiteSpace(m_ip)) m_ip = NetBase.DEFAULT_IP;

            m_sessionClearTimer = new Timer(new TimerCallback(PurgeSessions), 
                null, UDP_FREE_TIMEOUT_MS, UDP_FREE_TIMEOUT_MS);
        }

        public bool IsExit { get; set; } = false;

        public const int SIO_UDP_CONNRESET = -1744830452;

        public const int UDP_FREE_TIMEOUT_MS = 60000;

        public bool Debug { get; set; } = true;

        /// <summary>
        /// 加解密
        /// </summary>
        public ICipher Crypter { get; set; }

        private Socket serverSocket;

        private Dictionary<string, UdpSession> m_sessions = new Dictionary<string, UdpSession>();

        private Timer m_sessionClearTimer = null;

        private UdpClient m_client = null;

        private Thread m_thread = null;

        private NetHandler m_handler = null;

        private int m_port = 0;

        private string m_ip = "";

        byte[] m_buff;

        void PurgeSessions(object state)
        {
            lock (m_sessions)
            {
                var itemsToRemove = new List<string>();
                foreach (var pair in m_sessions)
                {
                    if ((DateTime.UtcNow - pair.Value.lastActive).TotalSeconds > 600)
                        itemsToRemove.Add(pair.Key);
                }

                foreach (var item in itemsToRemove)
                    m_sessions.Remove(item);
            }
        }        

        public void Listen()
        {
            IPEndPoint myEndpoint = new IPEndPoint(IPAddress.Parse(m_ip), m_port);

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.IOControl(
                (IOControlCode)SIO_UDP_CONNRESET,
                new byte[] { 0, 0, 0, 0 },
                null
            );
            serverSocket.Blocking = false;
            serverSocket.Bind(myEndpoint);

            System.Diagnostics.Debug.WriteLineIf(Debug, string.Format("UDP Server listen at {0}:{1}", IPAddress.Parse(this.m_ip), m_port));

            StartReceive();
        }


        void ReceiveFromCallback(IAsyncResult ar)
        {
            try
            {
                EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                int bytesRead = 0;

                try
                {
                    bytesRead = serverSocket.EndReceiveFrom(ar, ref remoteEP);
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                catch (SocketException ex)
                {
                    System.Diagnostics.Debug.WriteLineIf(Debug, string.Format("Socket exception at UDPServer.ReceiveFromCallback(" + remoteEP.ToString() + "): " + ex.Message + ". " + ex.StackTrace));
                    System.Diagnostics.Debug.Assert(false, ex.Message);
                    StartReceive();
                    return;
                }

                IPEndPoint remoteEP_IP = (IPEndPoint)remoteEP;

                var requestParam = SimpleProtocol.Decode(m_buff, bytesRead);                

                // 读取完buffer之后，就可以继续StartReceive
                StartReceive();

                var requestSessionID = requestParam.SessionID;

                UdpSession session = null;

                lock (m_sessions)
                {
                    if (!m_sessions.ContainsKey(requestSessionID))
                    {
                        m_sessions.Add(requestSessionID, new UdpSession(remoteEP_IP.Address, remoteEP_IP.Port,requestParam.SessionID));
                        //throw new Exception(string.Format("Received invalid session {2} from {0}:{1}", remoteEP_IP.Address, remoteEP_IP.Port, requestParam.SessionID));
                    }                        

                    session = m_sessions[requestSessionID];
                }
                /*
                if (session.port > 0 && session.port != remoteEP_IP.Port)
                    throw new Exception(string.Format("Session {0} suddenly changed the port", requestParam.SessionID));
                */

                session.port = remoteEP_IP.Port;
                
                /*
                if (packet.Sequence <= session.inSequence) //drop
                    return;
                session.inSequence = packet.Sequence;
                */
                if (session.inSequence >= uint.MaxValue)
                {
                    session.inSequence = 0;
                }
                session.inSequence++;

                session.lastActive = DateTime.UtcNow;
                
                // 应答数据
                var responseData = m_handler?.Invoke(requestParam, remoteEP_IP);

                requestParam.SetToResponse(SimpleProtocol.Encode(responseData));

                Sendpacket(requestParam, session);

                System.Diagnostics.Debug.WriteLineIf(Debug, "Udp " + requestParam.ToString() + " received from " + remoteEP_IP.ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLineIf(Debug, ex.Message + "\n" + ex.StackTrace);
            }
        }

        void StartReceive()
        {
            EndPoint bindEndPoint = new IPEndPoint(IPAddress.Any, 0);
            serverSocket.BeginReceiveFrom(m_buff, 0, NetBase.MAX_UDP_BUF_SIZE, SocketFlags.None, ref bindEndPoint, new AsyncCallback(ReceiveFromCallback), null);
        }

        public void Sendpacket(SimpleProtocolStruct packet, UdpSession session)
        {
            System.Diagnostics.Debug.WriteLineIf(Debug, "Udp " + packet.ToString() + " send to " + new IPEndPoint(session.address, session.port).ToString());
            serverSocket.SendTo(packet.ToBytes(), new IPEndPoint(session.address, session.port));
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (serverSocket != null)
                serverSocket.Close();

            if (m_sessionClearTimer != null)
                m_sessionClearTimer.Dispose();
        }
    }
}
