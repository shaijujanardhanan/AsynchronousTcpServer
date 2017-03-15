using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
namespace AsynchronousTcpServer
{
    public class Server
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        Int32 port = 10000;
        ManualResetEvent allDone = new ManualResetEvent(false);
        public Server(IPAddress ipAddress, Int32 inputPort)
        {
            this.ip = ipAddress;
            this.port = inputPort;
        }

        public void StartListening()
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(this.ip, this.port);
            serverSocket.Bind(endpoint);

            while(true)
            {
                allDone.Reset();
                serverSocket.BeginAccept(new AsyncCallback(AcceptConnection), serverSocket);
                Debug.WriteLine($"Listening on IP: {ip} and port: {port}");
                allDone.WaitOne();
            }
        }

        private void AcceptConnection(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }
    }
}
