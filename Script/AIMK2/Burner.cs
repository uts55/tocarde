using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burner : MonoBehaviour
{
    public float attacktime;
    public float distance;
    int level;
    float attack = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float targetdistance = Vector2.Distance(gameObject.transform.position, collision.transform.position);
        if (targetdistance < distance)
        {
            if (collision.tag == "Enemy")
            {
                collision.gameObject.AddComponent<Burning>();
                if (attack > 0)
                {
                    collision.SendMessage("GetBurn", attack / 4);
                }
                else
                {
                    collision.SendMessage("GetBurn", 40 + (40 * 0.2f * (level - 1)));
                }
            }
        }
    }
    void GetLevel(int l)
    {
        level = l;
    }
    void GetAttack(float a)
    {
        attack = a;
    }
}
