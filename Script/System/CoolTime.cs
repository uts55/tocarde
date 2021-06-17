using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    public float turn_time = 10.5f;
    public float time;
    public float ratio;

    Image image;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        image = this.transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += 1.0f * Time.deltaTime;

        if (time >= 10.5f)
        {
            time = 0;
        }
        ratio = 1 - (time / turn_time);
        image.fillAmount = ratio;
    }
}
