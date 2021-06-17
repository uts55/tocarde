using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotcha_On : MonoBehaviour
{
    public bool is_On;
    // Start is called before the first frame update
    void Start()
    {
        is_On = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu_On_Off()
    {
        if(is_On == false)
        {
            this.gameObject.SetActive(true);
            is_On = true;
        }
        else if (is_On == true)
        {
            this.gameObject.SetActive(false);
            is_On = false;
        }
    }
}
