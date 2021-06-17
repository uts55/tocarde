using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    GameObject target;
    Rigidbody2D rigid;
    float heal;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = CalVel(target.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        Vector3 settarget = Vector3.Normalize(target.transform.position - transform.position);
        rigid.AddForce(settarget);

        float distance = Vector2.Distance(gameObject.transform.position, target.transform.position);

        if (distance <= 1)
        {
            target.SendMessage("Healed", heal);
            Destroy(gameObject);
        }
        Vector2 v = rigid.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle *10, Vector3.forward);
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
    void GetHeal(float a)
    {
        heal = a;
    }
}
