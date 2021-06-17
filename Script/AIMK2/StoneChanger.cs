using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer Stone;
    Image stonesprite;
    void Start()
    {
        stonesprite = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stone != null)
        {
            stonesprite.sprite = Stone.sprite;
        }
    }
}
