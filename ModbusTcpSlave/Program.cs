// 네임스페이스 선언
using System.Net; // 네트워크 관련 기능을 사용하기 위한 네임스페이스
using System.Net.Sockets; // 소켓 통신 기능을 사용하기 위한 네임스페이스
using Microsoft.Win32; // 레지스트리 접근 기능을 사용하기 위한 네임스페이스
using System.Numerics; // 복소수 및 벡터 연산 기능을 사용하기 위한 네임스페이스
using NModbus; // Modbus 프로토콜 구현 라이브러리
using YamlDotNet.Serialization; // YAML 데이터 직렬화/역직렬화 라이브러리
using YamlDotNet.Serialization.NamingConventions; // YAML 데이터 필드 이름 변환 규칙 라이브러리

// ModbusTcpSlave 네임스페이스 선언
namespace ModbusTcpSlave
{
    // Program 클래스 선언
    class Program
    {
        // Main 메서드 (프로그램 시작점)
        static async Task Main(string[] args)
        {
            // Ctrl+C 입력 시 프로그램 종료 처리
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, eventArgs) => cts.Cancel();
            try
            {
                // Modbus TCP 슬레이브 시작
                StartModbusTcpSlave();
            }
            catch (Exception e) // 예외 발생 시 처리
            {
                Console.WriteLine(e.Message); // 예외 메시지 출력
            }
            Console.WriteLine("Press any key to continue..."); // 사용자에게 키 입력 대기 메시지 출력
            Console.ReadKey(); // 키 입력 대기
        }

        /// <summary>
        ///     Modbus TCP 슬레이브 시작 메서드
        /// </summary>
        public static void StartModbusTcpSlave()
        {
            // 슬레이브 IP 주소 및 포트 설정
            int port = 502; // Modbus TCP 기본 포트
            IPAddress address = new IPAddress(new byte[] { 172, 20, 20, 55 }); // 슬레이브 IP 주소 설정

            // YAML 파일 읽기 (레지스터 정보)
            var deserializer = new DeserializerBuilder() // YAML 역직렬화 설정
                .WithNamingConvention(PascalCaseNamingConvention.Instance)  // PascalCase 명명 규칙 사용
                .Build(); // 설정 완료

            var configFilePath = "register_info.yaml"; // YAML 파일 경로 설정
            var yamlContent = File.ReadAllText(configFilePath); // YAML 파일 내용 읽기
            var registers = deserializer.Deserialize<List<RegisterConfig>>(yamlContent); // 레지스터 정보 역직렬화

            // TCP 슬레이브 생성 및 시작
            TcpListener slaveTcpListener = new TcpListener(address, port); // TCP 리스너 생성
            slaveTcpListener.Start(); // 리스닝 시작

            IModbusFactory factory = new ModbusFactory(); // Modbus 팩토리 생성
            IModbusSlaveNetwork network = factory.CreateSlaveNetwork(slaveTcpListener); // 슬레이브 네트워크 생성
            IModbusSlave slave1 = factory.CreateSlave(1); // 슬레이브 ID 1 생성
            //IModbusSlave slave2 = factory.CreateSlave(2); // 추가 슬레이브 생성 (주석 처리됨)

            network.AddSlave(slave1); // 슬레이브 1 추가
            //network.AddSlave(slave2); // 추가 슬레이브 추가 (주석 처리됨)

            // 레지스터 값 초기화 및 랜덤 값 생성
            var random = new Random(); // 랜덤 값 생성기
            foreach (var reg in registers) // 각 레지스터에 대해
            {
                ushort[] values = new ushort[1]; // 레지스터 값 배열
                values[0] = (ushort)random.Next(reg.ValueMin, reg.ValueMax + 1); // 랜덤 값 생성
                slave1.DataStore.HoldingRegisters.WritePoints(reg.RegisterAddress, values); // 레지스터 값 설정
            }

            // 슬레이브 리스닝 시작
            network.ListenAsync().GetAwaiter().GetResult();

            // 메인 스레드 종료 방지 (무한 대기)
            Thread.Sleep(Timeout.Infinite);
        }
    }

    // YAML 파일 구조를 위한 클래스
    public class RegisterConfig
    {
        public ushort RegisterAddress { get; set; } // 레지스터 주소
        public int Byte { get; set; } // 바이트 크기
        public string RegisterName { get; set; } // 레지스터 이름
        public string Unit { get; set; } // 단위
        public string Format { get; set; } // 형식
        public string Type { get; set; } // 데이터 타입
        public string Swap { get; set; } // 스왑 방식
        public int ValueMin { get; set; } // 최소값
        public int ValueMax { get; set; } // 최대값
    }
}