using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGold : MonoBehaviour
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

    //돈뽑기 10000
    public void GetMoney20000()
    {
        if (GameData.Instance.basic_data.account_gem >= 200)
        {
            GameData.Instance.basic_data.account_gem -= 200;
            GameData.Instance.basic_data.account_gold += 20000;
        }
        else
        {
            NotEnoughGem();
        }
    }

    //돈뽑기 50000
    public void GetMoney50000()
    {
        if (GameData.Instance.basic_data.account_gem >= 475)
        {
            GameData.Instance.basic_data.account_gem -= 475;
            GameData.Instance.basic_data.account_gold += 50000;
        }
        else
        {
            NotEnoughGem();
        }
    }

    //돈뽑기 100000
    public void GetMoney100000()
    {
        if (GameData.Instance.basic_data.account_gem >= 900)
        {
            GameData.Instance.basic_data.account_gem -= 900;
            GameData.Instance.basic_data.account_gold += 100000;
        }
        else
        {
            NotEnoughGem();
        }
    }

    //보석 부족할때
    public void NotEnoughGem()
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
        if(time >= 3.0f)
        {
            panel.SetActive(false);
            return;
        }
    }
}
