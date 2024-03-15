import socket
import numpy as np
import tensorflow as tf

# 모델 로드
model = tf.keras.models.load_model('rnn_model.h5')

# 서버 설정
HOST = '10.10.1.58'  # 서버 IP 주소 (수정 필요)
PORT = 5000         # 포트 번호 (수정 필요)

# 소켓 생성 및 바인딩
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind((HOST, PORT))
server_socket.listen(1)

print(f"서버가 {HOST}:{PORT}에서 실행 중입니다.")

while True:
    # 클라이언트로부터 연결 요청 대기
    client_socket, addr = server_socket.accept()
    print(f"클라이언트가 접속했습니다: {addr}")

    try:
        # 클라이언트로부터 입력 데이터 수신
        data = client_socket.recv(1024).decode()
        input_data = list(map(float, data.split(',')))

        # 입력 데이터 전처리 및 모델 예측
        input_data_arr = np.array(input_data).reshape(1, 3)
        prediction = model.predict(input_data_arr)

        # 예측 결과 전송
        result_str = ','.join(str(val) for val in prediction[0])
        client_socket.sendall(result_str.encode())

    except Exception as e:
        print("예외 발생:", str(e))

    finally:
        # 연결 종료 및 소켓 닫기
        client_socket.close()
