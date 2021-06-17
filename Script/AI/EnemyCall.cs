using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Soldier
{
    internal bool isactive;
    public GameObject soldier;
    internal float Rezentime;
}
public class EnemyCall : MonoBehaviour
{
    public Soldier[] S;
    bool[] Rezentrue;
    float timer = 0;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        Rezentrue = new bool[S.Length];
        for (int i = 0; i < Rezentrue.Length; i++)
        {
            if(S[i].isactive == true)
                Rezentrue[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            if (first == true)
            {
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(transform.position.x, transform.position.y + random, random * 10);
                Instantiate(S[0].soldier, randomspot, Quaternion.identity);
                first = false;
            }
            for (int i = 0; i < S.Length; i++)
            {
                if (Rezentrue[i] == true)
                {
                    StartCoroutine(Spawn(i));
                }
            }
        }
    }
    IEnumerator Spawn(int i)
    {
        Rezentrue[i] = false;
        yield return new WaitForSeconds(S[i].Rezentime);
        float random = UnityEngine.Random.Range(-0.3f, 0.3f);
        Vector3 randomspot = new Vector3(transform.position.x, transform.position.y + random, random * 10);
        Instantiate(S[i].soldier, randomspot, Quaternion.identity);
        Rezentrue[i] = true;
    }
}
