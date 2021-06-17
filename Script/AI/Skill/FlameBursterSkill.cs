using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBursterSkill : MonoBehaviour
{
    AllyAI1 ai;
    internal float count;
    // Start is called before the first frame update
    void Start()
    {
        if ((gameObject.GetComponent<AllyAI1>() as AllyAI1) != null)
        {
            ai = gameObject.GetComponent<AllyAI1>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
