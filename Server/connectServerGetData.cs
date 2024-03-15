using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;

public class connectServerGetData : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private byte[] receiveBuffer = new byte[1024];

    private void Start()
    {
        ConnectToServer("10.10.1.58", 5000); // 서버 IP 주소와 포트 번호에 맞게 수정 필요
    }

    private void Update()
    {
        if (stream != null && stream.DataAvailable)
        {
            int bytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
            string receivedData = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);
            
            // 받은 데이터 처리
            Debug.Log("Received data: " + receivedData);

            // 연결 종료 (필요한 경우)
            DisconnectFromServer();
        }
    }

    public void ConnectToServer(string ipAddress, int port)
    {
        try
        {
            client = new TcpClient();
            client.Connect(ipAddress, port);
            
            stream = client.GetStream();

            string[] inputDataStr = gameObject.GetComponent<rank>().lists.split(',');
            
			// 입력 데이터 전송
			byte[] sendDataBytes = Encoding.ASCII.GetBytes(inputDataStr);
			stream.Write(sendDataBytes, 0, sendDataBytes.Length);
			
			Debug.Log("Sent data: " + inputDataStr);
        }
        catch (Exception e)
        {
        	Debug.LogError("Error connecting to server: " + e.Message);
        	DisconnectFromServer();
    	}
	}

	public void DisconnectFromServer()
	{
	    if (stream != null)
	    {
	        stream.Close();
	        stream.Dispose();
	    }

	    if (client != null && client.Connected)
	    {
	        client.Close();
	    }
	}
}
