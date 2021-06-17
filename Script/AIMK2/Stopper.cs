using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("Stop");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("StopFinish");
    }
}
