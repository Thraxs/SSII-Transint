using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transint
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */


            ServerSocket server = new ServerSocket(6531);
            server.start();
            //ClientSocket client = new ClientSocket("127.0.0.1", 6531);
            //client.sendData("client message data");
            server.stop();
        }
    }
}
