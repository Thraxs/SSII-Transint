using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transint
{
    class ServerSocket
    {
        private IPEndPoint localServer;
        private Socket socket;
        private Socket handler;
        private HMACAlgorithm algorithm;
        private string data;
        private byte[] buffer;
        private byte[] key;

        public ServerSocket(int port, byte[] key, HMACAlgorithm algorithm)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress address = null;

            //Find IPv4 address
            foreach (IPAddress addr in ipHostInfo.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    address = addr;
                }
            }

            localServer = new IPEndPoint(address, port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            data = null;
            buffer = new Byte[1024];
            this.key = key;
            this.algorithm = algorithm;
        }

        public void start()
        {
            try
            {
                //TODO continuous server
                socket.Bind(localServer);
                socket.Listen(10);

                handler = socket.Accept();

                int bytesRec = handler.Receive(buffer);
                data = Encoding.Default.GetString(buffer);

                //Separate HMAC and message
                int HMACSeparator = data.IndexOf("</>");
                int messageSeparator = data.LastIndexOf("</>");
                byte[] receivedHMAC = Encoding.Default.GetBytes(data.Substring(0, HMACSeparator));
                string message = data.Substring(HMACSeparator + 3, (messageSeparator - HMACSeparator) - 3);

                Cipher.verifyHMAC(key, message, receivedHMAC, algorithm);

                //TODO send response
                //byte[] response = Encoding.ASCII.GetBytes("server response data");

                //socket.Send(response);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

                //Erase keys from program
                //Cipher.eraseKey(key);
                //Cipher.eraseKey(receivedKey);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server socket exception: " + e.ToString());
            }
        }
    }
}
