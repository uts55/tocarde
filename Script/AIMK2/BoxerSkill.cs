using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerSkill : MonoBehaviour
{
    Attack attack;
    Stat stat;
    float rate;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        stat = GetComponent<Stat>();
        rate = 35;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Setrate()
    {
        float random = Random.Range(0, 100);
        if (random < rate)
        {
            Effect.SetActive(true);
            attack.stun = 1;
        }
    }
    void ReSetrate()
    {
        attack.stun = 0;
        Effect.SetActive(false);
    }
}
