#### 클라이언트 (modbus_test)

- Modbus TCP 서버에 연결하여 데이터를 읽고 쓸 수 있는 GUI 기반 클라이언트입니다.
- 사용자가 서버의 IP 주소, 포트, 슬레이브 ID, 레지스터 주소 및 레지스터 수를 입력하여 데이터를 읽을 수 있습니다.
- IModbusClient 인터페이스를 사용하여 ModbusTcpClient 클래스를 통해 실제 Modbus TCP 통신을 처리합니다.

#### 슬레이브 (ModbusTcpSlave)

- Modbus TCP 슬레이브를 구현하여 클라이언트의 요청에 응답합니다.
- register_info.yaml 파일에서 레지스터 구성 정보를 읽어와 슬레이브의 데이터 저장소를 초기화합니다.
- PascalCaseNamingConvention을 사용하여 YAML 파일의 필드 이름을 C# 클래스의 속성 이름과 일치시킵니다.
- 레지스터 값은 난수로 초기화되며, 클라이언트 요청에 따라 값을 읽거나 쓸 수 있습니다.

---
#### 주요 파일:

- Form1.cs: 클라이언트 UI 및 이벤트 처리 로직
- Form1.Designer.cs: 클라이언트 UI 디자인
- IModbusClient.cs: Modbus 클라이언트 인터페이스
- ModbusTcpClient.cs: NModbus를 사용한 Modbus TCP 클라이언트 구현
- Program.cs (클라이언트): 클라이언트 애플리케이션 시작점
- Program.cs (슬레이브): 슬레이브 애플리케이션 시작점
- TcpClientWrapper.cs: TCP 클라이언트 래퍼 클래스
- RegisterConfig.cs: 레지스터 구성 정보를 담는 클래스
- register_info.yaml: 레지스터 구성 정보 YAML 파일