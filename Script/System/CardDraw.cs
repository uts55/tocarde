using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDraw : MonoBehaviour
{
    public float turn_time = 10;
    public float time;
    //카드 카운트
    public int card_count = 0;

    //카드 프리팹
    public GameObject card_prefab;

    public GameObject drawed_card;

    public UnitNumberDataList draw_list = new UnitNumberDataList();
    public UnitNumberDataList pre_list = new UnitNumberDataList();

    //미리보기
    public GameObject pre_card;

    public GameObject hand_card;
    public Carddrawtimer decktimer;
    public GameObject deck;
    public Animator drawMotion;
    public Animator deleteMotion;

    public int rand_index;

    //프리팹 목록
    public GameObject prefab_list;

    //미리보기 1번, 2번 인덱스
    int pre1_index;


    //유닛 이미지 저장소
    public GameObject unit_image;
    public GameObject magic_image;
    public GameObject buff_image;

    public bool Istutorial;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < GameData.Instance.deck_size; i++)
        {
            if (GameData.Instance.unit_deck_list.list[i].unit_num == 0)
            {
                Debug.LogError("UnitCode is 0. Check your deck.");
            }
            else if (GameData.Instance.unit_deck_list.list[i].unit_num < 101)
            {
                draw_list.list.Add(GameData.Instance.unit_all_list.list[GameData.Instance.unit_deck_list.list[i].unit_num - 1]);
            }
            else if (GameData.Instance.unit_deck_list.list[i].unit_num < 201)
            {
                draw_list.list.Add(GameData.Instance.magic_all_list.list[GameData.Instance.unit_deck_list.list[i].unit_num - 101]);
            }
            else if (GameData.Instance.unit_deck_list.list[i].unit_num < 301)
            {
                draw_list.list.Add(GameData.Instance.buff_all_list.list[GameData.Instance.unit_deck_list.list[i].unit_num - 201]);
            }
        }

        hand_card = GameObject.FindGameObjectWithTag("Hand");

        pre_card = GameObject.FindGameObjectWithTag("PreCard1");

        unit_image = GameObject.FindGameObjectWithTag("UnitImageParent");
        magic_image = GameObject.FindGameObjectWithTag("MagicImageParent");
        buff_image = GameObject.FindGameObjectWithTag("BuffImageParent");

        prefab_list = GameObject.FindGameObjectWithTag("CardPrefabList");

        //시작하면 드로우 5번, 미리보기 설정
        /*InitDraw();
        InitDraw();
        InitDraw();
        InitDraw();
        InitDraw();
        InitPreDraw();*/
        if (Istutorial == false)
        {
            StartCoroutine(InitDraw());
            InitPreDraw();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Istutorial == false)
        {
            time += 1.0f * Time.deltaTime;

            if (time >= turn_time + 0.5f)
            {
                if (card_count < 6)
                {
                    time = 0;
                    StartCoroutine(Draw());
                }
                else if (card_count >= 6)
                {
                    time = 0;
                    Over();
                }
            }
            if (time <= 0.7f && time > 0.6)
            {
                decktimer.StartCoolTime(turn_time);
            }

            if (card_count >= 6)
            {
                decktimer.background = true;
            }
            else if (card_count < 6)
            {
                decktimer.background = false;
            }
        }
    }

    //시작할때 뽑기
    /*public void InitDraw()
    {
        rand_index = Random.Range(0, GameData.Instance.deck_size);
        drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        drawed_card.transform.SetParent(hand_card.transform);
        //카드에 이름, 인구, 코스트 등 입력
        drawed_card.GetComponent<CardStatus>().StatusSetting(draw_list.list[rand_index].unit_number, draw_list.list[rand_index].unit_name, draw_list.list[rand_index].population, draw_list.list[rand_index].cost1, draw_list.list[rand_index].cost2);
    }*/
    IEnumerator InitDraw()
    {
        for (int i = 0; i < 4; i++)
        {
            drawMotion.SetTrigger("Draw");
            card_count++;
            yield return new WaitForSeconds(0.5f);
            rand_index = Random.Range(0, GameData.Instance.deck_size);
            //카드 프리팹 변경
            //유닛카드
            if (draw_list.list[rand_index].unit_number < 101)
            {
                //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
                if (draw_list.list[rand_index].grade == 0)
                {
                    card_prefab = prefab_list.transform.GetChild(0).GetChild(0).gameObject;
                }
                else if (draw_list.list[rand_index].grade == 1)
                {
                    card_prefab = prefab_list.transform.GetChild(0).GetChild(1).gameObject;
                }
                else if (draw_list.list[rand_index].grade == 2)
                {
                    card_prefab = prefab_list.transform.GetChild(0).GetChild(2).gameObject;
                }
            }
            else if (draw_list.list[rand_index].unit_number < 201)
            {
                //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
                if (draw_list.list[rand_index].grade == 0)
                {
                    card_prefab = prefab_list.transform.GetChild(1).GetChild(0).gameObject;
                }
                else if (draw_list.list[rand_index].grade == 1)
                {
                    card_prefab = prefab_list.transform.GetChild(1).GetChild(1).gameObject;
                }
                else if (draw_list.list[rand_index].grade == 2)
                {
                    card_prefab = prefab_list.transform.GetChild(1).GetChild(2).gameObject;
                }
            }
            else if (draw_list.list[rand_index].unit_number < 301)
            {
                //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
                if (draw_list.list[rand_index].grade == 0)
                {
                    card_prefab = prefab_list.transform.GetChild(2).GetChild(0).gameObject;
                }
                else if (draw_list.list[rand_index].grade == 1)
                {
                    card_prefab = prefab_list.transform.GetChild(2).GetChild(1).gameObject;
                }
                else if (draw_list.list[rand_index].grade == 2)
                {
                    card_prefab = prefab_list.transform.GetChild(2).GetChild(2).gameObject;
                }
            }

            drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            drawed_card.transform.SetParent(hand_card.transform);
            drawed_card.transform.localScale = new Vector3(1, 1);
            drawed_card.transform.localPosition = new Vector3(0, 0, 0);
            //카드에 이름, 인구, 코스트 등 입력
            drawed_card.GetComponent<CardStatus>().StatusSetting(draw_list.list[rand_index].unit_number, draw_list.list[rand_index].unit_name, draw_list.list[rand_index].population, draw_list.list[rand_index].cost1, draw_list.list[rand_index].description);
            //카드 이미지 변경
            ImageChanger(drawed_card);

        }
    }
    public void SettingDraw(int a)
    {
        StartCoroutine(SetDraw(a));
    }
    IEnumerator SetDraw(int number)
    {
        drawMotion.SetTrigger("Draw");
        card_count++;
        yield return new WaitForSeconds(0.5f);
        rand_index = number;
        //카드 프리팹 변경
        //유닛카드
        if (rand_index < 101)
        {
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (GameData.Instance.unit_all_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(0).gameObject;
            }
            else if (GameData.Instance.unit_all_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(1).gameObject;
            }
            else if (GameData.Instance.unit_all_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(2).gameObject;
            }
            drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            drawed_card.transform.SetParent(hand_card.transform);
            //카드에 이름, 인구, 코스트 등 입력
            drawed_card.GetComponent<CardStatus>().StatusSetting(GameData.Instance.unit_all_list.list[rand_index].unit_number, GameData.Instance.unit_all_list.list[rand_index].unit_name, GameData.Instance.unit_all_list.list[rand_index].population, GameData.Instance.unit_all_list.list[rand_index].cost1, GameData.Instance.unit_all_list.list[rand_index].description);

        }
        else if (rand_index < 201)
        {
            rand_index = rand_index - GameData.Instance.unit_all_list.list.Count -1;
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (GameData.Instance.magic_all_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(0).gameObject;
            }
            else if (GameData.Instance.magic_all_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(1).gameObject;
            }
            else if (GameData.Instance.magic_all_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(2).gameObject;
            }
            drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            drawed_card.transform.SetParent(hand_card.transform);
            //카드에 이름, 인구, 코스트 등 입력
            drawed_card.GetComponent<CardStatus>().StatusSetting(GameData.Instance.magic_all_list.list[rand_index].unit_number, GameData.Instance.magic_all_list.list[rand_index].unit_name, GameData.Instance.magic_all_list.list[rand_index].population, GameData.Instance.magic_all_list.list[rand_index].cost1, GameData.Instance.magic_all_list.list[rand_index].description);

        }
        else if (rand_index < 301)
        {
            rand_index = rand_index - GameData.Instance.unit_all_list.list.Count - GameData.Instance.magic_all_list.list.Count-2;
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (GameData.Instance.buff_all_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(0).gameObject;
            }
            else if (GameData.Instance.buff_all_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(1).gameObject;
            }
            else if (GameData.Instance.buff_all_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(2).gameObject;
            }
            drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            drawed_card.transform.SetParent(hand_card.transform);
            //카드에 이름, 인구, 코스트 등 입력
            drawed_card.GetComponent<CardStatus>().StatusSetting(GameData.Instance.buff_all_list.list[rand_index].unit_number, GameData.Instance.buff_all_list.list[rand_index].unit_name, GameData.Instance.buff_all_list.list[rand_index].population, GameData.Instance.buff_all_list.list[rand_index].cost1, GameData.Instance.buff_all_list.list[rand_index].description);

        }
        drawed_card.transform.localScale = new Vector3(1, 1);
        drawed_card.transform.localPosition = new Vector3(0, 0, 0);

        if (Istutorial == true)
        {
            drawed_card.GetComponent<DragSystem>().TutorialCard = true;
        }
        //카드 이미지 변경
        ImageChanger(drawed_card);
    }
    //시작할때 미리보기
    public void InitPreDraw()
    {
        rand_index = Random.Range(0, GameData.Instance.deck_size);
        pre1_index = rand_index;
        //카드에 이름, 인구, 코스트 등 입력
        pre_card.GetComponent<CardStatus>().StatusSetting(draw_list.list[rand_index].unit_number, draw_list.list[rand_index].unit_name, draw_list.list[rand_index].population, draw_list.list[rand_index].cost1, draw_list.list[rand_index].description);
    }

    //뽑기 기본틀
    /* public void Draw()
     {
         //미리보기 -> 손패로 이동
         rand_index = pre1_index;
         drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
         drawed_card.transform.SetParent(hand_card.transform);
         //카드에 이름, 인구, 코스트 등 입력
         drawed_card.GetComponent<CardStatus>().StatusSetting(draw_list.list[rand_index].unit_number, draw_list.list[rand_index].unit_name, draw_list.list[rand_index].population, draw_list.list[rand_index].cost1, draw_list.list[rand_index].cost2);


         //미리보기 2 -> 1, 미리보기 2에 새로운 카드 생성
         PreDraw();
     }*/
    public void OnDraw()
    {
        StartCoroutine(Draw());
    }
    IEnumerator Draw()
    {
        drawMotion.SetTrigger("Draw");
        card_count++;
        yield return new WaitForSeconds(0.5f);
        rand_index = pre1_index;
        //카드 프리팹 변경
        //유닛카드
        if (draw_list.list[rand_index].unit_number < 101)
        {
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (draw_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(0).gameObject;
            }
            else if (draw_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(1).gameObject;
            }
            else if (draw_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(2).gameObject;
            }
        }
        else if (draw_list.list[rand_index].unit_number < 201)
        {
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (draw_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(0).gameObject;
            }
            else if (draw_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(1).gameObject;
            }
            else if (draw_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(2).gameObject;
            }
        }
        else if (draw_list.list[rand_index].unit_number < 301)
        {
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (draw_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(0).gameObject;
            }
            else if (draw_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(1).gameObject;
            }
            else if (draw_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(2).gameObject;
            }
        }
        drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        drawed_card.transform.SetParent(hand_card.transform);
        drawed_card.transform.localScale = new Vector3(1, 1);
        drawed_card.transform.localPosition = new Vector3(0, 0, 0);
        //카드에 이름, 인구, 코스트 등 입력
        drawed_card.GetComponent<CardStatus>().StatusSetting(draw_list.list[rand_index].unit_number, draw_list.list[rand_index].unit_name, draw_list.list[rand_index].population, draw_list.list[rand_index].cost1, draw_list.list[rand_index].description);
        //카드 이미지 변경
        ImageChanger(drawed_card);

        //미리보기 2 -> 1, 미리보기 2에 새로운 카드 생성
        PreDraw();
    }
    public void RandomDraw()
    {
        StartCoroutine(RDraw());
    }
    IEnumerator RDraw()
    {
        drawMotion.SetTrigger("Draw");
        card_count++;
        yield return new WaitForSeconds(0.5f);
        rand_index = Random.Range(0, GameData.Instance.all_list.list.Count);
        //카드 프리팹 변경
        //유닛카드
        if (rand_index < GameData.Instance.unit_all_list.list.Count)
        {
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (GameData.Instance.unit_all_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(0).gameObject;
            }
            else if (GameData.Instance.unit_all_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(1).gameObject;
            }
            else if (GameData.Instance.unit_all_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(0).GetChild(2).gameObject;
            }
            drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            drawed_card.transform.SetParent(hand_card.transform);
            //카드에 이름, 인구, 코스트 등 입력
            drawed_card.GetComponent<CardStatus>().StatusSetting(GameData.Instance.unit_all_list.list[rand_index].unit_number, GameData.Instance.unit_all_list.list[rand_index].unit_name, GameData.Instance.unit_all_list.list[rand_index].population, GameData.Instance.unit_all_list.list[rand_index].cost1, GameData.Instance.unit_all_list.list[rand_index].description);

        }
        else if (rand_index < GameData.Instance.unit_all_list.list.Count + GameData.Instance.magic_all_list.list.Count)
        {
            rand_index = rand_index - GameData.Instance.unit_all_list.list.Count - 1;
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (GameData.Instance.magic_all_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(0).gameObject;
            }
            else if (GameData.Instance.magic_all_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(1).gameObject;
            }
            else if (GameData.Instance.magic_all_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(1).GetChild(2).gameObject;
            }
            drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            drawed_card.transform.SetParent(hand_card.transform);
            //카드에 이름, 인구, 코스트 등 입력
            drawed_card.GetComponent<CardStatus>().StatusSetting(GameData.Instance.magic_all_list.list[rand_index].unit_number, GameData.Instance.magic_all_list.list[rand_index].unit_name, GameData.Instance.magic_all_list.list[rand_index].population, GameData.Instance.magic_all_list.list[rand_index].cost1, GameData.Instance.magic_all_list.list[rand_index].description);

        }
        else
        {
            rand_index = rand_index - GameData.Instance.unit_all_list.list.Count - GameData.Instance.magic_all_list.list.Count - 2;
            //등급체크 노말 = 0, 유니크 = 1, 레전드 = 2
            if (GameData.Instance.buff_all_list.list[rand_index].grade == 0)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(0).gameObject;
            }
            else if (GameData.Instance.buff_all_list.list[rand_index].grade == 1)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(1).gameObject;
            }
            else if (GameData.Instance.buff_all_list.list[rand_index].grade == 2)
            {
                card_prefab = prefab_list.transform.GetChild(2).GetChild(2).gameObject;
            }
            drawed_card = Instantiate(card_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            drawed_card.transform.SetParent(hand_card.transform);
            //카드에 이름, 인구, 코스트 등 입력
            drawed_card.GetComponent<CardStatus>().StatusSetting(GameData.Instance.buff_all_list.list[rand_index].unit_number, GameData.Instance.buff_all_list.list[rand_index].unit_name, GameData.Instance.buff_all_list.list[rand_index].population, GameData.Instance.buff_all_list.list[rand_index].cost1, GameData.Instance.buff_all_list.list[rand_index].description);

        }
        drawed_card.transform.localScale = new Vector3(1, 1);
        drawed_card.transform.localPosition = new Vector3(0, 0, 0);

        ImageChanger(drawed_card);
    }
    //미리보기 뽑기
    public void PreDraw()
    {
        rand_index = Random.Range(0, GameData.Instance.deck_size);
        pre1_index = rand_index;
        pre_card.GetComponent<CardStatus>().StatusSetting(draw_list.list[pre1_index].unit_number, draw_list.list[pre1_index].unit_name, draw_list.list[pre1_index].population, draw_list.list[pre1_index].cost1, draw_list.list[pre1_index].description);

    }

    public void DeleteHandAll()
    {
        /*//손패의 모든 자식을 파괴
        for (int i = 0; i < hand_card.transform.childCount; i++)
        {
            Destroy(hand_card.transform.GetChild(i).gameObject);
        }
        //1프레임이 지나야 파괴가 되기 때문에, 혹시 그전에 childCount를 참조할 일이 있을까 싶어서 hand_card의 자식을 모두 떼냄
        hand_card.transform.DetachChildren();

        card_count = 0;*/
        StartCoroutine(DeleteHandall());
    }
    IEnumerator DeleteHandall()
    {
        int count = hand_card.transform.childCount;
        if (count > 0)
        {
            card_count = 0;


            for (int i = 0; i < count; i++)
            {
                if(hand_card.transform.GetChild(i).gameObject.GetComponent<Animator>())
                    hand_card.transform.GetChild(i).gameObject.GetComponent<Animator>().SetTrigger("Delete");

            }
            yield return new WaitForSeconds(0.2f);
            for (int i = 0; i < count; i++)
            {
                Destroy(hand_card.transform.GetChild(i).gameObject);
            }
            deleteMotion.SetTrigger("Delete");
            //1프레임이 지나야 파괴가 되기 때문에, 혹시 그전에 childCount를 참조할 일이 있을까 싶어서 hand_card의 자식을 모두 떼냄
            //hand_card.transform.DetachChildren();
        }
    }
    //손패 한도초과
    public void Over()
    {
        //타는 애니메이션
        drawMotion.SetTrigger("Burn");
        //미리보기 2 -> 1, 미리보기 2에 새로운 카드 생성
        PreDraw();
    }

    void ImageChanger(GameObject ob)
    {
        int n;

        if (ob.GetComponent<CardStatus>().number < 101)
        {
            n = ob.GetComponent<CardStatus>().number - 1;
            UnitImageChange(n, ob);
        }
        else if (ob.GetComponent<CardStatus>().number < 201)
        {
            n = ob.GetComponent<CardStatus>().number - 101;
            MagicImageChange(n, ob);
        }
        else if (ob.GetComponent<CardStatus>().number < 301)
        {
            n = ob.GetComponent<CardStatus>().number - 201;
            BuffImageChange(n, ob);
        }
        else
        {
            Debug.LogError("Check card's number.");
        }
    }

    void UnitImageChange(int n, GameObject card)
    {
        Image card_image = card.transform.GetChild(1).GetComponent<Image>();
        card_image.sprite = unit_image.transform.GetChild(n).GetComponent<SpriteRenderer>().sprite;
    }

    void MagicImageChange(int n, GameObject card)
    {
        Image card_image = card.transform.GetChild(1).GetComponent<Image>();
        card_image.sprite = magic_image.transform.GetChild(n).GetComponent<SpriteRenderer>().sprite;
    }

    void BuffImageChange(int n, GameObject card)
    {
        Image card_image = card.transform.GetChild(1).GetComponent<Image>();
        card_image.sprite = buff_image.transform.GetChild(n).GetComponent<SpriteRenderer>().sprite;
    }
}
