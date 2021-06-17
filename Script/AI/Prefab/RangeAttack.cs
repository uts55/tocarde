using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public float range;
    float attack;
    float timer;
    public float attacktime;
    public bool knockback;
    string Tag;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > attacktime)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        float targetdistance = Vector2.Distance(gameObject.transform.position, collision.transform.position);
        if (targetdistance < range)
        {
            if (Tag == "Ally")
            {
                if (collision.tag == "Enemy")
                {
                    collision.SendMessage("Attacked", attack);
                    if (knockback == true)
                    {
                        collision.SendMessage("knockback");
                    }
                }
                else if(collision.tag == "EnemyCastle")
                {
                    collision.gameObject.transform.parent.gameObject.SendMessage("Attacked", attack);
                    if(knockback == true)
                    {
                        collision.gameObject.transform.parent.gameObject.SendMessage("knockback");
                    }
                }
            }
            if (Tag == "Enemy")
            {
                if (collision.tag == "Ally" || collision.tag == "AllyCastle")
                {
                    collision.SendMessage("Attacked", attack);
                    if (knockback == true)
                    {
                        collision.SendMessage("knockback");
                    }
                }
            }
        }

    }
    void GetAttack(float a)
    {
        attack = a;
    }
    void GetTag(string t)
    {
        Tag = t;
    }
}
