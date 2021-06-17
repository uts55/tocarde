using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject gotcha_panel;
    public GameObject card_panel;
    public GameObject gem_panel;
    public GameObject gold_panel;
    public GameObject ad_panel;

    //골드, 젬 표시
    public TextMeshProUGUI gold_text;
    public TextMeshProUGUI gem_text;

    //public GameObject button_panel;

    // Start is called before the first frame update
    void Start()
    {
        TextRefresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //뽑기창 오픈
    public void GotchaOpen()
    {
        gotcha_panel.SetActive(true);
        card_panel.SetActive(false);
        gem_panel.SetActive(false);
        gold_panel.SetActive(false);
        ad_panel.SetActive(false);
    }


    //카드창 오픈
    public void CardOpen()
    {
        gotcha_panel.SetActive(false);
        card_panel.SetActive(true);
        gem_panel.SetActive(false);
        gold_panel.SetActive(false);
        ad_panel.SetActive(false);
    }


    //보석창 오픈
    public void GemOpen()
    {
        gotcha_panel.SetActive(false);
        card_panel.SetActive(false);
        gem_panel.SetActive(true);
        gold_panel.SetActive(false);
        ad_panel.SetActive(false);
    }


    //골드창 오픈
    public void GoldOpen()
    {
        gotcha_panel.SetActive(false);
        card_panel.SetActive(false);
        gem_panel.SetActive(false);
        gold_panel.SetActive(true);
        ad_panel.SetActive(false);
    }

    //광고창 오픈
    public void AdOpen()
    {
        gotcha_panel.SetActive(false);
        card_panel.SetActive(false);
        gem_panel.SetActive(false);
        gold_panel.SetActive(false);
        ad_panel.SetActive(true);
    }

    //text 최신화
    public void TextRefresh()
    {
        gold_text.text = GameData.Instance.basic_data.account_gold.ToString();
        gem_text.text = GameData.Instance.basic_data.account_gem.ToString();
    }
}
