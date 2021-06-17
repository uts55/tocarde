using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    public float time;
    int level;
    float timer;
    bool Finish;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time)
        {
            Finish = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false)
        {
            Stat collisionstat = collision.gameObject.GetComponent<Stat>();
            collisionstat.Bdefence -= 0.5f;
            //collisionstat.Battackspeed -= 0.8f;
            collisionstat.Bspeed -= 0.8f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false)
        {
            Stat collisionstat = collision.gameObject.GetComponent<Stat>();
            if (collision.gameObject.GetComponent<Stat>().Bdefence != 0)
            {
                collisionstat.Bdefence = 0;
            }
            /*if (collision.gameObject.GetComponent<Stat>().Battackspeed != 0)
            {
                collisionstat.Battackspeed = 0;
            }*/
            if (collision.gameObject.GetComponent<Stat>().Bspeed != 0)
            {
                collisionstat.Bspeed = 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Finish == true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Stat collisionstat = collision.gameObject.GetComponent<Stat>();
                if (collision.gameObject.GetComponent<Stat>().Bdefence != 0)
                {
                    collisionstat.Bdefence = 0;
                }
                /*if (collision.gameObject.GetComponent<Stat>().Battackspeed != 0)
                {
                    collisionstat.Battackspeed = 0;
                }*/
                if (collision.gameObject.GetComponent<Stat>().Bspeed != 0)
                {
                    collisionstat.Bspeed = 0;
                }
            }
            Destroy(gameObject);
        }
    }
    void Getlevel(int l)
    {
        level = l;
    }
}
