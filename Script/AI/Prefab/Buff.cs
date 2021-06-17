using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public float BuffRange;
    public float Buffattack;
    public float Buffdefence;
    public float Buffspeed;
    public float Buffattackspeed;

    Collider2D[] ally;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ally = Physics2D.OverlapCircleAll(transform.position, BuffRange);
        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i].tag == gameObject.tag)
            {
                buff(ally[i]);
            }
        }
    }

    void buff(Collider2D a)
    {
        if(Buffattack > 0)
        {
            a.SendMessage("BuffAttack", Buffattack);
        }
        if (Buffdefence > 0)
        {
            a.SendMessage("BuffDefence", Buffdefence);
        }
        if (Buffspeed > 0)
        {
            a.SendMessage("BuffSpeed", Buffspeed);
        }
        if (Buffattackspeed > 0)
        {
            a.SendMessage("BuffAttackSpeed", Buffattackspeed);
        }
    }
}
