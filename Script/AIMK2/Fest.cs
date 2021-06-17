using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fest : MonoBehaviour
{
    GameObject eff;
    Stat stat;
    int level;
    float counter;
    float timer;
    public int j = 0;
    public List<GameObject> Enemys = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponent<Stat>();
        eff = stat.festEff;
        counter = 6;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= counter)
        {
            GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
            
            for (int i = 0; i < Enemy.Length; i++)
            {
                if(Enemy[i] != this.gameObject && Enemy[i].GetComponent<Fest>() == null)
                {
                    Enemys.Add(Enemy[i]);
                    j++;
                }
            }
            int at = Enemys.Count;
            if (at > 3)
                at = 3;
            for (int i = 0; i < at; i++)
            {
                Enemys[i].AddComponent<Fest>();
                Enemys[i].SendMessage("Festlevel", level);
            }
            Destroy(this);
        }
        else
        {
            if (timer % 1 < 0.1f)
            {
                stat.Attacked(60 + (60 * (0.2f * level)));
                float random = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(eff, new Vector3(transform.position.x + random, transform.position.y + 1f + random / 2, transform.position.z - 3), Quaternion.identity);
                text.transform.parent = gameObject.transform;
            }
        }
    }
    public void Festlevel(int amount)
    {
        level = amount;
    }
}
