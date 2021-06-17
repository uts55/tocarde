using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChanger : MonoBehaviour
{
    new AudioSource[] audio;
    SoundSystem soundsystem;
    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponentsInChildren<AudioSource>();
        if (GameObject.FindGameObjectWithTag("SoundSystem"))
        {
            soundsystem = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundSystem>();
            for (int i = 0; i < audio.Length; i++)
            {
                audio[i].volume = soundsystem.EffectsoundValue;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (soundsystem != null)
        {
            for (int i = 0; i < audio.Length; i++)
            {
                audio[i].volume = soundsystem.EffectsoundValue;
            }
        }
    }
}
