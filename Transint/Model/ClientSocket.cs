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
        private string input;

        public ClientSocket(string ip, int port, byte[] key, HMACAlgorithm algorithm, string input)
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
            this.key = new byte[key.Length];
            Array.Copy(key, this.key, key.Length);
            this.algorithm = algorithm;
            this.input = input;
        }

        public void sendData()
        {
            try
            {
                socket.Connect(remoteServer);

                Program.form.logClientAction("Conexion establecida con el servidor");

                //Create the message with the HMAC and the contents
                byte[] HMAC = Cipher.computeHMAC(key, input, algorithm);
                string messageString = Cipher.byteToString(HMAC) + "</>" + input + "</>";
                byte[] message = Encoding.Default.GetBytes(messageString);
                
                socket.Send(message);

                Program.form.logClientAction("Mensaje enviado al servidor");

                int bytesReceived = socket.Receive(buffer);
                data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

                Program.form.logClientAction(data);

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
