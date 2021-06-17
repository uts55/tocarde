using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMonMain : MonoBehaviour
{
    new AudioSource audio;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audio = GetComponent<AudioSource>();
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main_Title" || SceneManager.GetActiveScene().name == "Deck_list" || SceneManager.GetActiveScene().name == "Stage_select" || SceneManager.GetActiveScene().name == "Stage_detail" || SceneManager.GetActiveScene().name == "Stage_detail2" || SceneManager.GetActiveScene().name == "Stage_detail3" || SceneManager.GetActiveScene().name == "shop")
        {
            if (start == true)
            {
                audio.Play();
                start = false;
            }
        }
        else
        {
            audio.Stop();
            start = true;
        }
    }
}
