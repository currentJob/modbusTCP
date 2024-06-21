using System;
using System.Windows.Forms;

namespace modbus_test
{
    public partial class Form1 : Form
    {
        private IModbusClient _modbusClient;

        public Form1()
        {
            InitializeComponent();
            _modbusClient = new ModbusTcpClient();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _modbusClient.Connect(txtIpAddress.Text, int.Parse(txtPort.Text));
                MessageBox.Show("Connected to Modbus server.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _modbusClient.Disconnect();
            MessageBox.Show("Disconnected from Modbus server.");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                byte slaveId = byte.Parse(txtSlaveId.Text);
                ushort address = ushort.Parse(txtAddress.Text);
                ushort numberOfPoints = ushort.Parse(txtRegister.Text);
                ushort[] response = _modbusClient.ReadHoldingRegisters(slaveId, address, numberOfPoints);
                MessageBox.Show($"Response: {string.Join(", ", response)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading registers: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}