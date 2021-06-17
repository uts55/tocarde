using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemActivator : MonoBehaviour
{
    public GameObject[] Collector;
    public Enemy_castleAI EnemyCastle;
    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyCastle.CastleLevel == 1)
        {
            Collector[0].SetActive(true);   
        }
        else if (EnemyCastle.CastleLevel == 2)
        {
            Collector[1].SetActive(true);
        }
        else if (EnemyCastle.CastleLevel == 3)
        {
            Collector[2].SetActive(true);
        }
    }
}
