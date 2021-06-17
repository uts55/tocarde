using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ADManager : MonoBehaviour
{
    public GameObject buy_card;
    public GameObject buy_gem;
    public GameObject buy_gold;

    void Awake()
    {
        Advertisement.Initialize("4081593", false);
    }
    //광고 보여주기
    public void ShowAD()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    //보상형 광고 보여주기 (골드)
    public void ShowRewardGold()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAdsGold };
            Advertisement.Show("rewardedVideo", options);
        }
        else
        {
            Debug.Log("AD fail.");
        }
    }

    //광고 실행 후 결과 (골드)
    public void ResultAdsGold(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:     //실패
                {
                    Debug.Log("The ad failed.");
                }
                break;
            case ShowResult.Skipped:    //스킵함
                {
                    Debug.Log("The ad was skipped.");
                }
                break;
            case ShowResult.Finished:   //성공
                {
                    Debug.Log("The ad was successed.");
                    GameData.Instance.basic_data.account_gold += 5000;
                }
                break;
        }
    }

    //보상형 광고 보여주기 (보석)
    public void ShowRewardGem()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAdsGem };
            Advertisement.Show("rewardedVideo", options);
        }
        else
        {
            Debug.Log("AD fail.");
        }
    }

    //광고 실행 후 결과 (골드)
    public void ResultAdsGem(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:     //실패
                {
                    Debug.Log("The ad failed.");
                }
                break;
            case ShowResult.Skipped:    //스킵함
                {
                    Debug.Log("The ad was skipped.");
                }
                break;
            case ShowResult.Finished:   //성공
                {
                    Debug.Log("The ad was successed.");
                    GameData.Instance.basic_data.account_gem += 100;
                }
                break;
        }
    }

    //보상형 광고 보여주기 (뽑기)
    public void ShowRewardGotCha()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAdsGotCha };
            Advertisement.Show("rewardedVideo", options);
        }
        else
        {
            Debug.Log("AD fail.");
        }
    }

    //광고 실행 후 결과 (뽑기)
    public void ResultAdsGotCha(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:     //실패
                {
                    Debug.Log("The ad failed.");
                }
                break;
            case ShowResult.Skipped:    //스킵함
                {
                    Debug.Log("The ad was skipped.");
                }
                break;
            case ShowResult.Finished:   //성공
                {
                    Debug.Log("The ad was successed.");
                    buy_card.GetComponent<BuyCard>().AdCardGotcha();
                }
                break;
        }
    }
}
