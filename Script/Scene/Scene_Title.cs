using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Title : MonoBehaviour
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

        SceneManager.LoadScene("Title");
    }
}
