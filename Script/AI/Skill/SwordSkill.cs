using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : MonoBehaviour
{
    AllyAI1 ai;
    internal float count;
    public float Hittime;
    void Start()
    {
        if ((gameObject.GetComponent<AllyAI1>() as AllyAI1) != null)
        {
            ai = gameObject.GetComponent<AllyAI1>();
        }
    }
    void Update()
    {
        if(count == Hittime)
        {
            ai.stun = true;
        }
        else if(count > Hittime)
        {
            count = 1;
            ai.stun = false;
        }
    }
}
