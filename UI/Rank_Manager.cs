using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rank_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject FirebaseManager;
    [SerializeField] GameObject RankingPanel;
    [SerializeField] GameObject Window_Manager;
    [SerializeField] GameObject TimeManager_Manager;
    public bool is_active = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Window_Manager.GetComponent<Window_Hit_Manage>().is_broken && is_active)
        {
            RankingPanel.SetActive(true);
            float recordTime = 60 - TimeManager_Manager.GetComponent<TimeSlider>().sliderTime;
            string rank = "";
            if (recordTime <= 10)
            {
                rank = "A";
            }
            else if(recordTime <= 20)
            {
                rank = "B";
            }
            else if(recordTime< 30)
            {
                rank = "C";
            }
            else
            {
                rank = "D";
            }
            FirebaseManager.GetComponent<FirebaseManager>().WriteNewData("User_MK", 5.9f, 11.3f, recordTime, 1, rank);

            FirebaseManager.GetComponent<FirebaseManager>().LoadData();
            StartCoroutine(FirebaseManager.GetComponent<FirebaseManager>().setRank());
            is_active= false;
        }
    }
}
