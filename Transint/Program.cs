using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;//TODO REMOVE
using System.Text;

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
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            /*
            byte[] key = Cipher.generateKey(HMACAlgorithm.SHA512);
            ServerSocket server = new ServerSocket(11000, key, HMACAlgorithm.SHA512);
            Thread thread = new Thread(server.start);
            thread.Start();
            ClientSocket client = new ClientSocket("localhost", 11000, key, HMACAlgorithm.SHA512);
            client.sendData("client message data");
            */
        }
    }
}
