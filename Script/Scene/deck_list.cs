using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deck_list : MonoBehaviour
{
    public Animator ani;
    public void ChangeScene()
    {
        StartCoroutine(change());
    }
    IEnumerator change()
    {
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Deck_list");
    }
}
