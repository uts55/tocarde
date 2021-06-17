using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeSelector : MonoBehaviour
{
    public GameObject background;
    public GameObject Thunder;
    public GameObject MagicHall;
    public GameObject Missforcha;
    public GameObject Fatman;
    public GameObject LockOn;
    public GameObject down;
    public GameObject HealTotem;
    public Image lockback;
    public GameObject Toxicfield;
    public GameObject ToyRabbit;
    public GameObject AngelShield;
    CameraDrag cameradrag;
    Canvas DragField;
    DragSystem Card;
    int cost_low;
    int number;
    int level;
    bool isTutorial;
    Collider2D[] Catched;
    List<GameObject> detectlist = new List<GameObject>();
    CardDraw drawsystem;
    // Start is called before the first frame update
    void Start()
    {
        drawsystem = GameObject.FindGameObjectWithTag("Drawsystem").GetComponent<CardDraw>();
        //DragField = GameObject.FindGameObjectWithTag("DragField").GetComponent<Canvas>();
        cameradrag = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraDrag>();
        Card.gameObject.SetActive(false);
        if (number > 100 && number < 200)
        {
            level = GameData.Instance.magic_all_list.list[number - 100].unit_level;
        }
        else if (number > 200)
        {
            level = GameData.Instance.magic_all_list.list[number - 200].unit_level;
        }
        switch (number)
        {
            case 114:
            case 116:
            case 119:
            case 120:
            case 210:
                LockOn.SetActive(false);
                lockback.enabled = false;
                down.SetActive(true);
                break;
            default:
                LockOn.SetActive(true);
                lockback.enabled = true;
                down.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -2 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 0)
            {
                background.SetActive(true);
                CatchEnemy(2f, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else
            {
                background.SetActive(false);
            }


            if (Input.mousePosition.x < 200/1920.0f * Screen.width && Input.mousePosition.x > 100 / 1920.0f * Screen.width)
            {
                if (Camera.main.transform.position.x > -26)
                {
                    Camera.main.transform.position += new Vector3(-0.1f, 0, 0);
                }
            }
            else if (Input.mousePosition.x < 100 / 1920.0f * Screen.width)
            {
                if (Camera.main.transform.position.x > -26)
                {
                    Camera.main.transform.position += new Vector3(-0.3f, 0, 0);
                }
            }
            else if (Input.mousePosition.x > 1720 / 1920.0f * Screen.width && Input.mousePosition.x < 1820 / 1920.0f * Screen.width)
            {
                if (Camera.main.transform.position.x < 2.5)
                {
                    Camera.main.transform.position += new Vector3(0.1f, 0, 0);
                }
            }
            else if (Input.mousePosition.x > 1820 / 1920.0f * Screen.width)
            {
                if (Camera.main.transform.position.x < 2.5)
                {
                    Camera.main.transform.position += new Vector3(0.3f, 0, 0);
                }
            }

            Vector2 thisposition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x , -1);
            gameObject.transform.position = thisposition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (Input.mousePosition.y > 300 / 1080.0f * Screen.height && Input.mousePosition.y < 600 / 1080.0f * Screen.height)
            {
                GameManager.Instance.gold -= cost_low;
                switch (number)
                {
                    case 113:
                        Instantiate(Missforcha, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.Euler(-90, 0, 0));
                        break;
                    case 114:
                        //CatchEnemy(2f, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                        if (detectlist.Count <= 0)
                        {
                            Instantiate(Thunder, transform.position + new Vector3(0, 4), Quaternion.identity);
                            Instantiate(MagicHall, transform.position, Quaternion.identity);
                        }
                        else
                        {
                            for (int i = 0; i < detectlist.Count; i++)
                            {
                                Instantiate(Thunder, detectlist[i].transform.position + new Vector3(0, 4), Quaternion.identity);
                                Instantiate(MagicHall, detectlist[i].transform.position, Quaternion.identity);
                                detectlist[i].SendMessage("Attacked", 150 + (150 * 0.3f * (level - 1)));
                                detectlist[i].SendMessage("BuffAttackSpeed",detectlist[i].GetComponent<Stat>().attackspeed * 0.2f + (detectlist[i].GetComponent<Stat>().attackspeed * (0.2f + (level * 0.1f))));
                                cameradrag.shake = true;
                            }
                        }
                        break;
                    case 116:
                        GameObject fat = Instantiate(Fatman, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.Euler(0, 0, -90));
                        fat.transform.position = new Vector3(fat.transform.position.x, fat.transform.position.y, 0);
                        fat.SendMessage("Getlevel", level);
                        break;
                    case 119:
                        GameObject To = Instantiate(Toxicfield, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.Euler(-50, 0, 0));
                        To.transform.position = new Vector3(To.transform.position.x, To.transform.position.y - 1f, 0);
                        To.SendMessage("Getlevel",level);
                        break;
                    case 120:
                        GameObject Toy = Instantiate(ToyRabbit, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                        Toy.transform.position = new Vector3(Toy.transform.position.x, Toy.transform.position.y, 0);
                        Toy.GetComponent<Stat>().health = 500 + (500 * 0.1f * (level - 1));
                        Toy.SendMessage("Getlevel", level);
                        break;
                    case 210:
                        GameObject totem = Instantiate(HealTotem, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                        totem.transform.position = new Vector3(totem.transform.position.x, totem.transform.position.y, 0);
                        totem.SendMessage("Getlevel", level);
                        break;
                    default:
                        break;
                }
                //CatchAlly();
                //CatchEnemy();
                for (int i = 0; i < detectlist.Count; i++)
                {
                    if (detectlist[i] != null)
                    {
                        detectlist[i].gameObject.BroadcastMessage("UpdateOutline", false);
                        //detectlist[i].transform.parent = null;
                    }
                }
                if (isTutorial == true)
                {
                    GameObject.FindGameObjectWithTag("DialogManager").GetComponent<ActiveManager>().Interact();
                }
                drawsystem.card_count--;
                Destroy(Card.gameObject);
                Destroy(gameObject);
            }
            else
            {
                for (int i = 0; i < detectlist.Count; i++)
                {
                    detectlist[i].gameObject.BroadcastMessage("UpdateOutline", false);
                    //detectlist[i].transform.parent = null;
                }
                detectlist.Clear();
                Card.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
    public void GetThis(GameObject card)
    {
        Card = card.GetComponent<DragSystem>();
        cost_low = Card.cost_low;
        number = Card.index;
        isTutorial = Card.TutorialCard;
    }
    public void CatchAlly(float range, Vector3 spot)
    {
        detectlist.Clear();
        Catched = Physics2D.OverlapCircleAll(spot, range/ transform.lossyScale.x);
        for (int i = 0; i < Catched.Length; i++)
        {
            float targetdistance = Vector2.Distance(spot, Catched[i].transform.position);
            if (Catched[i].tag == "Ally" && targetdistance < range && Catched[i].transform.GetChild(0).gameObject.tag != "Castle")
            {
                detectlist.Add(Catched[i].gameObject);
            }
        }
        /*for (int i = 0; i < detectlist.Count; i++)
        {
            if (detectlist.Count > 0)
            {
                if (detectlist[i] == detectlist[i + 1])
                {
                    detectlist.RemoveAt(i + 1);
                }
            }
        }*/
    }
    public void CatchEnemy(float range, Vector3 spot)
    {
        for (int i = 0; i < detectlist.Count; i++)
        {
            if (detectlist[i] != null)
            {
                detectlist[i].BroadcastMessage("UpdateOutline", false);
                //detectlist[i].transform.parent = null;
            }
        }
        detectlist.Clear();
        Catched = Physics2D.OverlapCircleAll(spot, range/ transform.lossyScale.x);
        for (int i = 0; i < Catched.Length; i++)
        {
            float targetdistance = Vector2.Distance(spot, Catched[i].transform.position);
            if (Catched[i].tag == "Enemy" && targetdistance < range && Catched[i].transform.GetChild(0).gameObject.tag != "Castle")
            {
                detectlist.Add(Catched[i].gameObject);
                Catched[i].gameObject.BroadcastMessage("UpdateOutline", true);
                //Catched[i].gameObject.transform.SetParent(DragField.transform);
            }
        }
        /*for (int i = 0; i < detectlist.Count; i++)
        {
            if (detectlist.Count > 0)
            {
                if (detectlist[i] == detectlist[i + 1])
                {
                    detectlist.RemoveAt(i + 1);
                }
            }
        }*/
    }
}
