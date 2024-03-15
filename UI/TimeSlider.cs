using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeSlider : MonoBehaviour
{
    Slider slider;
    public float sliderTime = 60f;
    // Start is called before the first frame update
    TimeManager timeManager;
    void Start()
    {
        slider = GetComponent<Slider>();
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }
    int once = 0;
    // Update is called once per frame
    void Update()
    {
        
        if (slider.value > 0)
        {
            slider.value = timeManager.GameTime - Time.deltaTime;
            sliderTime= slider.value;
        }
        else
        {
            
        }
        if (sliderTime < 12f&&once==0)
        {
            GameObject.Find("SoundManager").GetComponent<DD_Sound_Manager>().playDrown();
            Debug.Log("²¿¸£¸¤");
            once++;
        }
    }
}
