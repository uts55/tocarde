using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class _data : MonoBehaviour
{
    public bool is_data;

    void Start()
    {
        is_data = false;
    }

    // Update is called once per frame
    void Update() { }

    public void on_off_data()
    {
        if (is_data == false)
        {
            this.gameObject.SetActive(true);
            is_data = true;
        }
        else if(is_data == true){
            this.gameObject.SetActive(false);
            is_data = false;
        }
    }
}
