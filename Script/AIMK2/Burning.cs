using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    GameObject eff;
    Stat stat;
    float amount;
    float counter;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponent<Stat>();
        eff = stat.burnEff;
        counter = 5;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > counter)
        {
            Destroy(this);
        }
        else
        {
            if (timer % 1 < 0.1f)
            {
                stat.Attacked(amount);
                float random = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(eff, new Vector3(transform.position.x + random, transform.position.y + 1f + random / 2, transform.position.z - 3), Quaternion.identity);
                text.transform.parent = gameObject.transform;
            }
        }
    }
    void GetBurn(float a)
    {
        amount = a;
    }
}
