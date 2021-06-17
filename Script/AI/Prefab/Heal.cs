using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float healrange;
    public float healamount;
    public float healtime;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] ally = Physics2D.OverlapCircleAll(transform.position, healrange);

        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i].tag == gameObject.tag)
            {
                timer += Time.deltaTime;
                if (timer > healtime)
                {
                    ally[i].gameObject.SendMessage("Healed", healamount);
                    timer = 0;
                }
            }
        }
    }
}
