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
        private string data;
        private byte[] buffer;
        public bool started { get; set; }

        public ServerSocket(int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress address = ipHostInfo.AddressList[0];
            localServer = new IPEndPoint(address, port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            data = null;
            buffer = new Byte[1024];
        }

        public void start()
        {
            try
            {
                this.started = true;

                socket.Bind(localServer);
                socket.Listen(10);

                while (started)
                {
                    handler = socket.Accept();
                    data = null;

                    while (true)
                    {
                        buffer = new byte[1024];
                        int bytesRec = handler.Receive(buffer);
                        data += Encoding.ASCII.GetString(buffer, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    //TODO handle received message (data)
                    Console.WriteLine("Client message: " + data);

                    //TODO send response
                    byte[] response = Encoding.ASCII.GetBytes("server response data");

                    socket.Send(response);
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
                this.started = false;

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Server socket exception: " + e.ToString());
            }
        }
    }
}
