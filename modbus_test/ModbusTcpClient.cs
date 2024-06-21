using System.Net.Sockets;
using NModbus;

namespace modbus_test
{
    public class ModbusTcpClient : IModbusClient
    {
        private TcpClient _tcpClient;
        private IModbusMaster _modbusMaster;

        public void Connect(string ipAddress, int port)
        {
            _tcpClient = new TcpClient(ipAddress, port);
            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateMaster(_tcpClient);
        }

        public void Disconnect()
        {
            _tcpClient.Close();
        }

        public ushort[] ReadHoldingRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            return _modbusMaster.ReadHoldingRegisters(slaveId, startAddress, numberOfPoints);
        }

        public void WriteSingleRegister(byte slaveId, ushort address, ushort value)
        {
            _modbusMaster.WriteSingleRegister(slaveId, address, value);
        }
    }
}
