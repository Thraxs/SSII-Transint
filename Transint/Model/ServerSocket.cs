using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transint
{
    class StateObject
    {
        public Socket socket = null;
        public byte[] buffer = new byte[1024];
        public StringBuilder input = new StringBuilder();
    }

    class ServerSocket
    {
        private IPEndPoint localServer;
        private Socket socket;
        private HMACAlgorithm algorithm;
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

            this.key = new byte[key.Length];
            Array.Copy(key, this.key, key.Length);
            this.algorithm = algorithm;
        }

        public static ManualResetEvent resetEvent = new ManualResetEvent(false);

        public void start()
        {
            try
            {
                socket.Bind(localServer);
                socket.Listen(100);
                while (true)
                {
                    resetEvent.Reset();
                    socket.BeginAccept(new AsyncCallback(AcceptConnection), socket);
                    resetEvent.WaitOne();
                }
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
                socket.Close();

                //Erase key once server is closed
                Cipher.eraseKey(key);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server close socket exception: " + e.ToString());
            }
        }

        public void AcceptConnection(IAsyncResult result)
        {
            try
            {
                resetEvent.Set();

                Socket listener = (Socket)result.AsyncState;
                Socket handler = listener.EndAccept(result);

                StateObject state = new StateObject();
                state.socket = handler;

                handler.BeginReceive(state.buffer, 0, 1024, 0, new AsyncCallback(ProcessConnection), state);
            }
            catch (ObjectDisposedException){/*Server closed*/}
        }

        public void ProcessConnection(IAsyncResult result)
        {
            string data = string.Empty;

            StateObject state = (StateObject)result.AsyncState;
            Socket handler = state.socket;

            int bytesRec = handler.EndReceive(result);

            if (bytesRec > 0)
            {
                state.input.Append(Encoding.Default.GetString(state.buffer, 0, bytesRec));

                data = state.input.ToString();
                if (data.IndexOf("<//>") > -1){
                    //Process input

                    //Separate HMAC and message
                    int HMACSeparator = data.IndexOf("</>");
                    int messageSeparator = data.LastIndexOf("<//>");
                    byte[] receivedHMAC = Cipher.stringToByte(data.Substring(0, HMACSeparator));
                    string message = data.Substring(HMACSeparator + 3, (messageSeparator - HMACSeparator) - 3);

                    bool status = Cipher.verifyHMAC(key, message, receivedHMAC, algorithm);
                    string response;
                    if (status)
                    {
                        Program.form.logServerAction("Mensaje integro recibido desde " + IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()));
                        response = "Mensaje integro recibido por el servidor";
                    }
                    else
                    {
                        Program.form.logServerAction("Mensaje no integro recibido desde " + IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()));
                        response = "Mensaje no integro recibido por el servidor";
                    }

                    SendResponse(handler, response);

                } else {
                    //No full message received, continue reading
                    handler.BeginReceive(state.buffer, 0, 1024, 0, new AsyncCallback(ProcessConnection), state);
                }
            }
        }

        public void SendResponse(Socket handler, String data)
        {
            byte[] response = Encoding.Default.GetBytes(data);

            handler.BeginSend(response, 0, response.Length, 0, new AsyncCallback(ProcessResponse), handler);
        }

        public void ProcessResponse(IAsyncResult result)
        {
            try
            {
                Socket handler = (Socket)result.AsyncState;

                int bytesSent = handler.EndSend(result);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Server socket response exception: " + e.ToString());
            }
        }
    }
}
