using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanel : MonoBehaviour
{
    float time;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            time += 1.0f * Time.deltaTime;
            if (time >= 1.5f)
            {
                time = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
