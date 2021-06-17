using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class stage1_1 : MonoBehaviour
{
    public int stageNum;
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Gem;
    public Animator ani;
    internal bool isOffence;
    public int prevStageNum;
    public GameObject[] Unlock;
    public GameObject[] Lock;
    int progress;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        progress = GameData.Instance.basic_data.game_progress - prevStageNum;
        for (int i = 1; i < Unlock.Length; i++)
        {
            if (i <= progress)
            {
                Unlock[i].SetActive(true);
                Lock[i].SetActive(false);
            }
            else
            {
                Unlock[i].SetActive(false);
                Lock[i].SetActive(true);
            }
        }
        Gold.text = (GameData.Instance.basic_data.account_gold).ToString();
        Gem.text = (GameData.Instance.basic_data.account_gem).ToString();
    }

    public void ChangeScene()
    {
        StartCoroutine(change());
    }
    IEnumerator change()
    {
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        if (stageNum == 0)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
    public void GetStage(int num)
    {
        stageNum = num;
    }
    public void GetOffence(bool a)
    {
        isOffence = a;
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("AllyCastle"))
            StartCoroutine(delete());
    }       
    IEnumerator delete()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
