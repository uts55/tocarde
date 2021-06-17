using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading_bar : MonoBehaviour
{
    public Slider progressbar;
    public TextMeshProUGUI text;
    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            yield return null;
            if (progressbar.value < 1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime / 2 );  // Mathf.MoveTowards(현위치, 도착지점, 속도)
                text.text = Mathf.Ceil(progressbar.value * 100) + "%";
            }

            else
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}