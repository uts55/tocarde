using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGem : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetGem1000()
    {
        GameData.Instance.basic_data.account_gem += 1000;
        GameData.Instance.SaveData();
    }

    public void GetGem2000()
    {
        GameData.Instance.basic_data.account_gem += 2000;
        GameData.Instance.SaveData();
    }


    public void GetGem5000()
    {
        GameData.Instance.basic_data.account_gem += 5000;
        GameData.Instance.SaveData();
    }

    //뭔가 문제가 발생함
    public void Problem()
    {
        //이미 켜져있음
        if (panel.activeSelf == true)
        {
            return;
        }

        //아니면
        float time = 0;
        time += Time.deltaTime * 1.0f;
        panel.SetActive(true);
        if (time >= 3.0f)
        {
            panel.SetActive(false);
            return;
        }
    }
}
