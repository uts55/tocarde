using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    int card_number;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");

        card_number = int.Parse(eventData.pointerDrag.name);

        GetComponent<DeckData>().DragUnitToDeck(card_number);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
