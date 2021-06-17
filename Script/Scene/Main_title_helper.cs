using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Main_title_helper : MonoBehaviour
{
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Gem;
    // Start is called before the first frame update
    void Start()
    {
        Gold.text = (GameData.Instance.basic_data.account_gold).ToString();
        Gem.text = (GameData.Instance.basic_data.account_gem).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
