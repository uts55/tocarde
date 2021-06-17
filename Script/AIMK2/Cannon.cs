using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Bomb;
    public bool Isbullet;
    internal GameObject target;
    Rigidbody2D rigid;
    internal float attack;
    public float speed;
    public bool targeting;
    internal float distance;
    float timer;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (target != null)
        {
            if (Isbullet == false)
            {
                rigid.velocity = CalVel(target.transform.position, transform.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
        }
        else if (target != null)
        {
            Vector3 settarget = Vector3.Normalize(target.transform.position - transform.position) * speed;
            rigid.AddForce(settarget);
            distance = Vector2.Distance(gameObject.transform.position, target.transform.position);

            if (targeting == true)
            {
                if (distance <= 1)
                {
                    GameObject Boom = Instantiate(Bomb, transform.position, Quaternion.identity);
                    Boom.SendMessage("GetAttack", attack);
                    Boom.SendMessage("GetLevel", level);
                    Destroy(gameObject);
                }
            }
            else
            {
                if(transform.position.y < -1)
                {
                    GameObject Boom = Instantiate(Bomb, transform.position, Quaternion.identity);
                    Boom.SendMessage("GetAttack", attack);
                    Boom.SendMessage("GetLevel", level);
                    Destroy(gameObject);
                }
            }
            Vector2 v = rigid.velocity;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    Vector3 CalVel(Vector3 target, Vector3 main)
    {

        Vector3 distance = target - main;

        float x = target.x - main.x;
        float y = target.y - main.y;

        Vector3 result = distance;
        result.x = x;
        result.y = y + 0.5f * Mathf.Abs(Physics2D.gravity.y);
        return result;
    }
    void GetTarget(GameObject t)
    {
        target = t;
    }
    void GetAttack(float a)
    {
        attack = a;
    }
    void GetLevel(int l)
    {
        level = l;
    }
}
