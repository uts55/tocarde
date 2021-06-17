using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSkill : MonoBehaviour
{
    Attack attack;
    Stat stat;
    public GameObject bullet;
    public GameObject specialbullet;
    public float cooltime;
    public SpriteRenderer zabelin;
    bool startcool;
    public float timer;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        stat = GetComponent<Stat>();
        startcool = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooltime)
        {
            attack.Object = specialbullet;
            zabelin.color = new Color(255, 0, 0);
        }
        else
        {
            attack.Object = bullet;
            zabelin.color = new Color(255, 255, 255);
        }
    }
    void Check()
    {
        if(attack.Object == specialbullet)
        {
            timer = 0;
        }
    }
    void EffOn()
    {
        if (attack.Object == specialbullet)
        {
            Effect.SetActive(true);
        }
    }
    void EffOff()
    {
        if (attack.Object == specialbullet)
        {
            Effect.SetActive(false);
        }
    }
}