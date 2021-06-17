using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    Slider slider;
    SoundSystem soundsystem;
    // Start is called before the first frame update
    void Start()
    {
        soundsystem = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundSystem>();
        slider = GetComponent<Slider>();
        if (gameObject.tag == "EffectControl")
            slider.value = soundsystem.EffectsoundValue;
        else if (gameObject.tag == "BackControl")
            slider.value = soundsystem.BacksoundValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "EffectControl")
        {
            soundsystem.EffectsoundValue = slider.value;
            slider.value = soundsystem.EffectsoundValue;
        }
        else if (gameObject.tag == "BackControl")
        {
            soundsystem.BacksoundValue = slider.value;
            slider.value = soundsystem.BacksoundValue;
        }
    }
}
