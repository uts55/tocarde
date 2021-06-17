using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSkill : MonoBehaviour
{
    AllyAI1 ai;
    internal float count;
    public float Hittime;
    float increase;
    public GameObject skillarrow;
    GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        if ((gameObject.GetComponent<AllyAI1>() as AllyAI1) != null)
        {
            ai = gameObject.GetComponent<AllyAI1>();
        }
        increase = ai.attack * 2;
        temp = ai.arrow; 
    }

    // Update is called once per frame
    void Update()
    {
        if(count == Hittime)
        {
            ai.arrow = skillarrow;
            ai.attack = increase;
        }
        else if(count > Hittime)
        {
            ai.arrow = temp;
            ai.attack = increase / 2;
            count = 1;
        }
    }
}
