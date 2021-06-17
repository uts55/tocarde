using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverloadSystem : MonoBehaviour
{
    public int overloadstack;
    public List<GameObject> miner = new List<GameObject>();
    public List<AIMK2> minerai = new List<AIMK2>();

    public TextMeshProUGUI minercount;
    public TextMeshProUGUI Gemmedminer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        minercount.text = miner.Count.ToString();
        Gemmedminer.text = overloadstack.ToString();
        for (int i = 0; i < miner.Count; i++)
        {
            if(overloadstack > i)
            {
                minerai[i].move.move = false;
                minerai[i].attack.attackable = false;
            }
            else
            {
                minerai[i].move.move = true;
                minerai[i].attack.attackable = true;
            }
        }

    }

    public void AddMiner(GameObject newminer)
    {
        miner.Add(newminer.GetComponent<GameObject>());
        minerai.Add(newminer.GetComponent<AIMK2>());
    }
}
