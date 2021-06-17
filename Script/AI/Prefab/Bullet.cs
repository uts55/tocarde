using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject effect;
    GameObject target;
    Rigidbody2D rigid;
    float attack;
    float timer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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

            float distance = Vector2.Distance(gameObject.transform.position, target.transform.position);

            if (distance <= 1)
            {
                //GameObject eff = Instantiate(effect, new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-1f, 0), transform.position.z - 3), Quaternion.identity);
                //eff.transform.SetParent(target.transform);
                target.SendMessage("Attacked", attack);
                Destroy(gameObject);
            }

            //transform.Rotate(new Vector3(0, 0, 360.0f - Vector3.Angle(this.transform.right, rigid.velocity.normalized)));
        }
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
