using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaSkill : MonoBehaviour
{
    Attack attack;
    Animator ani;
    public AttackType attacktype;
    AttackType Tmpattacktype;
    public GameObject Object;
    GameObject TmpObject;
    public float cooltime;
    public float healtime;
    float timer;
    float healtimer;
    bool a;
    bool b = true;
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        ani = GetComponent<Animator>();
        Tmpattacktype = attack.attacktype;
        TmpObject = attack.Object;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        healtimer += Time.deltaTime;
        if (timer > cooltime)
        {
            if (a == true)
            {
                attack.attacktype = attacktype;
                if (Object != null)
                {
                    attack.Object = Object;
                }
                a = false;
            }
        }
        else
        {
            attack.attacktype = Tmpattacktype;
            if (Object != null)
            {
                attack.Object = TmpObject;
            }
        }
        if (b == false)
        {
            attack.attackable = false;
        }
        Check();
    }
    void CheckChange()
    {
        if (timer > cooltime)
        {
            a = true;
        }
    }
    void Check()
    {
        if (attack.attacktype == attacktype && attack.Object == Object)
        {
            b = false;
            ani.Play("Attack2");
        }
        else if(healtimer > healtime)
        {
            b = false;
            ani.Play("Attack3");
        }
    }
    void CheckFinish()
    {
        timer = 0;
        b = true;
        attack.attackable = true;
    }
    void HealFinish()
    {
        healtimer = 0;
        b = true;
        attack.attackable = true;
    }
    void heal()
    {
        SendMessage("Healed", 100);
    }
}
