using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destruction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destruction()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
