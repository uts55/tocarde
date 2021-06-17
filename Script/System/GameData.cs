using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;


//기본 데이터 모음
public class BasicData
{
    //진행도, 골드, 보석
    public int game_progress;
    public int account_gold;
    public int account_gem;
    public bool account_shop;

    public BasicData(int progress, int gold, int gem, bool shop)
    {
        game_progress = progress;
        account_gold = gold;
        account_gem = gem;
        account_shop = shop;
    }
}

//덱
//직렬화 (아마도)
[System.Serializable]
public class NumberDeck
{
    //유닛 코드 저장
    public int unit_num;

    //생성자
    public NumberDeck(int num)
    {
        unit_num = num;
    }
}

//덱의 유닛코드 리스트를 클래스로
public class DeckList
{
    public List<NumberDeck> list = new List<NumberDeck>();
}

//유닛코드 데이터 저장할 클래스
[System.Serializable]
public class UnitNumberData
{
    //유닛 코드 저장
    public int unit_number;
    //유닛 이름
    public string unit_name;
    //유닛 인구, 자원, 고급자원
    public int population;
    public int cost1;
    public int cost2;

    //유닛의 레벨, 추가로 가지고 있는 갯수
    public int unit_level;
    public int unit_count;

    //데미지, 체력, 공격속도, 방어력, 이동속도, 치명타
    public float attack_damage;
    public float health;
    public float attack_speed;
    public float defense;
    public float move_speed;
    public float critical_per;

    //유닛 타입, 등급
    public int type;
    public int grade;

    //유닛 설명
    public string description;

    //유닛이 있는지
    public bool is_have;

    //생성자 (유닛코드, 가지고있는지, 이름, 인구, 일반자원, 고급자원, 레벨, 갯수, 공격력, 체력, 공격속도, 방어력, 이동속도, 치명타확률, 유닛타입, 유닛등급)
    public UnitNumberData(int unit_num, bool ishave, string name, int unit_population, int cost_1, int cost_2, int level , int count, float unit_damage, float unit_health, float unit_attack_speed, float unit_defense, float unit_move_speed, float unit_critical, int unit_type, int unit_grade, string unit_description)
    {
        unit_number = unit_num;
        is_have = ishave;
        unit_name = name;
        population = unit_population;
        cost1 = cost_1;
        cost2 = cost_2;
        unit_level = level;
        unit_count = count;
        attack_damage = unit_damage;
        health = unit_health;
        attack_speed = unit_attack_speed;
        defense = unit_defense;
        move_speed = unit_move_speed;
        critical_per = unit_critical;
        type = unit_type;
        grade = unit_grade;
        description = unit_description;
    }
}

//유닛코드 데이터 클래스의 리스트
public class UnitNumberDataList
{
    public List<UnitNumberData> list = new List<UnitNumberData>();
}

//등급별 카드 리스트를 json으로 저장하기위해 클래스로 정의
public class CardList
{
    public List<int> list = new List<int>();
}

public class GameData : MonoBehaviour
{
    //게임데이터의 인스턴스를 담는 static변수
    private static GameData instance = null;

    //기본 게임데이터 (진행도, 골드, 보석)
    public BasicData basic_data = new BasicData(0, 0, 0, false);

    //전체 유닛 리스트
    public UnitNumberDataList unit_all_list = new UnitNumberDataList();
    //마법 리스트
    public UnitNumberDataList magic_all_list = new UnitNumberDataList();
    //버프 리스트
    public UnitNumberDataList buff_all_list = new UnitNumberDataList();
    //패시브 리스트
    public UnitNumberDataList passive_all_list = new UnitNumberDataList();

    //등급별 카드 리스트
    public CardList normal_card_list = new CardList();
    public CardList rare_card_list = new CardList();
    public CardList unique_card_list = new CardList();
    public CardList legend_card_list = new CardList();

    //전체 리스트
    public UnitNumberDataList all_list = new UnitNumberDataList();

    //덱 리스트
    public DeckList unit_deck_list = new DeckList();
    //패시브만 따로
    public DeckList passive_deck_list = new DeckList();

    //덱 사이즈
    public int deck_size;

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환시 없어지지않게
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //씬 이동시 그 씬에도 GameData가 존재하면, 이전씬에서 쓰던 인스턴스 사용.
            //instance에 인스턴스가 존재한다면 자신을 삭제.
            Destroy(this.gameObject);
        }
        //Awake시 데이터, 덱, 유닛리스트 로드 및 세이브
        deck_size = 9;
        if(!Directory.Exists(Application.persistentDataPath + "/Data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath +"/Data");
        }
        LoadData();
        SaveData();
        //DeckInit();
        LoadDeck();
        SaveDeck();
        //UnitInit();
        LoadUnitList();
        SaveUnitList();

        //유닛 등급별 정리
        //CardGradeOrganizeInit();
        LoadGradeList();
        SaveGradeList();
    }

    private void Start()
    {

    }

    //게임 데이터 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static GameData Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void DeckMake()
    {

    }

    //데이터 저장
    public void SaveData()
    {
        //함수 호출 확인
        Debug.Log("Save");
        //Json으로 변환
        string basic_json = JsonUtility.ToJson(basic_data);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/BasicData.json", basic_json);
    }

    //데이터 불러오기
    public void LoadData()
    {
        //함수 호출 확인
        Debug.Log("Load");
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/BasicData.json"))
        {
            string json_string = File.ReadAllText(Application.persistentDataPath + "/Data/BasicData.json");

            //Json을 BasicData로 변환
            basic_data = JsonUtility.FromJson<BasicData>(json_string);
        }
        else
        {
            TextAsset json_string = Resources.Load("Data/BasicData") as TextAsset;
            basic_data = JsonUtility.FromJson<BasicData>(json_string.ToString());
        }
        //로드 후 값 확인
        Debug.Log(basic_data.game_progress);
        Debug.Log(basic_data.account_gold);
        Debug.Log(basic_data.account_gem);

    }

    //덱 저장
    public void SaveDeck()
    {
        //덱저장
        //함수 호출 확인
        Debug.Log("Save");
        //Json으로 변환
        string deck_json = JsonUtility.ToJson(unit_deck_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/DeckData.json", deck_json);

        //패시브 따로 저장
        //Json으로 변환
        deck_json = JsonUtility.ToJson(passive_deck_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/PassiveDeckData.json", deck_json);
    }

    //덱 불러오기
    public void LoadDeck()
    {
        //덱 로드
        //함수 호출 확인
        Debug.Log("Load");
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/DeckData.json"))
        {
            string json_string = File.ReadAllText(Application.persistentDataPath + "/Data/DeckData.json");

            //Json을 DeckList로 변환
            unit_deck_list = JsonUtility.FromJson<DeckList>(json_string);
        }
        else
        {
            TextAsset json_string = Resources.Load("Data/DeckData") as TextAsset;
            unit_deck_list = JsonUtility.FromJson<DeckList>(json_string.ToString());
        }
        //로드 후 값 확인
        for (int i = 0; i < deck_size; i++)
        {
            Debug.Log(unit_deck_list.list[i].unit_num);
        }


        //패시브 따로 로드
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/PassiveDeckData.json"))
        {
            string json_string = File.ReadAllText(Application.persistentDataPath + "/Data/PassiveDeckData.json");

            //Json을 passive_deck_list로 변환
            passive_deck_list = JsonUtility.FromJson<DeckList>(json_string);
        }
        else
        {
            TextAsset json_string = Resources.Load("Data/PassiveDeckData") as TextAsset;
            passive_deck_list = JsonUtility.FromJson<DeckList>(json_string.ToString());
        }
    }

    //유닛 리스트 저장
    public void SaveUnitList()
    {
        //함수 호출 확인
        Debug.Log("Save");

        string deck_json;

        //전체 유닛 리스트
        deck_json = JsonUtility.ToJson(unit_all_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/AllUnitList.json", deck_json);

        //전체 마법 리스트
        deck_json = JsonUtility.ToJson(magic_all_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/AllMagicList.json", deck_json);

        //전체 버프 리스트
        deck_json = JsonUtility.ToJson(buff_all_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/AllBuffList.json", deck_json);

        //전체 패시브 리스트
        deck_json = JsonUtility.ToJson(passive_all_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/AllPassiveList.json", deck_json);
    }

    //유닛 리스트 불러오기
    public void LoadUnitList()
    {
        string json_string;
        //함수 호출 확인
        Debug.Log("Load");

        //전체 유닛 리스트
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/AllUnitList.json"))
        {
            json_string = File.ReadAllText(Application.persistentDataPath + "/Data/AllUnitList.json");
            //Json을 UnitNumberDataList로 변환
            unit_all_list = JsonUtility.FromJson<UnitNumberDataList>(json_string);
        }
        else
        {
            TextAsset json_text = Resources.Load("Data/AllUnitList") as TextAsset;
            unit_all_list = JsonUtility.FromJson<UnitNumberDataList>(json_text.ToString());
        }
        //전체 마법 리스트
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/AllMagicList.json"))
        {
            json_string = File.ReadAllText(Application.persistentDataPath + "/Data/AllMagicList.json");
            //Json을 UnitNumberDataList로 변환
            magic_all_list = JsonUtility.FromJson<UnitNumberDataList>(json_string);
        }
        else
        {
            TextAsset json_text = Resources.Load("Data/AllMagicList") as TextAsset;
            magic_all_list = JsonUtility.FromJson<UnitNumberDataList>(json_text.ToString());
        }
        //전체 버프 리스트
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/AllBuffList.json"))
        {
            json_string = File.ReadAllText(Application.persistentDataPath + "/Data/AllBuffList.json");
            //Json을 UnitNumberDataList로 변환
            buff_all_list = JsonUtility.FromJson<UnitNumberDataList>(json_string);
        }
        else
        {
            TextAsset json_text = Resources.Load("Data/AllBuffList") as TextAsset;
            buff_all_list = JsonUtility.FromJson<UnitNumberDataList>(json_text.ToString());
        }
        //전체 패시브 리스트
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/AllPassiveList.json"))
        {
            json_string = File.ReadAllText(Application.persistentDataPath + "/Data/AllPassiveList.json");
            //Json을 UnitNumberDataList로 변환
            passive_all_list = JsonUtility.FromJson<UnitNumberDataList>(json_string);
        }
        else
        {
            TextAsset json_text = Resources.Load("Data/AllPassiveList") as TextAsset;
            passive_all_list = JsonUtility.FromJson<UnitNumberDataList>(json_text.ToString());
        }
        all_list.list.AddRange(unit_all_list.list);
        all_list.list.AddRange(magic_all_list.list);
        all_list.list.AddRange(buff_all_list.list);
    }

    //덱 초기화
    public void DeckInit()
    {
        for (int i = 0; i < deck_size; i++)
        {
            unit_deck_list.list.Add(new NumberDeck(0));
            Debug.Log(unit_deck_list.list[i].unit_num);
        }
        passive_deck_list.list.Add(new NumberDeck(0));
    }

    //카드리스트 초기화
    public void UnitInit()
    {
        //유닛 리스트 (1 ~ )
        for (int i = 0; i < 100; i++)
        {
            unit_all_list.list.Add(new UnitNumberData(i + 1, true, "Unit" + i.ToString(), 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, "null"));
        }
        //마법 리스트 (101 ~ )
        for (int i = 0; i < 100; i++)
        {
            magic_all_list.list.Add(new UnitNumberData(i + 101, true, "Magic" + i.ToString(), 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, "null"));
        }
        //버프 리스트 (201 ~ )
        for (int i = 0; i < 100; i++)
        {
            buff_all_list.list.Add(new UnitNumberData(i + 201, true, "Buff" + i.ToString(), 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, "null"));
        }
        //패시브 리스트 (301 ~ )
        for (int i = 0; i < 100; i++)
        {
            passive_all_list.list.Add(new UnitNumberData(i + 301, true, "Passive" + i.ToString(), 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, "null"));
        }
    }

    //종료시 데이터, 덱 저장
    private void OnApplicationQuit()
    {
        SaveData();
        SaveDeck();
        SaveUnitList();
    }

    //카드 등급별 리스트 정리
    public void CardGradeOrganizeInit()
    {
        NormalCardOrganize();
        UniqueCardOrganize();
        LegendCardOrganize();
    }

    //노멀카드 정리
    public void NormalCardOrganize()
    {
        //유닛카드 스캔
        for (int i = 0; i < unit_all_list.list.Count; i++)
        {
            if (unit_all_list.list[i].grade == 0)
            {
                normal_card_list.list.Add(unit_all_list.list[i].unit_number);
            }
        }

        //마법카드 스캔
        for (int i = 0; i < magic_all_list.list.Count; i++)
        {
            if (magic_all_list.list[i].grade == 0)
            {
                normal_card_list.list.Add(magic_all_list.list[i].unit_number);
            }
        }

        //버프카드 스캔
        for (int i = 0; i < buff_all_list.list.Count; i++)
        {
            if (buff_all_list.list[i].grade == 0)
            {
                normal_card_list.list.Add(buff_all_list.list[i].unit_number);
            }
        }

        //패시브카드 스캔
        for (int i = 0; i < passive_all_list.list.Count; i++)
        {
            if (passive_all_list.list[i].grade == 0)
            {
                normal_card_list.list.Add(passive_all_list.list[i].unit_number);
            }
        }
    }

    //유니크카드 정리
    public void UniqueCardOrganize()
    {
        //유닛카드 스캔
        for (int i = 0; i < unit_all_list.list.Count; i++)
        {
            if (unit_all_list.list[i].grade == 1)
            {
                unique_card_list.list.Add(unit_all_list.list[i].unit_number);
            }
        }

        //마법카드 스캔
        for (int i = 0; i < magic_all_list.list.Count; i++)
        {
            if (magic_all_list.list[i].grade == 1)
            {
                unique_card_list.list.Add(magic_all_list.list[i].unit_number);
            }
        }

        //버프카드 스캔
        for (int i = 0; i < buff_all_list.list.Count; i++)
        {
            if (buff_all_list.list[i].grade == 1)
            {
                unique_card_list.list.Add(buff_all_list.list[i].unit_number);
            }
        }

        //패시브카드 스캔
        for (int i = 0; i < passive_all_list.list.Count; i++)
        {
            if (passive_all_list.list[i].grade == 1)
            {
                unique_card_list.list.Add(passive_all_list.list[i].unit_number);
            }
        }
    }

    //전설카드 정리
    public void LegendCardOrganize()
    {
        //유닛카드 스캔
        for (int i = 0; i < unit_all_list.list.Count; i++)
        {
            if (unit_all_list.list[i].grade == 2)
            {
                legend_card_list.list.Add(unit_all_list.list[i].unit_number);
            }
        }

        //마법카드 스캔
        for (int i = 0; i < magic_all_list.list.Count; i++)
        {
            if (magic_all_list.list[i].grade == 2)
            {
                legend_card_list.list.Add(magic_all_list.list[i].unit_number);
            }
        }

        //버프카드 스캔
        for (int i = 0; i < buff_all_list.list.Count; i++)
        {
            if (buff_all_list.list[i].grade == 2)
            {
                legend_card_list.list.Add(buff_all_list.list[i].unit_number);
            }
        }

        //패시브카드 스캔
        for (int i = 0; i < passive_all_list.list.Count; i++)
        {
            if (passive_all_list.list[i].grade == 2)
            {
                legend_card_list.list.Add(passive_all_list.list[i].unit_number);
            }
        }
    }

    //등급리스트 저장
    public void SaveGradeList()
    {
        string deck_json;

        //노멀 리스트
        deck_json = JsonUtility.ToJson(normal_card_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/NormalCardList.json", deck_json);

        //유니크 리스트
        deck_json = JsonUtility.ToJson(unique_card_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/UniqueCardList.json", deck_json);

        //레전드 리스트
        deck_json = JsonUtility.ToJson(legend_card_list);
        //저장
        File.WriteAllText(Application.persistentDataPath + "/Data/LegendCardList.json", deck_json);
    }

    //등급리스트 불러오기
    public void LoadGradeList()
    {
        string json_string;

        //노멀 카드 리스트
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/NormalCardList.json"))
        {
            json_string = File.ReadAllText(Application.persistentDataPath + "/Data/NormalCardList.json");
            //Json을 UnitNumberDataList로 변환
            normal_card_list = JsonUtility.FromJson<CardList>(json_string);
        }
        else
        {
            TextAsset json_text = Resources.Load("Data/NormalCardList") as TextAsset;
            normal_card_list = JsonUtility.FromJson<CardList>(json_text.ToString());
        }

        //유니크 카드 리스트
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/UniqueCardList.json"))
        {
            json_string = File.ReadAllText(Application.persistentDataPath + "/Data/UniqueCardList.json");
            //Json을 UnitNumberDataList로 변환
            unique_card_list = JsonUtility.FromJson<CardList>(json_string);
        }
        else
        {
            TextAsset json_text = Resources.Load("Data/UniqueCardList") as TextAsset;
            unique_card_list = JsonUtility.FromJson<CardList>(json_text.ToString());
        }
        //레전드 카드 리스트
        //불러오기
        if (File.Exists(Application.persistentDataPath + "/Data/LegendCardList.json"))
        {
            json_string = File.ReadAllText(Application.persistentDataPath + "/Data/LegendCardList.json");
            //Json을 UnitNumberDataList로 변환
            legend_card_list = JsonUtility.FromJson<CardList>(json_string);
        }
        else
        {
            TextAsset json_text = Resources.Load("Data/LegendCardList") as TextAsset;
            legend_card_list = JsonUtility.FromJson<CardList>(json_text.ToString());
        }
    }
}