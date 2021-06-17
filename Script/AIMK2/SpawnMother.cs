using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMother : MonoBehaviour
{
    public GameObject mother;
    Stat stat;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponent<Stat>();   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 10)
        {
            stat.BuffAttack(stat.attack / 2);
            stat.BuffAttackSpeed(stat.attackspeed / 2);
            timer = 0;
        }
    }

    public void Spawnmothr()
    {
        Instantiate(mother, transform.position, Quaternion.identity);
    }
}
