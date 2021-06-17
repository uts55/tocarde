using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class HealAlone : MonoBehaviour
{
    public float healrange;
    public float healamount;
    public float healtime;
    public GameObject carrot;

    Attack attack;
    internal bool isHeal;
    internal List<Collider2D> list = new List<Collider2D>();
    Stat allystat;
    internal bool HealAv;

    // Start is called before the first frame update
    void Start()
    {
        Check();
        HealAv = true;
        attack = GetComponent<Attack>();
        attack.targettag = "Ally";
        attack.targettag2 = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(list.Count <= 1)
        {
            Check();
        }
        if(list[0] == null)
        {
            align();
        }
        if(list[0].tag != gameObject.tag)
        {
            align();
        }
        else if(list[0].tag == gameObject.tag)
        {
            if(allystat != null)
            {
                if (allystat.health >= allystat.maxHealth)
                {
                    align();
                }
                else if (allystat.health < allystat.maxHealth)
                {
                    if (HealAv == true)
                    {
                        isHeal = true;
                        GameObject shoot = Instantiate(carrot, transform.position, Quaternion.identity);
                        shoot.SendMessage("GetHeal", healamount);
                        shoot.SendMessage("GetTarget", list[0].gameObject);
                        StartCoroutine(Wait(healtime));
                    }
                    else if (HealAv == false)
                    {
                        isHeal = false;
                    }
                }
            }
            else if(allystat== null)
            {
                align();
            }
        }
    }

    public void Check()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, healrange);
        list.AddRange(targets);
    }
    void align()
    {
        list.RemoveAt(0);
        allystat = list[0].GetComponent<Stat>();
    }
    IEnumerator Wait(float time)
    {
        HealAv = false;
        yield return new WaitForSeconds(time);
        HealAv = true;
    }
}
