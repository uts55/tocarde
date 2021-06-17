using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Storage_Select : MonoBehaviour
{/*
    //게임시스템
    public GameObject gameSystem;
    public GameSystem gameSystem_script;
    
    //유닛코드
    public int unit_number;
    //1성 리스트 부모
    public GameObject parent_1;
    //2성 리스트 부모
    public GameObject parent_2;
    //3성 리스트 부모

    //1성 리스트
    public List<GameObject> unit_List_1 = new List<GameObject>();
    //2성 리스트
    public List<GameObject> unit_List_2 = new List<GameObject>();
    //3성 리스트

    //유닛코드 최댓값
    public int unit_num_end;
    //스폰 포인트
    public GameObject spawn_Point;
    //찼는가?
    public bool is_full;
    // Start is called before the first frame update
    void Start()
    {
        //게임 시스템 스크립트
        gameSystem_script = gameSystem.GetComponent<GameSystem>();

        //유닛코드 최댓값
        unit_num_end = gameSystem_script.unit_num_end;

        //unit_num_end = 7;

        //유닛코드 초기화
        unit_number = 0;

        //비어있음
        is_full = false;
        
        //unit_List_1에 1성(parent_1)
        for(int i = 0; i < unit_num_end; i++)
        {
            unit_List_1.Add(parent_1.transform.GetChild(i).gameObject);
            unit_List_2.Add(parent_2.transform.GetChild(i).gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (is_full == false)
        {

        }
        else if (is_full == true)
        {
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(spawn_Point.transform.position.x, spawn_Point.transform.position.y + random,-random*100);
            //1성이면
            if(unit_number / 1000 == 0)
            {
                Instantiate(unit_List_1[unit_number - 1], randomspot, Quaternion.identity);
            }

            //2성이면
            else if(unit_number / 1000 == 1)
            {
                Instantiate(unit_List_2[unit_number - 1001], randomspot, Quaternion.identity);
            }

            //3성이면
            else if(unit_number / 1000 == 2)
            {

            }

            //비워주기
            is_full = false;
            //유닛코드 초기화
            unit_number = 0;
        }
    }*/
}
