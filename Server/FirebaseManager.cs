using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase;
// using UnityEngine.JsonUtility;

public class FirebaseManager : MonoBehaviour
{
    
    public class Data               // 보낼 데이터 클래스, 현재는 
                                    // id : 사용자 입력 id
                                    // time : 걸린 시간
    {
        public string id;
        public string time;

        public Data(string id, string time)
        {
            this.id = id;
            this.time = time;
        }
    }
    

    private DatabaseReference reference;

    List<string> dataList = new List<string>();      // 데이터를 저장할 리스트   

    private void setReference()                         // 설정에 적어둔 root reference를 가져옴
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void WriteNewData(string id, string time)    // 데이터를 보낼때 호출 (순서대로 id 와 time)
    {
        setReference();
        Data data = new Data(id, time);                 // 데이터 생성
        string json = JsonUtility.ToJson(data);         // json으로 변환
        reference.Child("data").Child(id).SetRawJsonValueAsync(json);   // 데이터베이스에 저장
        /*
            root
                data
                    id (자동증가)
                        id : id
                        time : time
        */
    }
    // Task task;
    public void LoadData()                  // return type : List<string> (json 형태의 string)
    {
        setReference();
        
        reference.Child("data").GetValueAsync().ContinueWith(task =>    // 데이터베이스에서 데이터를 가져옴 (root -> data 에있는 것들 모두.)
                                                                        // => lambda 표현식임. GetValueAsync()는 Task<DataSnapshot>을 반환함. ContinueWith는 Task를 반환함.
                                                                        // 중요 : 이거 "thread"로 돌아감. 즉, task가 끝나기 전에 다음 코드가 실행될 수 있음. 이거떔에 시간 쪼까 걸렸고마잉.
                                                                        // 해당 task를 lambda를 통해 task 변수에 저장 후 상태판단.
                                                                        // 그냥 firebase 에서 지원해주는 함수이므로 documentation을 참조하도록.
        {
            if (task.IsFaulted)                                         // load 실패시
            {
                Debug.Log("error");
            }
            else if (task.IsCompleted)                                  // true 일시
            {
                DataSnapshot snapshot = task.Result;                    // task의 결과를 DataSnapshot으로 저장(DataSnapshot은 firebase에서 지원해주는 클래스로 데이터를 가져올때 사용)
                foreach (DataSnapshot dataSnap in snapshot.Children)
                {
                    string json = dataSnap.GetRawJsonValue();           // Json To RawData
                    Debug.Log(json.ToString());
                    dataList.Add(json);                                 // RawData To List
                }
            
            }
        });

    }

    IEnumerator testDataSend()                      //데이터 전송 테스트를 위한 coroutine
    {
        while (true)
        {
            
            WriteNewData("2", "2");
            yield return new WaitForSeconds(1f);
        }
    }

}