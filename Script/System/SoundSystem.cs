using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSystem : MonoBehaviour
{
    public float EffectsoundValue;
    public float BacksoundValue;

    string SceneName;
    string tmp;
    List<GameObject> Effect = new List<GameObject>();
    List<AudioSource> Effectsound = new List<AudioSource>();
    GameObject[] EffectArray;
    public float effecttmp;

    List<GameObject> Back = new List<GameObject>();
    List<AudioSource> Backsound = new List<AudioSource>();
    GameObject[] BackArray;
    public float backtmp;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        EffectsoundValue = 1.0f;
        BacksoundValue = 1.0f;
        SceneName = SceneManager.GetActiveScene().name;
        EffectArray = GameObject.FindGameObjectsWithTag("EffectAudio");
        Effect.AddRange(EffectArray);
        BackArray = GameObject.FindGameObjectsWithTag("BackAudio");
        Back.AddRange(BackArray);

        for (int i = 0; i < Effect.Count; i++)
        {
            Effectsound.Add(Effect[i].gameObject.GetComponent<AudioSource>());
        }
        for (int i = 0; i < Back.Count; i++)
        {
            Backsound.Add(Back[i].gameObject.GetComponent<AudioSource>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        tmp = SceneManager.GetActiveScene().name;
        if(SceneName != tmp)
        {
            Effect.RemoveRange(0,Effect.Count);
            Back.RemoveRange(0, Back.Count);
            Effectsound.RemoveRange(0, Effectsound.Count);
            Backsound.RemoveRange(0, Backsound.Count);
            EffectArray = GameObject.FindGameObjectsWithTag("EffectAudio");
            Effect.AddRange(EffectArray);

            BackArray = GameObject.FindGameObjectsWithTag("BackAudio");
            Back.AddRange(BackArray);

            for (int i = 0; i < Effect.Count; i++)
            {
                Effectsound.Add(Effect[i].gameObject.GetComponent<AudioSource>());
            }
            for (int i = 0; i < Back.Count; i++)
            {
                Backsound.Add(Back[i].gameObject.GetComponent<AudioSource>());
            }
            SceneName = tmp;
        }
        for (int i = 0; i < Effectsound.Count; i++)
        {
            if(Effectsound[i] != null)
                Effectsound[i].volume = EffectsoundValue;
        }
        for (int i = 0; i < Backsound.Count; i++)
        {
            if (Backsound[i] != null)
                Backsound[i].volume = BacksoundValue;
        }
    }
}
