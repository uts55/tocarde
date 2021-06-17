using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScale : MonoBehaviour
{
    public TextMeshProUGUI text;
    float tmptime;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "X 1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void button()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 2f;
            text.text = "X 2";
        }
        else if(Time.timeScale == 2)
        {
            Time.timeScale = 4;
            text.text = "X 4";
        }
        else if(Time.timeScale == 4)
        {
            Time.timeScale = 1;
            text.text = "X 1";
        }
    }
    public void Stop()
    {
        tmptime = Time.timeScale;
        Time.timeScale = 0;
    }
    public void play()
    {
        if(tmptime == 0)
        {
            tmptime = 1;
        }
        Time.timeScale = tmptime;
        tmptime = 0;
    }
}
