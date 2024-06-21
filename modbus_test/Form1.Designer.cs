namespace modbus_test
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtIpAddress = new TextBox();
            txtPort = new TextBox();
            txtSlaveId = new TextBox();
            txtAddress = new TextBox();
            txtRegister = new TextBox();
            btnConnect = new Button();
            btnDisconnect = new Button();
            btnRead = new Button();
            SuspendLayout();
            // 
            // txtIpAddress
            // 
            txtIpAddress.Location = new Point(12, 12);
            txtIpAddress.Name = "txtIpAddress";
            txtIpAddress.Size = new Size(100, 23);
            txtIpAddress.TabIndex = 0;
            txtIpAddress.Text = "172.20.20.55";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(118, 12);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(100, 23);
            txtPort.TabIndex = 1;
            txtPort.Text = "502";
            // 
            // txtSlaveId
            // 
            txtSlaveId.Location = new Point(12, 38);
            txtSlaveId.Name = "txtSlaveId";
            txtSlaveId.Size = new Size(100, 23);
            txtSlaveId.TabIndex = 2;
            txtSlaveId.Text = "1";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(118, 38);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 3;
            txtAddress.Text = "0";
            // 
            // txtRegister
            // 
            txtRegister.Location = new Point(224, 38);
            txtRegister.Name = "txtRegister";
            txtRegister.Size = new Size(100, 23);
            txtRegister.TabIndex = 4;
            txtRegister.Text = "1";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 64);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(93, 64);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 23);
            btnDisconnect.TabIndex = 6;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(174, 64);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(75, 23);
            btnRead.TabIndex = 7;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(336, 101);
            Controls.Add(btnRead);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(txtRegister);
            Controls.Add(txtAddress);
            Controls.Add(txtSlaveId);
            Controls.Add(txtPort);
            Controls.Add(txtIpAddress);
            Name = "Form1";
            Text = "Modbus TCP Client";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtSlaveId;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtRegister;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnRead;
    }
}