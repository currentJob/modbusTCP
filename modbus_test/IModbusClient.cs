namespace modbus_test
{
    public interface IModbusClient
    {
        void Connect(string ipAddress, int port);
        void Disconnect();
        ushort[] ReadHoldingRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints);
        void WriteSingleRegister(byte slaveId, ushort address, ushort value);
    }
}