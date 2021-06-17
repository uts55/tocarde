using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_title : MonoBehaviour
{
    public Animator ani;
    public void ChangeScene()
    {
        StartCoroutine(change());
    }
    IEnumerator change()
    {

        yield return new WaitForSeconds(0.8f);
        ani.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Main_Title");
    }
}

