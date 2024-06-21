using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;
using System.Numerics;
using NModbus;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ModbusTcpSlave
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, eventArgs) => cts.Cancel();
            try
            {
                StartModbusTcpSlave();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        /// <summary>
        ///     Simple Modbus TCP slave example.
        /// </summary>
        public static void StartModbusTcpSlave()
        {
            int port = 502;
            IPAddress address = new IPAddress(new byte[] { 172, 20, 20, 55 });

            // YAML 파일 읽기
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)  // PascalCase로 변환
                .Build();

            var configFilePath = "register_info.yaml"; // YAML 파일 경로 설정
            var yamlContent = File.ReadAllText(configFilePath);
            var registers = deserializer.Deserialize<List<RegisterConfig>>(yamlContent);

            // create and start the TCP slave
            TcpListener slaveTcpListener = new TcpListener(address, port);
            slaveTcpListener.Start();

            IModbusFactory factory = new ModbusFactory();
            IModbusSlaveNetwork network = factory.CreateSlaveNetwork(slaveTcpListener);
            IModbusSlave slave1 = factory.CreateSlave(1);
            //IModbusSlave slave2 = factory.CreateSlave(2);

            network.AddSlave(slave1);
            //network.AddSlave(slave2);

            // 레지스터 값 초기화 및 랜덤 값 생성 로직 추가
            var random = new Random();
            foreach (var reg in registers)
            {
                ushort[] values = new ushort[1];
                values[0] = (ushort)random.Next(reg.ValueMin, reg.ValueMax + 1);
                slave1.DataStore.HoldingRegisters.WritePoints(reg.RegisterAddress, values);
            }

            network.ListenAsync().GetAwaiter().GetResult();

            // prevent the main thread from exiting
            Thread.Sleep(Timeout.Infinite);
        }

    }

    // YAML 파일 구조를 위한 클래스
    public class RegisterConfig
    {
        public ushort RegisterAddress { get; set; }
        public int Byte { get; set; }
        public string RegisterName { get; set; }
        public string Unit { get; set; }
        public string Format { get; set; }
        public string Type { get; set; }
        public string Swap { get; set; }
        public int ValueMin { get; set; }
        public int ValueMax { get; set; }
    }
}