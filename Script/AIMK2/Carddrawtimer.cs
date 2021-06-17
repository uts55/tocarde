using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carddrawtimer : MonoBehaviour
{
    Image image;
    public GameObject back;
    public bool background;
    public float coolTime;
    bool isStart = false;
    float leftTime;
    float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime * speed;
                if (leftTime < 0)
                {
                    leftTime = 0;
                    isStart = true;
                }
            }
        float ratio = 1.0f - (leftTime / coolTime);
        image.fillAmount = ratio;
        
        
        if(background == true)
        {
            back.SetActive(true);
        }
        else
        {
            back.SetActive(false);
        }
    }
    public void StartCoolTime(float time)
    {
        coolTime = time;
        leftTime = time;
        isStart = true;
    }
}
