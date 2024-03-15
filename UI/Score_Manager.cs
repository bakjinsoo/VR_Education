using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Score_Manager : MonoBehaviour
{
    public int total_score=0;
    public GameObject Alert_Pannel;
    public Text Alert_text;
    public Text score_text;//total score 변수 업데이트
    public GameObject Crack_Alert_Pannel;
    public Text crack_text;
    public int edge_key = 0;
    public GameObject window_manager;
    public GameObject Grade_Pannel;
    public Text Grade_Text;
    public GameObject TimeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "Score : " + total_score;
        if(window_manager.GetComponent<Window_Hit_Manage>().is_broken==true&&edge_key==1)
        {
            total_score += 5000;
            Debug.Log("창문탈출성공");
            Alert_Pannel.SetActive(true);
            GameObject.Find("SoundManager").GetComponent<DD_Sound_Manager>().playGlassBreak();
            Alert_text.text = "침수된 차에서 탈출에 성공하셨습니다! \n축하합니다!";
            if(TimeSlider.GetComponent<TimeSlider>().sliderTime>48f)
            {
                Grade_Pannel.SetActive(true);
                Grade_Text.text = "S등급의 성적으로\n클리어하셨습니다.";
                GameObject.Find("SoundManager").GetComponent<DD_Sound_Manager>().playSuccess();

            }
            else if (TimeSlider.GetComponent<TimeSlider>().sliderTime > 36f)
            {
                Grade_Pannel.SetActive(true);
                Grade_Text.text = "A등급의 성적으로\n클리어하셨습니다.";
                GameObject.Find("SoundManager").GetComponent<DD_Sound_Manager>().playSuccess();
            }
            else if (TimeSlider.GetComponent<TimeSlider>().sliderTime > 24f)
            {
                Grade_Pannel.SetActive(true);
                Grade_Text.text = "B등급의 성적으로\n클리어하셨습니다.";
                GameObject.Find("SoundManager").GetComponent<DD_Sound_Manager>().playSuccess();
            }
            else if (TimeSlider.GetComponent<TimeSlider>().sliderTime > 12f)
            {
                Grade_Pannel.SetActive(true);
                Grade_Text.text = "C등급의 성적으로\n클리어하셨습니다.";
                GameObject.Find("SoundManager").GetComponent<DD_Sound_Manager>().playSuccess();
            }
        }
        else if (TimeSlider.GetComponent<TimeSlider>().sliderTime < 2f)
        {
            Grade_Pannel.SetActive(true);
            Grade_Text.text = "실패";
            Alert_Pannel.SetActive(true);
            Alert_text.text = "침수된 차에서 탈출에 실패하셨습니다. \n다시해보세요.";
        }
        
    }
    
    
}
