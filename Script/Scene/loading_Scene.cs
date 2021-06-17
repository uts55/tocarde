using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading_Scene : MonoBehaviour
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

        SceneManager.LoadScene("loading");
    }
}
