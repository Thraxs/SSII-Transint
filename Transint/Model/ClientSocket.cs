using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transint
{
    class ClientSocket
    {
        private IPEndPoint remoteServer;
        private Socket socket;
        private string data;
        private byte[] buffer;

        public ClientSocket(string ip, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(ip);
            IPAddress address = ipHostInfo.AddressList[0];
            remoteServer = new IPEndPoint(address, port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            data = null;
            buffer = new Byte[1024];
        }

        public void sendData(string data)
        {
            try
            {
                socket.Connect(remoteServer);

                byte[] message = Encoding.ASCII.GetBytes(data);
                socket.Send(message);

                int bytesReceived = socket.Receive(buffer);
                data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

                //TODO handle response
                Console.WriteLine("Server response: " + data);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Client socket exception: " + e.ToString());
            }
        }
    }
}
