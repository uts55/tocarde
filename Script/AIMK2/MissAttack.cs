using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissAttack : MonoBehaviour
{
    public float time;
    public float attack;
    int level;
    float timer;
    float collisiontimer;
    bool collisionOn = false;
    bool Finish;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        collisiontimer += Time.deltaTime;
        if(timer > time)
        {
            Finish = true;
        }
        if(collisiontimer > 0.5f && collisiontimer < 0.6f)
        {
            collisionOn = true;
        }
        else if(collisiontimer > 0.6f)
        {
            collisionOn = false;
            collisiontimer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false)
        {
            collision.gameObject.GetComponent<Stat>().Bspeed -= collision.gameObject.GetComponent<Stat>().Aspeed * (0.4f + 0.4f * (0.1f * level));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false)
        {
            if (collision.gameObject.GetComponent<Stat>().Bspeed != 0)
            {
                collision.gameObject.GetComponent<Stat>().Bspeed = 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collisionOn == true)
        {
            if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false)
            {
                collision.SendMessage("Attacked", (180 + 180 * 0.3f)/6);
            }
        }
        if(Finish == true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (collision.gameObject.GetComponent<Stat>().Bspeed != 0)
                {
                    collision.gameObject.GetComponent<Stat>().Bspeed = 0;
                }
            }
            Destroy(gameObject);
        }
    }
    public void Getlevel(int l)
    {
        level = l;
    }
}
