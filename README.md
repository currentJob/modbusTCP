## Modbus TCP 통신 예제

NModbus 라이브러리를 사용하여 Modbus TCP 클라이언트 및 슬레이브를 구현하는 예제 코드

### 주요 기능

**클라이언트 (modbus\_test)**

*   Modbus TCP 서버 (슬레이브)에 연결
*   홀딩 레지스터 읽기
*   레지스터 쓰기 (미구현)
*   연결 및 통신 상태 표시

**슬레이브 (ModbusTcpSlave)**

*   Modbus TCP 서버 (슬레이브) 실행
*   'register\_info.yaml' 파일에서 레지스터 구성 정보 로드
*   클라이언트의 레지스터 읽기/쓰기 요청 처리
*   레지스터 값 랜덤 초기화

### 사용 방법

1.  **클라이언트 실행:**
    *   modbus\_test 프로젝트를 빌드하고 실행
    *   텍스트 상자에 슬레이브의 IP 주소, 포트 번호, 슬레이브 ID, 레지스터 주소, 레지스터 개수를 입력
    *   "Connect" 버튼을 눌러 슬레이브에 연결
    *   "Read" 버튼을 눌러 홀딩 레지스터 값 읽기

2.  **슬레이브 실행:**
    *   NModbus\_Slave2 프로젝트를 빌드 후 실행
    *   슬레이브는 자동으로 'register\_info.yaml' 파일을 읽어 레지스터를 구성하고 클라이언트의 요청을 대기
