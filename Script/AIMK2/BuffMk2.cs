using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMk2 : MonoBehaviour
{
    public float BuffcoolTime;
    public float BuffRange;
    public float Buffattack;
    public float Buffdefence;
    public float Buffspeed;
    public float Buffattackspeed;

    internal bool isBuff;
    bool BuffAv;
    List<Collider2D> list = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        Check();
        BuffAv = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (list.Count == 1)
        {
            Check();
        }
        else if (list[0] == null)
        {
            align();
        }
        else if (list[0].tag != gameObject.tag)
        {
            align();
        }
        else if(list[0].GetComponent<Stat>() == null)
        {
            align();
        }
        else if (list[0].tag == gameObject.tag)
        {
            if (BuffAv == true)
            {
                isBuff = true;
                buff(list[0].gameObject);
                align();
                StartCoroutine(Wait());
            }
            else if (BuffAv == false)
            {
                isBuff = false;
            }
        }
        else
        {
            align();
        }
    }
    void Check()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, BuffRange);
        list.AddRange(targets);
    }
    void align()
    {
        list.RemoveAt(0);
    }
    IEnumerator Wait()
    {
        BuffAv = false;
        yield return new WaitForSeconds(BuffcoolTime);
        BuffAv = true;
    }
    void buff(GameObject a)
    {
        if (Buffattack > 0)
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
