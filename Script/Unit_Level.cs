using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Level : MonoBehaviour
{/*
    //게임시스템
    public GameObject gameSystem;
    public GameSystem gameSystem_script;

    //1성 레벨업 리스트
    public List<int> level_list_1 = new List<int>();
    //스토리지 리스트 (자식 리스트)
    public List<GameObject> storage_list = new List<GameObject>();
    //스크립트 접근
    public Storage_Select storage_script;
    //유닛 코드
    public int unit_number;
    //끝번호
    public int unit_number_end;

    // Start is called before the first frame update
    void Start()
    {
        //게임 시스템 스크립트
        gameSystem_script = gameSystem.GetComponent<GameSystem>();

        //유닛코드
        unit_number = 0;

        //끝번호
        unit_number_end = gameSystem_script.unit_num_end;
        //unit_number_end = 7;

        for (int i = 0; i < unit_number_end; i++)
        {
            level_list_1.Add(0);
        }

        for (int i = 0; i < 10; i++)
        {
            storage_list.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Check_Level()
    {
        Scan_Storage();
        Check_List();
    }

    public void Scan_Storage()
    {
        //스토리지 스캔
        //유닛코드 갯수 카운트
        for (int i = 0; i < 10; i++)
        {
            storage_script = storage_list[i].GetComponent<Storage_Select>();

            if (storage_script.is_full == true)
            {
                //unit_number에 유닛코드 담기
                unit_number = storage_script.unit_number;

                //유닛이 1성일때
                if (unit_number <= unit_number_end)
                {
                    level_list_1[unit_number - 1] += 1;
                }
            }
            else
            {

            }
        }
    }

    public void Check_List()
    {
        //유닛 리스트 1번부터 end까지 확인
        for (int i = 0; i < unit_number_end; i++)
        {
            //3마리 모이면
            if (level_list_1[i] == 3)
            {
                //유닛넘버 규칙
                //1성 1~999
                //2성 1000~1999
                //3성 11000~11999
                //이런식?

                //3개 모인 유닛 찾아서 지워주기
                for (int j = 0; j < 10; j++)
                {
                    storage_script = storage_list[j].GetComponent<Storage_Select>();
                    if (storage_script.unit_number == i + 1)
                    {
                        storage_script.unit_number = 0;
                        storage_script.is_full = false;
                    }
                }

                //빈공간 찾아서 상급유닛 넣어주기
                for (int j = 0; j < 10; j++)
                {
                    storage_script = storage_list[j].GetComponent<Storage_Select>();
                    if (storage_script.is_full == false)
                    {
                        storage_script.unit_number = i + 1001;
                        storage_script.is_full = true;
                        break;
                    }
                }
            }
            //클릭할때마다 스캔하기때문에 초기화시켜주기
            level_list_1[i] = 0;
        }
    }*/
}
