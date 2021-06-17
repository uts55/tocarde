using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiSkill : MonoBehaviour
{
    Attack attack;
    Stat stat;
    Animator ani;
    float rand;
    public AttackType attacktype;
    AttackType Tmpattacktype;
    public GameObject Object;
    GameObject TmpObject;
    bool a;
    bool b = true;
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        ani = GetComponent<Animator>();
        stat = GetComponent<Stat>();
        Tmpattacktype = attack.attacktype;
        TmpObject = attack.Object;
    }
    void Update()
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
        
        if (b == false)
        {
            attack.attackable = false;
        }
    }
    void CheckChange()
    {
        rand = Random.Range(0, 100);
        if (rand < stat.critical)
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
            attack.Rattack = attack.attack * 4;
        }
        else
        {
            attack.Rattack = attack.attack;
        }
    }
    void CheckFinish()
    {
            attack.attacktype = Tmpattacktype;
            if (Object != null)
            {
                attack.Object = TmpObject;
            }
        rand = 0;
        b = true;
        attack.attackable = true;
    }
}
