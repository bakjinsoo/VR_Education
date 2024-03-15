using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public float GameTime = 60f;
    public Text GameTimeText;
    public GameObject Alert_Pannel;
    public Text text;
    public int time_score=0;
    public bool pass=false;
    public int time_once = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        GameTime -= Time.deltaTime;
        GameTimeText.text = "Time : " + (int)GameTime;
        if (pass)
        {
            if (GameTime > 48&&time_once==0)
            {
                Alert_Pannel.SetActive(true);
                text.text = "축하합니다!\n S클래스의 성적으로 클리어하셨습니다.";
                time_once++;
                time_score += 1000;
        }
            else if (GameTime > 36 && time_once == 0)
            {
                Alert_Pannel.SetActive(true);
                text.text = "축하합니다!\n A클래스의 성적으로 클리어하셨습니다.";
                time_once++;
                time_score += 500;
            }
            else if (GameTime > 24 && time_once == 0)
            {
                Alert_Pannel.SetActive(true);
                text.text = "축하합니다!\n B클래스의 성적으로 클리어하셨습니다.";
                time_once++;
                time_score += 250;

            }
            else if (GameTime > 12 && time_once == 0)
            {
                Alert_Pannel.SetActive(true);
                text.text = "축하합니다!\n C클래스의 성적으로 클리어하셨습니다.";
                time_once++;
                time_score += 125;
            }
            else if (GameTime < 2)
            {
                Alert_Pannel.SetActive(true);
                text.text = "다시한번 수강하세요.";
            }
        }
        if (GameTime < 2)
        {
            Alert_Pannel.SetActive(true);
            text.text = "다시한번 수강하세요.";
        }
    }
}
