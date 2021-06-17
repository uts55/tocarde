using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    public int index;
    public int cost_low;
    //public int cost_high;
    public bool RangeSelect;
    public ParticleSystem particle;
    public ParticleSystem Feverparticle;
    public ParticleSystem dropparticle;
    public GameObject Circle;
    bool clicked;

    public AudioSource click;
    public AudioSource drop;
    public bool TutorialCard;

    CardDraw drawsystem;
    public GameObject placeholder = null;
    Canvas DragField;

    public void OnBeginDrag(PointerEventData eventData)
    {

            clicked = true;


            /*placeholder = new GameObject();
            placeholder.transform.SetParent(this.transform.parent);

            placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            parentToReturnTo = this.transform.parent;
            placeholderParent = parentToReturnTo;*/

            click.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.gold >= cost_low)
        {
            Vector3 screenPoint = Input.mousePosition;
            screenPoint.z = 10.0f;
            //Debug.Log("OnDrag");
            if (RangeSelect == true && this.transform.position.y >= -2)
            {
                GameObject range = Instantiate(Circle, Camera.main.ScreenToWorldPoint(screenPoint), Quaternion.identity);
                range.transform.SetParent(DragField.transform);
                range.transform.localScale = new Vector3(1, 1, 1);
                range.SendMessage("GetThis", this.gameObject);
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

                clicked = false;
                this.transform.localScale = new Vector2(1, 1);
                if (CardData.Instance.Fevertime == true)
                {
                    Feverparticle.gameObject.SetActive(false);
                }
                else
                {
                    particle.gameObject.SetActive(false);
                }//particle.Stop();
                drop.Play();
                Destroy(placeholder);
            }
            else
            {
                //this.transform.position = eventData.position;
                transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        clicked = false;
        //그냥 포지션으로 해버렸음
        //y포지션 -150이상이면 소환 아니면 복귀
        if (this.transform.position.y >= -2)
        {
            //몬가가 일어남
            if (GameManager.Instance.gold >= cost_low)
            {
                GameManager.Instance.gold -= cost_low;
                if (index < 101)
                {
                    float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                    Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 100);
                    Instantiate(GameManager.Instance.unit_list_all[index], randomspot, Quaternion.identity);
                }
                else if (index >= 101 && index < 301)
                {
                    CardData.Instance.Functionstart(index);
                }
                Vector3 screenPoint = Input.mousePosition;
                screenPoint.z = 10.0f;
                ParticleSystem particle = Instantiate(dropparticle, Camera.main.ScreenToWorldPoint(screenPoint), Quaternion.identity);
                //파괴
                drawsystem.card_count--;
                CardData.Instance.use++;
                if(TutorialCard == true)
                {
                    ActiveManager manager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<ActiveManager>();
                    manager.Interact();
                }
                Destroy(this.gameObject);
            }
            else
            {
                //소환 불가능
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            }
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        }

        this.transform.localScale = new Vector2(1, 1);
        if (CardData.Instance.Fevertime == true)
        {
            Feverparticle.gameObject.SetActive(false);
        }
        else
        {
            particle.gameObject.SetActive(false);
        }
        //particle.Stop();
        drop.Play();
        Destroy(placeholder);
    }

    public void OnDrop(PointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        index = this.gameObject.GetComponent<CardStatus>().number;
        cost_low = this.gameObject.GetComponent<CardStatus>().cost_low;
        //cost_high = this.gameObject.GetComponent<CardStatus>().cost_high;
        RangeSelect = this.gameObject.GetComponent<CardStatus>().selectable;
        drawsystem = GameObject.FindGameObjectWithTag("Drawsystem").GetComponent<CardDraw>();
        DragField = GameObject.FindGameObjectWithTag("DragField").GetComponent<Canvas>();
        particle.gameObject.SetActive(false);
        Feverparticle.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (clicked == false)
        {
            
            placeholder = new GameObject();
            placeholder.AddComponent<RectTransform>();
            placeholder.GetComponent<RectTransform>().sizeDelta = new Vector2(240, 320);
            placeholder.transform.SetParent(this.transform.parent);
            placeholder.transform.localScale = new Vector3(1,1);

            placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            parentToReturnTo = this.transform.parent;
            placeholderParent = parentToReturnTo;
            this.transform.SetParent(DragField.transform);
            Vector3 cardposition = this.transform.position;

            this.transform.position = cardposition - new Vector3(0, 0, 30);
            this.transform.localScale = new Vector2(1.2f, 1.2f);
            if (GameManager.Instance.gold >= cost_low)
            {
                if (CardData.Instance.Fevertime == true)
                {
                    Feverparticle.gameObject.SetActive(true);
                }
                else
                {
                    particle.gameObject.SetActive(true);
                }
            }
            StartCoroutine(up(cardposition));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine("up");
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

        this.transform.localScale = new Vector2(1, 1);
        this.transform.localPosition = new Vector3(0, 0);
        if (CardData.Instance.Fevertime == true)
        {
            Feverparticle.gameObject.SetActive(false);
        }
        else
        {
            particle.gameObject.SetActive(false);
        }
        //particle.Stop();
        Destroy(placeholder);
    }
    IEnumerator up(Vector3 thisposition)
    {
        for (int i = 0; i < 3; i++)
        {
            transform.position = transform.position + new Vector3(0, 0.5f);
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void WakeUp()
    {
        this.gameObject.SetActive(true);
    }
}