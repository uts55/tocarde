using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealField : MonoBehaviour
{
    public float time;
    public float heal;
    float timer;
    float collisiontimer;
    bool collisionOn = false;
    int level;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        collisiontimer += Time.deltaTime;
        if (timer > time)
        {
            Destroy(gameObject);
        }
        if (collisiontimer > 0.5f && collisiontimer < 0.6f)
        {
            collisionOn = true;
        }
        else if (collisiontimer > 0.6f)
        {
            collisionOn = false;
            collisiontimer = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collisionOn == true)
        {
            if (collision.gameObject.tag == "Ally" && collision.isTrigger == false)
            {
                collision.SendMessage("Healed", collision.GetComponent<Stat>().maxHealth * (0.04f + ((level - 1) * 0.01f)));
            }
        }
    }
    public void Getlevel(int l)
    {
        level = l;
    }
}
