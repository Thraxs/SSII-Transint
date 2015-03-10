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
        private HMACAlgorithm algorithm;
        private string data;
        private byte[] buffer;
        private byte[] key;

        public ClientSocket(string ip, int port, byte[] key, HMACAlgorithm algorithm)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(ip);
            IPAddress address = null;

            //Find IPv4 address
            foreach (IPAddress addr in ipHostInfo.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    address = addr;
                }
            }

            remoteServer = new IPEndPoint(address, port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            data = null;
            buffer = new Byte[1024];
            this.key = key;
            this.algorithm = algorithm;
        }

        public void sendData(string input)
        {
            try
            {
                socket.Connect(remoteServer);

                //Create the message with the HMAC and the contents
                byte[] HMAC = Cipher.computeHMAC(key, input, algorithm);
                string messageString = Encoding.Default.GetString(HMAC) + "</>" + input + "</>";
                byte[] message = Encoding.Default.GetBytes(messageString);
                
                socket.Send(message);

                /*
                int bytesReceived = socket.Receive(buffer);
                data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                */
                //TODO handle response
                //Console.WriteLine("Server response: " + data);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                //Erase key once the message has been sent
                Cipher.eraseKey(key);
            }
            catch (Exception e)
            {
                Console.WriteLine("Client socket exception: " + e.ToString());
            }
        }
    }
}
