using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transint
{
    public partial class Form1 : Form
    {
        private static byte[] generatedKey;
        private ServerSocket server;
        private Thread serverThread;
        private ClientSocket client;
        private bool serverStatus = false;

        public Form1()
        {
            InitializeComponent();
            comboBox_keyGenerator.SelectedIndex = 0;
            comboBox_clientAlgorithm.SelectedIndex = 0;
            comboBox_serverAlgorithm.SelectedIndex = 0;
            Program.form = this;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //If server is on, turn off before exiting application
            if (serverStatus)
            {
                server.stop();
            }
        }

        private void button_generateKey_Click(object sender, EventArgs e)
        {
            generatedKey = Cipher.generateKey((HMACAlgorithm)comboBox_keyGenerator.SelectedIndex);
            textBox_generatedKey.Text = Cipher.byteToString(generatedKey);
        }

        private void button_deleteKey_Click(object sender, EventArgs e)
        {
            Cipher.eraseKey(generatedKey);
            textBox_generatedKey.Text = "";
        }

        private void button_copyKey_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_generatedKey.Text);
        }

        private void button_switchServer_Click(object sender, EventArgs e)
        {
            if (serverStatus)
            {
                //Switch off
                server.stop();

                //Update server user interface
                textBox_servedPort.Enabled = true;
                comboBox_serverAlgorithm.Enabled = true;
                textBox_serverStatus.Text = "Apagado";
                button_switchServer.Text = "Encender";

                textBox_serverKey.Enabled = true;
                textBox_serverKey.UseSystemPasswordChar = false;
                textBox_serverKey.Text = "";

                //Log activity
                this.logServerAction("Servidor apagado");
            }
            else
            {
                try
                {
                    //Switch on
                    byte[] key = Cipher.stringToByte(textBox_serverKey.Text);

                    //Create and start server
                    server = new ServerSocket(int.Parse(textBox_servedPort.Text), key, (HMACAlgorithm)comboBox_serverAlgorithm.SelectedIndex);
                    serverThread = new Thread(server.start);
                    serverThread.Start();

                    //Update server user interface
                    textBox_servedPort.Enabled = false;
                    comboBox_serverAlgorithm.Enabled = false;
                    textBox_serverStatus.Text = "Encendido";
                    button_switchServer.Text = "Apagar";

                    //Hide and erase used key from user interface
                    textBox_serverKey.Enabled = false;
                    textBox_serverKey.UseSystemPasswordChar = true;
                    textBox_serverKey.Text = new string('*', textBox_serverKey.Text.Length);
                    Cipher.eraseKey(key);

                    serverStatus = true;

                    //Log activity
                    this.logServerAction("Servidor encendido");
                }
                catch (Exception){}

            }
        }

        private void button_sendMessage_Click(object sender, EventArgs e)
        {
            byte[] key = Cipher.stringToByte(textBox_clientKey.Text);

            client = new ClientSocket(textBox_serverIP.Text, int.Parse(textBox_serverPort.Text), key, (HMACAlgorithm)comboBox_clientAlgorithm.SelectedIndex, textBox_clientMessage.Text);

            //Hide and erase used key from user interface
            textBox_clientKey.Text = "";
            Cipher.eraseKey(key);

            //Send message
            Thread clientThread = new Thread(client.sendData);
            clientThread.Start();
        }

        delegate void LogServerActionCallback(string action);
        internal void logServerAction(string action)
        {
            if (this.InvokeRequired)
            {
                LogServerActionCallback callback = new LogServerActionCallback(logServerAction);
                this.Invoke(callback, new object[] { action });
            }
            else
            {
                listBox_server.Items.Insert(0, DateTime.Now.ToShortTimeString() + " - " + action);
            }
        }

        delegate void LogClientActionCallback(string action);
        internal void logClientAction(string action)
        {
            if (this.InvokeRequired)
            {
                LogClientActionCallback callback = new LogClientActionCallback(logClientAction);
                this.Invoke(callback, new object[] { action });
            }
            else
            {
                listBox_client.Items.Insert(0, DateTime.Now.ToShortTimeString() + " - " + action);
            }
        }
    }
}
