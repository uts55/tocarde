using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilAttackUp : MonoBehaviour
{
    Cannon cannon;
    bool a;
    // Start is called before the first frame update
    void Start()
    {
        cannon = GetComponent<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a == false)
        {
            if (cannon.attack > 0)
            {
                cannon.attack = cannon.attack * 1.5f;
                a = true;
            }
        }
    }
}
