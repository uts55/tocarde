using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IBeginDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    public GameObject panel;

    private RectTransform rect;
    //private Vector3 trans_return;

    private CanvasGroup canvas_group;

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    GameObject placeholder = null;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas_group = GetComponent<CanvasGroup>();
        //trans_return = transform.localPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        placeholder = new GameObject();
        placeholder.AddComponent<RectTransform>();
        placeholder.GetComponent<RectTransform>().sizeDelta = new Vector2(280, 400);

        placeholder.transform.SetParent(this.transform.parent);

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;

        transform.SetParent(transform.parent.parent.parent);

        canvas_group.alpha = 0.6f;
        canvas_group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor / panel.transform.localScale;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        canvas_group.alpha = 1.0f;
        canvas_group.blocksRaycasts = true;
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        Destroy(placeholder);
    }

    public void OnDrop(PointerEventData eventData)
    {

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
