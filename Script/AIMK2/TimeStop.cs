using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    float attack;
    float timer;
    GameObject Target;
    public float attacktime = 3;
    string Tag;
    public float distance;
    public int count;
    int level;
    int c;
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float targetdistance = Vector2.Distance(gameObject.transform.position, collision.transform.position);
        if (targetdistance < distance && count > c)
        {
            if (collision.tag == "Enemy")
            {
                c++;
                collision.gameObject.SendMessage("Attacked", attack * 2);
                collision.gameObject.SendMessage("stun", 1 + 0.5f * (level - 1));
                collision.gameObject.SendMessage("TimeStop", 3);
            }
            else if (collision.tag == "EnemyCastle")
            {
                collision.gameObject.transform.parent.gameObject.SendMessage("Attacked", attack);
            }
        }
    }
    void GetTarget(GameObject t)
    {
        Target = t;
    }
    void GetAttack(float a)
    {
        attack = a;
    }
    void GetTag(string t)
    {
        Tag = t;
    }
    void GetLevel(int l)
    {
        level = l;
    }
}