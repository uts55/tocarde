using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Select : MonoBehaviour
{
    public GameObject text_warning;
    public Animator ani;
    public void ChangeScene()
    {
        for (int i = 0; i < GameData.Instance.deck_size; i++)
        {
            if (GameData.Instance.unit_deck_list.list[i].unit_num == 0)
            {
                text_warning.SetActive(true);
                return;
            }
        }
        StartCoroutine(change());
    }
    IEnumerator change()
    {
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Stage_select");
    }
    public void HomeChangeScene()
    {
        for (int i = 0; i < GameData.Instance.deck_size; i++)
        {
            if (GameData.Instance.unit_deck_list.list[i].unit_num == 0)
            {
                text_warning.SetActive(true);
                return;
            }
        }
        StartCoroutine(Homechange());
    }
    IEnumerator Homechange()
    {
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Main_Title");
    }
    public void ShopChangeScene()
    {
        StartCoroutine(Shopchange());
    }
    IEnumerator Shopchange()
    {
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Shop");
    }
}
