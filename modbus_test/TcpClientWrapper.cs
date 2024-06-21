using System.Net.Sockets;

namespace modbus_test
{
    public class TcpClientWrapper
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;

        public void Connect(string ipAddress, int port)
        {
            _tcpClient = new TcpClient(ipAddress, port);
            _networkStream = _tcpClient.GetStream();
        }

        public void Disconnect()
        {
            _networkStream.Close();
            _tcpClient.Close();
        }

        public void Send(byte[] data)
        {
            _networkStream.Write(data, 0, data.Length);
        }

        public byte[] Receive(int numberOfBytes)
        {
            byte[] receivedBytes = new byte[numberOfBytes];
            _networkStream.Read(receivedBytes, 0, numberOfBytes);
            return receivedBytes;
        }
    }

}
