using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngeldevilSkill : MonoBehaviour
{
    float range;
    float healamount;
    // Start is called before the first frame update
    void Start()
    {
        range = GetComponent<Stat>().range;
        healamount = GetComponent<Stat>().attack * 0.8f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Heal()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, range);
        if (targets.Length > 0)
        {
            List<GameObject> targetobj = new List<GameObject>();
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].tag == "Ally" && targets[i].gameObject != this.gameObject)
                {
                    if (targets[i].GetComponent<Stat>().maxHealth > targets[i].GetComponent<Stat>().health)
                    {
                        targetobj.Add(targets[i].gameObject);
                    }
                }
            }
            if (targetobj.Count > 0)
            {
                targetobj[0].SendMessage("Healed", healamount);
            }
        }
    }
}
