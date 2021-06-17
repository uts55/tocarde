using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatman : MonoBehaviour
{
    bool trigger = false;
    float timer;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger == true)
        {
            timer += Time.deltaTime;
            if(timer > 0.1f)
            {
                trigger = false;
            }
            if (timer > 2f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (trigger == true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                float targetdistance = Vector2.Distance(transform.position, collision.transform.position);
                if (targetdistance < 2f)
                {
                    collision.gameObject.SendMessage("Attacked", 110 + (110 * 0.3f * (level - 1)));
                    collision.gameObject.AddComponent<Burning>();
                    collision.SendMessage("GetBurn", 40 + (40 * 0.2f * (level - 1)));
                }
            }
        }
    }
    public void Bomb()
    {
        trigger = true;
    }
    public void Getlevel(int l)
    {
        level = l;
    }
}
