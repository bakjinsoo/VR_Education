using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Window_Hit_Manage : MonoBehaviour
{
    public GameObject edge;
    public int edge_hit_count = 0;
    RaycastHit hit;
    float fixedY;
    public GameObject Score_Manager;
    public GameObject Alert_Pannel;
    public Text text;
    public bool is_broken = false;

    void Awake()
    {
        fixedY = transform.position.y;
    }
    void Update()
    {
        if(edge.GetComponent<Window_Hit_Management>().window_key>10)
        {
            edge_hit_count++;
            GameObject.Find("ScoreManager").GetComponent<Score_Manager>().edge_key++;
            is_broken= true;
        }


     }
}
