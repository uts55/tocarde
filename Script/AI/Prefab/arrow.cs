using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public GameObject effect;
    GameObject target;
    Rigidbody2D rigid;
    float attack;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (target != null)
        {
            rigid.velocity = CalVel(target.transform.position, transform.position);
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
            Vector3 settarget = Vector3.Normalize(target.transform.position - transform.position);
            rigid.AddForce(settarget);
            float distance = Vector2.Distance(gameObject.transform.position, target.transform.position);

            if (distance <= 1)
            {
                GameObject eff = Instantiate(effect, new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-1f, 0), transform.position.z - 3), Quaternion.identity);
                eff.transform.SetParent(target.transform);
                target.SendMessage("Attacked", attack);
                Destroy(gameObject);
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
}
