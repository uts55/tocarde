using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit_Select : MonoBehaviour
{
   /* //게임시스템
    public GameObject gameSystem;
    public GameSystem gameSystem_script;

    //지불 골드
    public int gold_pay;

    //손패
    public GameObject my_unit_list;
    public List<GameObject> unit_list = new List<GameObject>();
    //유닛 레벨업 스크립트
    public Unit_Level unit_level_script;
    //상점 초상화? 같은거
    public GameObject unit_model;
    //유닛 코드, 최솟값, 최댓값
    public int unit_number;
    public int unit_num_start;
    public int unit_num_end;
    //스크립트
    public Storage_Select storage_script;
    // Start is called before the first frame update
    void Start()
    {
        //게임 시스템 스크립트
        gameSystem_script = gameSystem.GetComponent<GameSystem>();

        //유닛 레벨업 스크립트
        unit_level_script = my_unit_list.GetComponent<Unit_Level>();

        //1성유닛 유닛코드 시작, 끝 설정
        unit_num_start = 1;
        unit_num_end = gameSystem_script.unit_num_end;
        //1에서 end사이 코드 지정
        unit_number = Random.Range(unit_num_start, unit_num_end + 1);
        //자식오브젝트 호출 및 활성화
        unit_model = transform.GetChild(0).gameObject;
        //손패크기

        //손패 넣어주기
        for(int i = 0; i < 10; i++)
        {
            unit_list.Add(my_unit_list.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //골드 설정
        setPay();
        if (gameSystem_script.gold - gold_pay >= 0)
        {
            //골드 소모
            gameSystem_script.gold -= gold_pay;
            //클릭시 비활성화
            this.gameObject.SetActive(false);
            //1번부터 순서대로 넣기
            for (int i = 0; i < 10; i++)
            {
                //손패의 Storage_Select 불러오기
                storage_script = unit_list[i].GetComponent<Storage_Select>();
                //손패가 찼을때
                if (storage_script.is_full == true)
                {
                    //마지막까지 찼을때
                    if (i == 9)
                    {
                        //스토리지에 있는 유닛 갯수 파악
                        unit_level_script.Scan_Storage();
                        //현재 클릭한 유닛의 갯수가 클릭한것까지 3개면
                        if (unit_level_script.level_list_1[unit_number - 1] + 1 == 3)
                        {
                            unit_level_script.level_list_1[unit_number - 1] += 1;
                            //체크해서 레벨업
                            unit_level_script.Check_List();
                        }
                        else
                        {                            
                            //3개가 안되면 갯수파악 리스트 초기화
                            for (int j = 0; j < unit_num_end; j++)
                            {
                                unit_level_script.level_list_1[j] = 0;
                            }
                            //돈돌려주기
                            gameSystem_script.gold += gold_pay;
                            //다시 액티브 시켜주기
                            this.gameObject.SetActive(true);
                        }
                    }
                    continue;
                }
                //손패가 비었을때
                else if (storage_script.is_full == false)
                {
                    storage_script.unit_number = this.unit_number;
                    storage_script.is_full = true;
                    unit_level_script.Check_Level();
                    break;
                }
            }
        }
        else
        {
            gameSystem_script.NotEnoughMinerals();
        }
    }

    public void reActive()
    {
        if(gameSystem_script.gold - 2 >= 0)
        {
            //리롤시 활성화
            this.gameObject.SetActive(true);
            //랜덤함수 호출
            unit_number = Random.Range(unit_num_start, unit_num_end + 1);
        }
    }


    public void setPay()
    {
        //1~4번유닛 2골드
        if (unit_number <= 4 && unit_number >= 1)
        {
            gold_pay = 2;
        }
        else if (unit_number == 5)
        {
            gold_pay = 3;
        }
        else if (unit_number <= 7 && unit_number >= 6)
        {
            gold_pay = 4;
        }
    }*/
}
