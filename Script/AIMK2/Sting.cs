using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : MonoBehaviour
{
    GameObject target;
    Rigidbody2D rigid;
    float attack;
    float timer;
    public float speed;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector3 settarget = new Vector3(speed, 0);
        rigid.AddForce(settarget);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > time)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false)
        {
            collision.SendMessage("Attacked", attack);
            collision.SendMessage("BuffSpeed", collision.GetComponent<Stat>().speed * 0.3f);
        }
        else if (collision.tag == "EnemyCastle")
        {
            collision.gameObject.transform.parent.gameObject.SendMessage("Attacked", attack);
        }
    }
    void GetTarget(GameObject t)
    {
        target = t;
    }
    void GetAttack(float a)
    {
        attack = a * 1.7f;
    }
}
