using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_detail : MonoBehaviour
{
    public Animator ani;
    public Button[] button;
    public int[] round;
    public GameObject[] Lock;
    int all = 0;
    int progress;
    private void Start()
    {
        progress = GameData.Instance.basic_data.game_progress;
        for (int i = 0; i < button.Length; i++)
        {
            int prev = all;
            all += round[i];
            if(progress < all && prev <= progress)
            {
                button[i].enabled = true;
                Lock[i].SetActive(false);
            }
            else if(prev < progress)
            {
                button[i].enabled = true;
                Lock[i].SetActive(false);
            }
            else
            {
                button[i].enabled = false;
                Lock[i].SetActive(true);
            }
        }
    }
    public void ChangeScene()
    {
        StartCoroutine(change());
    }
    IEnumerator change()
    {
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Stage_detail");
    }
    public void ChangeScene2()
    {
        StartCoroutine(change2());
    }
    IEnumerator change2()
    {
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Stage_detail2");
    }
    public void ChangeScene3()
    {
        StartCoroutine(change3());
    }
    IEnumerator change3()
    {
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Stage_detail3");
    }
}
