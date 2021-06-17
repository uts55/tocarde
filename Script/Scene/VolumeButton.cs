using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;
    Image thisimage;
    bool soundOn;
    SoundSystem soundsystem;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        thisimage = GetComponent<Image>();
        slider = GetComponentInChildren<Slider>();
        soundsystem = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundSystem>();
        if (slider.value > 0)
            soundOn = true;
        else if (slider.value == 0)
            soundOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(soundOn == true)
        {
            thisimage.sprite = On;
        }
        else if(soundOn == false)
        {
            thisimage.sprite = Off;
        }

        if (slider.value > 0)
            soundOn = true;
        else if (slider.value == 0)
            soundOn = false;
    }
    public void Button()
    {
        if (soundOn == true)
        {
            if (gameObject.tag == "EffectControl")
            {
                soundsystem.effecttmp = soundsystem.EffectsoundValue;
                soundOn = false;
                slider.value = 0;
            }
            else if (gameObject.tag == "BackControl")
            {
                soundsystem.backtmp = soundsystem.BacksoundValue;
                soundOn = false;
                slider.value = 0;
            }
        }
        else if (soundOn == false)
        {
            if (gameObject.tag == "EffectControl")
            {
                slider.value = soundsystem.effecttmp;
                soundOn = true;
                soundsystem.effecttmp = 1;
            }
            else if (gameObject.tag == "BackControl")
            {
                slider.value = soundsystem.backtmp;
                soundOn = true;
                soundsystem.backtmp = 1;
            }
        }
    }
}
