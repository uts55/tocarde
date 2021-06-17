using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyDelete : MonoBehaviour
{
    int level;
    float timer;
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = level + 4;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > counter)
        {
            Destroy(gameObject);
        }
    }
    public void Getlevel(int l)
    {
        level = l;
    }
}
