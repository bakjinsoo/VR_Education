using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window_Hit_Management : MonoBehaviour
{
    public int window_key = 0;
    public GameObject window;
    public GameObject hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");
        if(this.gameObject.tag=="edge")
        {
            window_key++;
            float z = Random.Range(1,10)*0.05f;
            float y=Random.Range(1, 10)*0.05f;
            GameObject.Find("SoundManager").GetComponent<DD_Sound_Manager>().playGlassHit();
            Vector3 pos=new Vector3(collision.transform.position.x-0.08f,collision.transform.position.y,collision.transform.position.z);
            Instantiate(hit,pos,Quaternion.Euler(0,-90.0f,0));

                Debug.Log("충돌감지");
            GameObject.Find("ScoreManager").GetComponent<Score_Manager>().total_score+=200;

        }
        else if(this.gameObject.tag == "window")
        {
            Debug.Log("충돌감지");
            GameObject.Find("ScoreManager").GetComponent<Score_Manager>().total_score -= 100;
        }
    }
}
