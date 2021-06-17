using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//덱의 유닛 데이터
public class UnitData
{
    //유닛 코드
    public int unit_number;
    //유닛이 있는가?
    public bool is_full;
    //덱 버튼(칸) 오브젝트
    public GameObject deck_object;
    //생성자
    public UnitData(int unit_num, bool isfull, GameObject unit)
    {
        unit_number = unit_num;
        is_full = isfull;
        deck_object = unit;
    }
}

//유닛리스트 데이터
public class UnitList
{
    //유닛코드
    public int unit_number;
    //유닛을 가지고 있는가?
    public bool is_have;
    //유닛이 들어가 있는가?
    public bool is_used;
    //유닛 리스트 버튼(칸) 오브젝트
    public GameObject unit_object;
    //생성자
    public UnitList(int unit_num, bool ishave, bool isused, GameObject unit)
    {
        unit_number = unit_num;
        is_have = ishave;
        is_used = isused;
        unit_object = unit;
    }
}

public class DeckData : MonoBehaviour
{
    //덱 데이터(유닛코드, isfull, 버튼오브젝트)
    public List<UnitData> deck_data = new List<UnitData>();
    //패시브 전용 덱
    public List<UnitData> passive_data = new List<UnitData>();
    //패시브 카드 데이터
    //public UnitData passive_data = new UnitData(GameData.Instance.unit_deck_list.list[i].unit_num, false, transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject));

    //전체 유닛 리스트
    public List<UnitList> all_unit_list = new List<UnitList>();
    //전체 마법 리스트
    public List<UnitList> all_magic_list = new List<UnitList>();
    //전체 버프 리스트
    public List<UnitList> all_buff_list = new List<UnitList>();
    //전체 패시브 리스트
    public List<UnitList> all_passive_list = new List<UnitList>();

    //유닛리스트 오브젝트 모음집
    public GameObject unit_list_parent;
    //유닛리스트 오브젝트
    public GameObject unit_list_object;

    //이미지
    public Image deck_image;
    public Image unit_image;

    //덱 빈칸 이미지
    public Sprite deck_blank;

    private void Awake()
    {
        
    }

    void Start()
    {
        //유닛리스트 오브젝트 모음집 태그로 찾기
        unit_list_parent = GameObject.FindWithTag("UnitListParent");
        //유닛리스트 오브젝트 태그로 찾기
        unit_list_object = unit_list_parent.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        //현재구조) object child (0) = image, 1~3 = sprite, child 1~3에서 0(image)로 sprite 받아오는방법.
        //1. idle, 2. checked, 3. 

        UnitListInit();
        DeckInit();
        //아이콘 초기화
        ImageInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //덱 불러오기 함수
    public void DeckInit()
    {
        //GameData에서 유닛코드 가져오기
        for (int i = 0; i < GameData.Instance.deck_size; i++)
        {
            deck_data.Add(new UnitData(GameData.Instance.unit_deck_list.list[i].unit_num, false, transform.GetChild(3).GetChild(0).GetChild(0).GetChild(i).gameObject));
        }

        //패시브 가져오기
        passive_data.Add(new UnitData(GameData.Instance.passive_deck_list.list[0].unit_num, false, transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject));
        
        //덱 체크하고, 유닛리스트와 겹치는 부분 수정하기
        CheckDeck();
    }

    //덱 체크 함수
    //체크덱을 덱 종류별로 나누는게 좋을듯?

    //이건 DeckInit에 있는게 더 나을듯.
    public void CheckDeck()
    {
        //가져온 데이터중, unit_number가 0이 아닐때 isfull을 true로 변경
        //패시브 먼저
        if (passive_data[0].unit_number > 300)
        {
            for (int j = 0; j < GameData.Instance.passive_all_list.list.Count; j++)
            {
                //normal_unit_list[j]의 unit_number가 deck의 unit_number값과 같다면, 그 인스턴스의 is_used를 true로 변경
                if (all_passive_list[j].unit_number == passive_data[0].unit_number)
                {
                    all_passive_list[j].is_used = true;
                    break;
                }
            }
        }

        //덱 체크
        for (int i = 0; i < GameData.Instance.deck_size; i++)
        {
            if (deck_data[i].unit_number > 0)
            {
                deck_data[i].is_full = true;

                //버프
                if (deck_data[i].unit_number > 200)
                {
                    for (int j = 0; j < all_buff_list.Count; j++)
                    {
                        //normal_unit_list[j]의 unit_number가 deck의 unit_number값과 같다면, 그 인스턴스의 is_used를 true로 변경
                        if (all_buff_list[j].unit_number == deck_data[i].unit_number)
                        {
                            all_buff_list[j].is_used = true;
                            break;
                        }
                    }
                }
                //마법
                else if (deck_data[i].unit_number > 100)
                {
                    for (int j = 0; j < all_magic_list.Count; j++)
                    {
                        //normal_unit_list[j]의 unit_number가 deck의 unit_number값과 같다면, 그 인스턴스의 is_used를 true로 변경
                        if (all_magic_list[j].unit_number == deck_data[i].unit_number)
                        {
                            all_magic_list[j].is_used = true;
                            break;
                        }
                    }
                }
                //유닛
                else
                {
                    for (int j = 0; j < all_unit_list.Count; j++)
                    {
                        //normal_unit_list[j]의 unit_number가 deck의 unit_number값과 같다면, 그 인스턴스의 is_used를 true로 변경
                        if (all_unit_list[j].unit_number == deck_data[i].unit_number)
                        {
                            all_unit_list[j].is_used = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                deck_data[i].is_full = false;
            }
        }
    }


    //유닛 리스트 불러오기 함수
    public void UnitListInit()
    {
        //유닛 리스트 GameData에서 불러오기

        //(유닛 코드, is_have, is_used, 유닛선택버튼 오브젝트)
        //유닛 1페이지
        for (int i = 0; i < 8; i++)
        {
            all_unit_list.Add(new UnitList(GameData.Instance.unit_all_list.list[i].unit_number, GameData.Instance.unit_all_list.list[i].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //유닛 2페이지
        //유닛 오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;

        for (int i = 0; i < 8; i++)
        {
            all_unit_list.Add(new UnitList(GameData.Instance.unit_all_list.list[i + 8].unit_number, GameData.Instance.unit_all_list.list[i + 8].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //유닛 3페이지
        //유닛 오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;

        for (int i = 0; i < 8; i++)
        {
            all_unit_list.Add(new UnitList(GameData.Instance.unit_all_list.list[i + 16].unit_number, GameData.Instance.unit_all_list.list[i + 16].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //유닛 4페이지
        //유닛 오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(3).GetChild(0).GetChild(0).gameObject;

        for (int i = 0; i < 8; i++)
        {
            all_unit_list.Add(new UnitList(GameData.Instance.unit_all_list.list[i + 24].unit_number, GameData.Instance.unit_all_list.list[i + 24].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }


        //마법리스트

        //마법 1페이지
        //오브젝트 수정
        unit_list_parent = GameObject.FindWithTag("MagicListParent");
        unit_list_object = unit_list_parent.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_magic_list.Add(new UnitList(GameData.Instance.magic_all_list.list[i].unit_number, GameData.Instance.magic_all_list.list[i].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //마법 2페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_magic_list.Add(new UnitList(GameData.Instance.magic_all_list.list[i + 8].unit_number, GameData.Instance.magic_all_list.list[i + 8].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //마법 3페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_magic_list.Add(new UnitList(GameData.Instance.magic_all_list.list[i + 16].unit_number, GameData.Instance.magic_all_list.list[i + 16].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //마법 4페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(3).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_magic_list.Add(new UnitList(GameData.Instance.magic_all_list.list[i + 24].unit_number, GameData.Instance.magic_all_list.list[i + 24].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }

        //버프 리스트

        //버프 1페이지
        //오브젝트 수정
        unit_list_parent = GameObject.FindWithTag("BuffListParent");
        unit_list_object = unit_list_parent.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_buff_list.Add(new UnitList(GameData.Instance.buff_all_list.list[i].unit_number, GameData.Instance.buff_all_list.list[i].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //버프 2페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_buff_list.Add(new UnitList(GameData.Instance.buff_all_list.list[i + 8].unit_number, GameData.Instance.buff_all_list.list[i + 8].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //버프 3페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_buff_list.Add(new UnitList(GameData.Instance.buff_all_list.list[i + 16].unit_number, GameData.Instance.buff_all_list.list[i + 16].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //버프 4페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(3).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_buff_list.Add(new UnitList(GameData.Instance.buff_all_list.list[i + 24].unit_number, GameData.Instance.buff_all_list.list[i + 24].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }

        //패시브 리스트

        //패시브 1페이지
        //오브젝트 수정
        unit_list_parent = GameObject.FindWithTag("PassiveListParent");
        unit_list_object = unit_list_parent.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_passive_list.Add(new UnitList(GameData.Instance.passive_all_list.list[i].unit_number, GameData.Instance.passive_all_list.list[i].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //패시브 2페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_passive_list.Add(new UnitList(GameData.Instance.passive_all_list.list[i + 8].unit_number, GameData.Instance.passive_all_list.list[i + 8].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //패시브 3페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_passive_list.Add(new UnitList(GameData.Instance.passive_all_list.list[i + 16].unit_number, GameData.Instance.passive_all_list.list[i + 16].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
        //패시브 4페이지
        //오브젝트 수정
        unit_list_object = unit_list_parent.transform.GetChild(3).GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < 8; i++)
        {
            all_passive_list.Add(new UnitList(GameData.Instance.passive_all_list.list[i + 24].unit_number, GameData.Instance.passive_all_list.list[i + 24].is_have, false, unit_list_object.transform.GetChild(i).gameObject));
        }
    }

    //유닛 리스트 체크
    public void CheckUnit()
    {

    }

    public void SaveDeckChanged()
    {
        List<int> num = new List<int>();

        num.Add(0);

        //i < 덱사이즈
        for (int i = 0; i < GameData.Instance.deck_size; i++)
        {
            GameData.Instance.unit_deck_list.list[i] = new NumberDeck(deck_data[i].unit_number);
        }

        GameData.Instance.passive_deck_list.list[0] = new NumberDeck(passive_data[0].unit_number);
    }

    //유닛리스트 클릭
    public void DragUnitToDeck(int num)
    {
        //클릭한 버튼의 name을 int형으로 변환
        //int num = int.Parse(EventSystem.current.currentSelectedGameObject.name);


        //유닛일때
        if (num < 100)
        {
            //해당 유닛을 가지고 있는가?
            if (all_unit_list[num].is_have == true)
            {
                //사용중인지 체크
                if (all_unit_list[num].is_used == true)
                {
                    for (int i = 0; i < GameData.Instance.deck_size; i++)
                    {
                        //버튼의 unit_number와 같은 unit_number 찾아서 해당 덱 비워주기
                        if (deck_data[i].unit_number == all_unit_list[num].unit_number)
                        {

                            deck_data[i].is_full = false;
                            deck_data[i].unit_number = 0;
                            all_unit_list[num].is_used = false;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < GameData.Instance.deck_size; i++)
                    {
                        //덱의 빈공간을 찾아서 넣어주기
                        if (deck_data[i].is_full == false)
                        {
                            deck_data[i].is_full = true;
                            deck_data[i].unit_number = all_unit_list[num].unit_number;
                            all_unit_list[num].is_used = true;
                            break;
                        }
                        else if (i == GameData.Instance.deck_size - 1)
                        {
                            //덱이 꽉찼을때
                        }
                    }
                }
            }
        }
        else if (num < 200)
        {
            if (all_magic_list[num - 100].is_have == true)
            {
                //사용중인지 체크
                if (all_magic_list[num - 100].is_used == true)
                {
                    for (int i = 0; i < GameData.Instance.deck_size; i++)
                    {
                        //버튼의 unit_number와 같은 unit_number 찾아서 해당 덱 비워주기
                        if (deck_data[i].unit_number == all_magic_list[num - 100].unit_number)
                        {

                            deck_data[i].is_full = false;
                            deck_data[i].unit_number = 0;
                            all_magic_list[num - 100].is_used = false;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < GameData.Instance.deck_size; i++)
                    {
                        //덱의 빈공간을 찾아서 넣어주기
                        if (deck_data[i].is_full == false)
                        {
                            deck_data[i].is_full = true;
                            deck_data[i].unit_number = all_magic_list[num - 100].unit_number;
                            all_magic_list[num - 100].is_used = true;
                            break;
                        }
                        else if (i == GameData.Instance.deck_size - 1)
                        {
                            //덱이 꽉찼을때
                        }
                    }
                }
            }
        }
        else if (num < 300)
        {
            if (all_buff_list[num - 200].is_have == true)
            {
                //사용중인지 체크
                if (all_buff_list[num - 200].is_used == true)
                {
                    for (int i = 0; i < GameData.Instance.deck_size; i++)
                    {
                        //버튼의 unit_number와 같은 unit_number 찾아서 해당 덱 비워주기
                        if (deck_data[i].unit_number == all_buff_list[num - 200].unit_number)
                        {

                            deck_data[i].is_full = false;
                            deck_data[i].unit_number = 0;
                            all_buff_list[num - 200].is_used = false;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < GameData.Instance.deck_size; i++)
                    {
                        //덱의 빈공간을 찾아서 넣어주기
                        if (deck_data[i].is_full == false)
                        {
                            deck_data[i].is_full = true;
                            deck_data[i].unit_number = all_buff_list[num - 200].unit_number;
                            all_buff_list[num - 200].is_used = true;
                            break;
                        }
                        else if (i == GameData.Instance.deck_size - 1)
                        {
                            //덱이 꽉찼을때
                        }
                    }
                }
            }
        }
        else
        {
            //패시브는 따로
            if (all_passive_list[num - 300].is_have == true)
            {
                //사용중인지 체크
                if (all_passive_list[num - 300].is_used == true)
                {
                    //패시브 덱 비우기
                    if (passive_data[0].unit_number == all_passive_list[num - 300].unit_number)
                    {
                        passive_data[0].is_full = false;
                        passive_data[0].unit_number = 0;
                        all_passive_list[num - 300].is_used = false;
                    }
                }
                else
                {
                    if (passive_data[0].unit_number != 0)
                    {
                        //한칸짜리라 바로 교체해주기
                        all_passive_list[passive_data[0].unit_number - 301].is_used = false;
                        passive_data[0].unit_number = all_passive_list[num - 300].unit_number;
                        all_passive_list[num - 300].is_used = true;
                    }
                    else
                    {
                        //비어있을때
                        passive_data[0].is_full = true;
                        passive_data[0].unit_number = all_passive_list[num - 300].unit_number;
                        all_passive_list[num - 300].is_used = true;
                    }

                }
            }
        }

        DeckSort();
        NormalDeckImage();
        NormalUnitImage(num);
        SaveDeckChanged();
    }

    //덱정렬
    public void DeckSort()
    {
        UnitData temp = new UnitData(0, false, null);
        for (int i = 0; i < deck_data.Count - 1; i++)
        {
            for (int j = i + 1; j < deck_data.Count; j++)
            {
                if (deck_data[i].unit_number < deck_data[j].unit_number)
                {
                    temp.unit_number = deck_data[i].unit_number;
                    temp.is_full = deck_data[i].is_full;

                    deck_data[i].unit_number = deck_data[j].unit_number;
                    deck_data[i].is_full = deck_data[j].is_full;

                    deck_data[j].unit_number = temp.unit_number;
                    deck_data[j].is_full = temp.is_full;
                }
            }
        }
    }

    public void ImageInit()
    {
        //덱 스캔 후 이미지 설정
        NormalDeckImage();

        //리스트 스캔 후 이미지 설정
        //유닛 이미지
        for (int i = 0; i < 32; i++)
        {
            //이미지 등록
            unit_image = all_unit_list[i].unit_object.transform.GetChild(0).GetComponent<Image>();
            //가지고 있으면
            if (all_unit_list[i].is_have == true)
            {
                //사용 중이면
                if (all_unit_list[i].is_used == true)
                {
                    //(2)스프라이트 사용
                    unit_image.sprite = all_unit_list[i].unit_object.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    //(1)스프라이트 사용
                    unit_image.sprite = all_unit_list[i].unit_object.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                }
            }
            else
            {
                unit_image.sprite = all_unit_list[i].unit_object.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
            }
        }
        //마법 이미지
        for (int i = 0; i < 32; i++)
        {
            //이미지 등록
            unit_image = all_magic_list[i].unit_object.transform.GetChild(0).GetComponent<Image>();
            //가지고 있으면
            if (all_magic_list[i].is_have == true)
            {
                //사용 중이면
                if (all_magic_list[i].is_used == true)
                {
                    //(2)스프라이트 사용
                    unit_image.sprite = all_magic_list[i].unit_object.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    //(1)스프라이트 사용
                    unit_image.sprite = all_magic_list[i].unit_object.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                }
            }
            else
            {
                unit_image.sprite = all_magic_list[i].unit_object.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
            }
        }
        //버프 이미지
        for (int i = 0; i < 32; i++)
        {
            //이미지 등록
            unit_image = all_buff_list[i].unit_object.transform.GetChild(0).GetComponent<Image>();
            //가지고 있으면
            if (all_buff_list[i].is_have == true)
            {
                //사용 중이면
                if (all_buff_list[i].is_used == true)
                {
                    //(2)스프라이트 사용
                    unit_image.sprite = all_buff_list[i].unit_object.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    //(1)스프라이트 사용
                    unit_image.sprite = all_buff_list[i].unit_object.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                }
            }
            else
            {
                unit_image.sprite = all_buff_list[i].unit_object.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
            }
        }
        //패시브 이미지
        for (int i = 0; i < 32; i++)
        {
            //이미지 등록
            unit_image = all_passive_list[i].unit_object.transform.GetChild(0).GetComponent<Image>();
            //가지고 있으면
            if (all_passive_list[i].is_have == true)
            {
                //사용 중이면
                if (all_passive_list[i].is_used == true)
                {
                    //(2)스프라이트 사용
                    unit_image.sprite = all_passive_list[i].unit_object.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    //(1)스프라이트 사용
                    unit_image.sprite = all_passive_list[i].unit_object.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                }
            }
            else
            {
                unit_image.sprite = all_passive_list[i].unit_object.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    //노말 덱 이미지 변경
    public void NormalDeckImage()
    {
        //패시브 먼저
        //deck의 image오브젝트의 image 컴포넌트를 넣어주기
        deck_image = passive_data[0].deck_object.GetComponent<Image>();
        //full이면 이미지 활성화
        if (passive_data[0].is_full == true)
        {
            if (passive_data[0].unit_number > 300)
            {
                for (int j = 0; j < GameData.Instance.passive_all_list.list.Count; j++)
                {
                    if (passive_data[0].unit_number == all_passive_list[j].unit_number)
                    {
                        deck_image.sprite = all_passive_list[j].unit_object.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite;
                        break;
                    }
                }
            }
        }
        else
        {
            deck_image.sprite = null;
        }

        for (int i = 0; i < GameData.Instance.deck_size; i++)
        {
            //deck의 image오브젝트의 image 컴포넌트를 넣어주기
            deck_image = deck_data[i].deck_object.GetComponent<Image>();
            //덱이 full이면 해당 유닛 이미지 활성화
            if (deck_data[i].is_full == true)
            {
                //유닛
                if (deck_data[i].unit_number < 101)
                {
                    for (int j = 0; j < GameData.Instance.unit_all_list.list.Count; j++)
                    {
                        if (deck_data[i].unit_number == all_unit_list[j].unit_number)
                        {
                            deck_image.sprite = all_unit_list[j].unit_object.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite;
                            break;
                        }
                    }
                }
                //마법
                else if (deck_data[i].unit_number < 201)
                {
                    for (int j = 0; j < GameData.Instance.magic_all_list.list.Count; j++)
                    {
                        if (deck_data[i].unit_number == all_magic_list[j].unit_number)
                        {
                            deck_image.sprite = all_magic_list[j].unit_object.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite;
                            break;
                        }
                    }
                }
                //버프
                else if (deck_data[i].unit_number < 301)
                {
                    for (int j = 0; j < GameData.Instance.buff_all_list.list.Count; j++)
                    {
                        if (deck_data[i].unit_number == all_buff_list[j].unit_number)
                        {
                            deck_image.sprite = all_buff_list[j].unit_object.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite;
                            break;
                        }
                    }
                }
            }
            else
            {
                //덱이 빈칸일때
                deck_image.sprite = deck_blank;
            }
        }
    }

    //유닛 리스트 이미지 바꾸기
    public void NormalUnitImage(int n)
    {
        if (n < 100)
        {
            //유닛 이미지
            for (int i = 0; i < 32; i++)
            {
                //이미지 등록
                unit_image = all_unit_list[i].unit_object.transform.GetChild(0).GetComponent<Image>();
                //가지고 있으면
                if (all_unit_list[i].is_have == true)
                {
                    //사용 중이면
                    if (all_unit_list[i].is_used == true)
                    {
                        //(2)스프라이트 사용
                        unit_image.sprite = all_unit_list[i].unit_object.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        //(1)스프라이트 사용
                        unit_image.sprite = all_unit_list[i].unit_object.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                    }
                }
                else
                {
                    unit_image.sprite = all_unit_list[i].unit_object.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
                }
            }
        }
        else if (n < 200)
        {
            //마법 이미지
            for (int i = 0; i < 32; i++)
            {
                //이미지 등록
                unit_image = all_magic_list[i].unit_object.transform.GetChild(0).GetComponent<Image>();
                //가지고 있으면
                if (all_magic_list[i].is_have == true)
                {
                    //사용 중이면
                    if (all_magic_list[i].is_used == true)
                    {
                        //(2)스프라이트 사용
                        unit_image.sprite = all_magic_list[i].unit_object.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        //(1)스프라이트 사용
                        unit_image.sprite = all_magic_list[i].unit_object.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                    }
                }
                else
                {
                    unit_image.sprite = all_magic_list[i].unit_object.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
                }
            }
        }
        else if (n < 300)
        {
            //버프 이미지
            for (int i = 0; i < 32; i++)
            {
                //이미지 등록
                unit_image = all_buff_list[i].unit_object.transform.GetChild(0).GetComponent<Image>();
                //가지고 있으면
                if (all_buff_list[i].is_have == true)
                {
                    //사용 중이면
                    if (all_buff_list[i].is_used == true)
                    {
                        //(2)스프라이트 사용
                        unit_image.sprite = all_buff_list[i].unit_object.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        //(1)스프라이트 사용
                        unit_image.sprite = all_buff_list[i].unit_object.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                    }
                }
                else
                {
                    unit_image.sprite = all_buff_list[i].unit_object.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
                }
            }
        }
        else
        {
            for (int i = 0; i < 32; i++)
            {
                //이미지 등록
                unit_image = all_passive_list[i].unit_object.transform.GetChild(0).GetComponent<Image>();
                //가지고 있으면
                if (all_passive_list[i].is_have == true)
                {
                    //사용 중이면
                    if (all_passive_list[i].is_used == true)
                    {
                        //(2)스프라이트 사용
                        unit_image.sprite = all_passive_list[i].unit_object.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        //(1)스프라이트 사용
                        unit_image.sprite = all_passive_list[i].unit_object.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                    }
                }
                else
                {
                    unit_image.sprite = all_passive_list[i].unit_object.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
                }
            }
        }

    }

    public void ClickDeck()
    {
        //클릭한 버튼의 name을 int형으로 변환
        int num = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        int unit_num = deck_data[num].unit_number - 1;

        //해당 덱의 unit_number을 참고해서 유닛리스트 검색
        if (deck_data[num].unit_number != 0)
        {
            if (deck_data[num].unit_number < 101)
            {
                all_unit_list[deck_data[num].unit_number - 1].is_used = false;
                deck_data[num].is_full = false;
                deck_data[num].unit_number = 0;
            }
            else if (deck_data[num].unit_number < 201)
            {
                all_magic_list[deck_data[num].unit_number - 101].is_used = false;
                deck_data[num].is_full = false;
                deck_data[num].unit_number = 0;
            }
            else if (deck_data[num].unit_number < 301)
            {
                all_buff_list[deck_data[num].unit_number - 201].is_used = false;
                deck_data[num].is_full = false;
                deck_data[num].unit_number = 0;
            }
        }


        DeckSort();
        NormalDeckImage();
        NormalUnitImage(unit_num);
        SaveDeckChanged();
    }

    public void ClickDeckPassive()
    {
        if (passive_data[0].unit_number != 0)
        {
            int unit_num = passive_data[0].unit_number - 1;

            all_passive_list[passive_data[0].unit_number - 301].is_used = false;
            passive_data[0].is_full = false;
            passive_data[0].unit_number = 0;

            NormalDeckImage();
            NormalUnitImage(unit_num);
            SaveDeckChanged();
        }
    }
}