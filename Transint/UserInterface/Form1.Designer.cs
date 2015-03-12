namespace Transint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox_client = new System.Windows.Forms.ListBox();
            this.button_sendMessage = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_clientMessage = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_clientKey = new System.Windows.Forms.TextBox();
            this.comboBox_clientAlgorithm = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_serverPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_serverIP = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox_server = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_serverKey = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_serverAlgorithm = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_servedPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_serverStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_switchServer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_generateKey = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox_keyGenerator = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_deleteKey = new System.Windows.Forms.Button();
            this.textBox_generatedKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servidor";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listBox_client);
            this.panel1.Controls.Add(this.button_sendMessage);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.textBox_clientMessage);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.textBox_clientKey);
            this.panel1.Controls.Add(this.comboBox_clientAlgorithm);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBox_serverPort);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox_serverIP);
            this.panel1.Location = new System.Drawing.Point(29, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 290);
            this.panel1.TabIndex = 2;
            // 
            // listBox_client
            // 
            this.listBox_client.FormattingEnabled = true;
            this.listBox_client.Location = new System.Drawing.Point(11, 190);
            this.listBox_client.Name = "listBox_client";
            this.listBox_client.Size = new System.Drawing.Size(335, 95);
            this.listBox_client.TabIndex = 19;
            // 
            // button_sendMessage
            // 
            this.button_sendMessage.Location = new System.Drawing.Point(204, 157);
            this.button_sendMessage.Name = "button_sendMessage";
            this.button_sendMessage.Size = new System.Drawing.Size(142, 23);
            this.button_sendMessage.TabIndex = 18;
            this.button_sendMessage.Text = "Enviar mensaje";
            this.button_sendMessage.UseVisualStyleBackColor = true;
            this.button_sendMessage.Click += new System.EventHandler(this.button_sendMessage_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Registro de actividad";
            // 
            // textBox_clientMessage
            // 
            this.textBox_clientMessage.Location = new System.Drawing.Point(76, 129);
            this.textBox_clientMessage.Name = "textBox_clientMessage";
            this.textBox_clientMessage.Size = new System.Drawing.Size(270, 20);
            this.textBox_clientMessage.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Mensaje:";
            // 
            // textBox_clientKey
            // 
            this.textBox_clientKey.Location = new System.Drawing.Point(76, 88);
            this.textBox_clientKey.Name = "textBox_clientKey";
            this.textBox_clientKey.Size = new System.Drawing.Size(270, 20);
            this.textBox_clientKey.TabIndex = 14;
            // 
            // comboBox_clientAlgorithm
            // 
            this.comboBox_clientAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_clientAlgorithm.FormattingEnabled = true;
            this.comboBox_clientAlgorithm.Items.AddRange(new object[] {
            "MD5",
            "RIPEMD",
            "SHA128",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.comboBox_clientAlgorithm.Location = new System.Drawing.Point(76, 56);
            this.comboBox_clientAlgorithm.Name = "comboBox_clientAlgorithm";
            this.comboBox_clientAlgorithm.Size = new System.Drawing.Size(110, 21);
            this.comboBox_clientAlgorithm.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Algoritmo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Clave:";
            // 
            // textBox_serverPort
            // 
            this.textBox_serverPort.Location = new System.Drawing.Point(248, 19);
            this.textBox_serverPort.Name = "textBox_serverPort";
            this.textBox_serverPort.Size = new System.Drawing.Size(98, 20);
            this.textBox_serverPort.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Puerto:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "IP Servidor:";
            // 
            // textBox_serverIP
            // 
            this.textBox_serverIP.Location = new System.Drawing.Point(76, 21);
            this.textBox_serverIP.Name = "textBox_serverIP";
            this.textBox_serverIP.Size = new System.Drawing.Size(110, 20);
            this.textBox_serverIP.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.listBox_server);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.textBox_serverKey);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.comboBox_serverAlgorithm);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.textBox_servedPort);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox_serverStatus);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button_switchServer);
            this.panel2.Location = new System.Drawing.Point(449, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 290);
            this.panel2.TabIndex = 3;
            // 
            // listBox_server
            // 
            this.listBox_server.FormattingEnabled = true;
            this.listBox_server.Location = new System.Drawing.Point(10, 190);
            this.listBox_server.Name = "listBox_server";
            this.listBox_server.Size = new System.Drawing.Size(335, 95);
            this.listBox_server.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 167);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Registro de actividad";
            // 
            // textBox_serverKey
            // 
            this.textBox_serverKey.Location = new System.Drawing.Point(77, 133);
            this.textBox_serverKey.Name = "textBox_serverKey";
            this.textBox_serverKey.Size = new System.Drawing.Size(268, 20);
            this.textBox_serverKey.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Clave:";
            // 
            // comboBox_serverAlgorithm
            // 
            this.comboBox_serverAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_serverAlgorithm.FormattingEnabled = true;
            this.comboBox_serverAlgorithm.Items.AddRange(new object[] {
            "MD5",
            "RIPEMD",
            "SHA128",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.comboBox_serverAlgorithm.Location = new System.Drawing.Point(77, 97);
            this.comboBox_serverAlgorithm.Name = "comboBox_serverAlgorithm";
            this.comboBox_serverAlgorithm.Size = new System.Drawing.Size(121, 21);
            this.comboBox_serverAlgorithm.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Algoritmo:";
            // 
            // textBox_servedPort
            // 
            this.textBox_servedPort.Location = new System.Drawing.Point(77, 53);
            this.textBox_servedPort.Name = "textBox_servedPort";
            this.textBox_servedPort.Size = new System.Drawing.Size(121, 20);
            this.textBox_servedPort.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Puerto:";
            // 
            // textBox_serverStatus
            // 
            this.textBox_serverStatus.Enabled = false;
            this.textBox_serverStatus.Location = new System.Drawing.Point(77, 16);
            this.textBox_serverStatus.Name = "textBox_serverStatus";
            this.textBox_serverStatus.ReadOnly = true;
            this.textBox_serverStatus.Size = new System.Drawing.Size(121, 20);
            this.textBox_serverStatus.TabIndex = 2;
            this.textBox_serverStatus.Text = "Apagado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Estado:";
            // 
            // button_switchServer
            // 
            this.button_switchServer.Location = new System.Drawing.Point(218, 16);
            this.button_switchServer.Name = "button_switchServer";
            this.button_switchServer.Size = new System.Drawing.Size(127, 23);
            this.button_switchServer.TabIndex = 0;
            this.button_switchServer.Text = "Encender";
            this.button_switchServer.UseVisualStyleBackColor = true;
            this.button_switchServer.Click += new System.EventHandler(this.button_switchServer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Generación de claves";
            // 
            // button_generateKey
            // 
            this.button_generateKey.Location = new System.Drawing.Point(288, 37);
            this.button_generateKey.Name = "button_generateKey";
            this.button_generateKey.Size = new System.Drawing.Size(231, 23);
            this.button_generateKey.TabIndex = 5;
            this.button_generateKey.Text = "Generar nueva clave";
            this.button_generateKey.UseVisualStyleBackColor = true;
            this.button_generateKey.Click += new System.EventHandler(this.button_generateKey_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.comboBox_keyGenerator);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.button_deleteKey);
            this.panel3.Controls.Add(this.textBox_generatedKey);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button_generateKey);
            this.panel3.Location = new System.Drawing.Point(29, 333);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(785, 162);
            this.panel3.TabIndex = 6;
            // 
            // comboBox_keyGenerator
            // 
            this.comboBox_keyGenerator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_keyGenerator.FormattingEnabled = true;
            this.comboBox_keyGenerator.Items.AddRange(new object[] {
            "MD5",
            "RIPEMD",
            "SHA128",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.comboBox_keyGenerator.Location = new System.Drawing.Point(93, 40);
            this.comboBox_keyGenerator.Name = "comboBox_keyGenerator";
            this.comboBox_keyGenerator.Size = new System.Drawing.Size(121, 21);
            this.comboBox_keyGenerator.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Algoritmo:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Location = new System.Drawing.Point(-2, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(785, 4);
            this.panel4.TabIndex = 9;
            // 
            // button_deleteKey
            // 
            this.button_deleteKey.Location = new System.Drawing.Point(288, 128);
            this.button_deleteKey.Name = "button_deleteKey";
            this.button_deleteKey.Size = new System.Drawing.Size(231, 23);
            this.button_deleteKey.TabIndex = 8;
            this.button_deleteKey.Text = "Eliminar clave del programa";
            this.toolTip1.SetToolTip(this.button_deleteKey, "Borra del programa toda informacion generada relacionada con la clave");
            this.button_deleteKey.UseVisualStyleBackColor = true;
            this.button_deleteKey.Click += new System.EventHandler(this.button_deleteKey_Click);
            // 
            // textBox_generatedKey
            // 
            this.textBox_generatedKey.Location = new System.Drawing.Point(93, 102);
            this.textBox_generatedKey.Name = "textBox_generatedKey";
            this.textBox_generatedKey.ReadOnly = true;
            this.textBox_generatedKey.Size = new System.Drawing.Size(671, 20);
            this.textBox_generatedKey.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Clave generada";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 517);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "TransInt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_generateKey;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_generatedKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button_deleteKey;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox_keyGenerator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_clientKey;
        private System.Windows.Forms.ComboBox comboBox_clientAlgorithm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_serverPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_serverIP;
        private System.Windows.Forms.TextBox textBox_serverKey;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox_serverAlgorithm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_servedPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_serverStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_switchServer;
        private System.Windows.Forms.ListBox listBox_client;
        private System.Windows.Forms.Button button_sendMessage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_clientMessage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBox_server;
        private System.Windows.Forms.Label label16;

    }
}

