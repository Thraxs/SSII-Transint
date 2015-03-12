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
            this.key = new byte[key.Length];
            Array.Copy(key, this.key, key.Length);
            this.algorithm = algorithm;
        }

        public void start()
        {
            try
            {
                //TODO async continuous server
                socket.Bind(localServer);
                socket.Listen(10);

                while (true)
                {
                    handler = socket.Accept();

                    int bytesRec = handler.Receive(buffer);
                    data = Encoding.Default.GetString(buffer);

                    //Separate HMAC and message
                    int HMACSeparator = data.IndexOf("</>");
                    int messageSeparator = data.LastIndexOf("</>");
                    byte[] receivedHMAC = Cipher.stringToByte(data.Substring(0, HMACSeparator));
                    string message = data.Substring(HMACSeparator + 3, (messageSeparator - HMACSeparator) - 3);

                    bool result = Cipher.verifyHMAC(key, message, receivedHMAC, algorithm);
                    byte[] response;
                    if (result)
                    {
                        Program.form.logServerAction("Mensaje integro recibido desde " + IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()));
                        response = Encoding.ASCII.GetBytes("Mensaje integro recibido por el servidor");
                    }
                    else
                    {
                        Program.form.logServerAction("Mensaje no integro recibido");
                        response = Encoding.ASCII.GetBytes("Mensaje no integro recibido por el servidor");
                    }

                    //Send response to client
                    handler.Send(response);

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (ObjectDisposedException)
            {
                //Socket closed, erase key from program
                Console.WriteLine("Server closed");
                Cipher.eraseKey(key);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server socket exception: " + e.ToString());
            }
        }

        public void stop()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

            }
            catch (SocketException)
            {
                //TODO
            }
        }
    }
}
