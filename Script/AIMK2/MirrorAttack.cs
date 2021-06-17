using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorAttack : MonoBehaviour
{
    Stat stat;
    internal bool mirror;
    public float Mirrorattack;
    internal bool MAttack;
    GameObject target;
    float distance;
    string targettag;
    // Start is called before the first frame update
    void Start()
    {
        stat = gameObject.GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            distance = Vector2.Distance(gameObject.transform.position, target.transform.position);
        }
        if (distance > stat.range)
        {
            target = null;
        }
        if (mirror == true)
        {
            if (MAttack == true && stat.health>0)
            {
                target.SendMessage("Attacked", Mirrorattack);
                MAttack = false;
            }
        }
    }
    void getMAttack(bool a)
    {
        MAttack = a;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (target == null)
        {
            float distance = Vector2.Distance(gameObject.transform.position, collision.transform.position);

            if (gameObject.tag == "Ally")
            {
                targettag = "Enemy";
            }
            else if (gameObject.tag == "Enemy")
            {
                targettag = "Ally";
            }
            if (collision.tag == targettag)
            {
                if (distance < stat.range)
                {
                    target = collision.gameObject;
                }
            }
        }
    }
}
