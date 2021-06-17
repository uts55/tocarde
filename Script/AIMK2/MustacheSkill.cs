using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustacheSkill : MonoBehaviour
{
    Stat stat;
    public float cooltime;
    public float timer;
    float healamount;
    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponent<Stat>();
        timer = 0;
        healamount = stat.maxHealth / 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (stat.maxHealth > stat.health)
        {
            timer += Time.deltaTime;
            if (timer > cooltime)
            {
                StartCoroutine(Healstart());
            }
        }
        else
        {
            timer = 0;
        }
    }
    IEnumerator Healstart()
    {
        timer = 0;
        for (int i = 0; i < 5; i++)
        {
            stat.Healed(healamount / 5);
            yield return new WaitForSeconds(1f);
        }
        timer = 0;
    }
}
