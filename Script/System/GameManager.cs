using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    //게임매니저의 인스턴스를 담는 static변수
    private static GameManager instance = null;

    //유닛 코드
    int unit_number;
    //유닛 개수
    //전체 유닛
    int unit_all_end;
    //노멀
    int unit_normal_end;
    
    //골드, 초당골드, 최대골드
    public float gold;
    public float time_gold;
    public float max_gold;
    public float gem;

    public GameObject gold_text;
    //public GameObject gold_text2;
    public GameObject stage_text;
    public GameObject stage_text2;
    public GameObject stage_text3;

    public int stage;
    public bool is_stage;
    public bool isOffence;
    public GameObject tutorial;
    public GameObject middletutorial;
    public GameObject bosstutorial;

    TextMeshProUGUI gold_text_mesh;
    //TextMeshProUGUI gold_text2_mesh;
    TextMeshProUGUI stage_text_mesh;
    TextMeshProUGUI stage_text_mesh2;
    TextMeshProUGUI stage_text_mesh3;

    stage1_1 stageset;
    //덱 리스트


    //게임 오브젝트
    //public GameObject draw_normal_rare;
    //GameObject draw_rare_unique;
    //GameObject draw_unique_legend;

    //유닛저장고 부모 오브젝트
    public GameObject list_parent;
    //유닛 오브젝트 저장고
    public List<GameObject> unit_list_all = new List<GameObject>();

    //뽑기 확률
    //public int percentage_normal_rare;

    //리스폰 위치 (오브젝트)
    public GameObject spawn_point;

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환시 없어지지않게
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //씬 이동시 그 씬에도 GameManager가 존재하면, 이전씬에서 쓰던 인스턴스 사용.
            //instance에 인스턴스가 존재한다면 자신을 삭제.
            Destroy(this.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        //스폰포인트 불러오기
        spawn_point = GameObject.FindGameObjectWithTag("SpawnPoint");
        is_stage = false;
        gold = 0;
        time_gold = 1;
        max_gold = 100;

        gold_text = GameObject.FindGameObjectWithTag("gold1");
        gold_text2 = GameObject.FindGameObjectWithTag("gold2");

        gold_text_mesh = gold_text.GetComponent<TextMeshProUGUI>();
        gold_text2_mesh = gold_text2.GetComponent<TextMeshProUGUI>();

        list_parent = GameObject.FindWithTag("ListParent").transform.GetChild(0).gameObject;

        for (int i = 0; i < unit_all_end; i++)
        {
            unit_list_all.Add(list_parent.transform.GetChild(i).gameObject);
        }
        stageset = GameObject.FindGameObjectWithTag("Helper").GetComponent<stage1_1>();
        stage = stageset.stageNum;
        */

        StartStage();
        if (tutorial != null)
        {
            if (stage == 0)
            {

            }
            else
            {
                GameObject.FindGameObjectWithTag("Drawsystem").GetComponent<CardDraw>().Istutorial = false;
                tutorial.GetComponent<VIDE_Assign>().targetManager.SetActive(false);
                tutorial.SetActive(false);
            }
        }
        if (middletutorial != null)
        {
            if (stage == GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>().MiddleBossRound)
            {
                if(GameData.Instance.basic_data.game_progress < GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>().MiddleBossRound)
                {

                }
                else
                {
                    middletutorial.GetComponent<VIDE_Assign>().targetManager.SetActive(false);
                    middletutorial.SetActive(false);
                }
            }
            else
            {
                middletutorial.GetComponent<VIDE_Assign>().targetManager.SetActive(false);
                middletutorial.SetActive(false);
            }
        }
        if (bosstutorial != null)
        {
            if (GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>().BossStage == stage)
            {
                if (GameData.Instance.basic_data.game_progress < GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>().BossStage)
                {

                }
                else
                {
                    bosstutorial.GetComponent<VIDE_Assign>().targetManager.SetActive(false);
                    bosstutorial.SetActive(false);
                }
            }
            else
            {
                bosstutorial.GetComponent<VIDE_Assign>().targetManager.SetActive(false);
                bosstutorial.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_stage == true)
        {
            if (gold <= max_gold)
            {
                //gold += time_gold * Time.deltaTime;
            }
            gold_text_mesh.text = (Mathf.Floor(gold)).ToString();
            //gold_text2_mesh.text = (Mathf.Floor(gem)).ToString();
        }
        else
        {

        }
    }


    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static GameManager Instance
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
    public void SetStage(int num)
    {
        stage = num;
    }

    public void StartStage()
    {
        if (GameObject.FindGameObjectWithTag("Helper") == true)
        {
            stageset = GameObject.FindGameObjectWithTag("Helper").GetComponent<stage1_1>();
            stage = stageset.stageNum;
            isOffence = stageset.isOffence;
        }
        //모든 유닛리스트 최댓값 입력
        unit_all_end = 25;

        list_parent = GameObject.FindWithTag("ListParent").transform.GetChild(0).gameObject;

        if (unit_list_all.Count >= unit_all_end)
        {
            unit_list_all = new List<GameObject>();
        }

        for (int i = 0; i < unit_all_end; i++)
        {
            unit_list_all.Add(list_parent.transform.GetChild(i).gameObject);
        }

        //스폰포인트 불러오기
        spawn_point = GameObject.FindGameObjectWithTag("SpawnPoint");


        is_stage = true;
        gold = 0;
        time_gold = 0.3f;
        max_gold = 100;

        gold_text = GameObject.FindGameObjectWithTag("gold1");
        //gold_text2 = GameObject.FindGameObjectWithTag("gold2");
        stage_text = GameObject.FindGameObjectWithTag("Stage");

        gold_text_mesh = gold_text.GetComponent<TextMeshProUGUI>();
        //gold_text2_mesh = gold_text2.GetComponent<TextMeshProUGUI>();
        stage_text_mesh = stage_text.GetComponent<TextMeshProUGUI>();
        stage_text_mesh2 = stage_text2.GetComponent<TextMeshProUGUI>();
        stage_text_mesh3 = stage_text3.GetComponent<TextMeshProUGUI>();

        if (GameObject.FindGameObjectWithTag("WaveSystem"))
        {
            if (stage == GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>().BossStage)
            {
                stage_text_mesh.text = "Boss";
                stage_text_mesh2.text = "Boss";
                stage_text_mesh3.text = "Boss";
            }
            else
            {
                stage_text_mesh.text = (Mathf.Floor(stage)).ToString();
                stage_text_mesh2.text = (Mathf.Floor(stage)).ToString();
                stage_text_mesh3.text = (Mathf.Floor(stage)).ToString();
            }
        }
        else
        {
            stage_text_mesh.text = (Mathf.Floor(stage)).ToString();
            stage_text_mesh2.text = (Mathf.Floor(stage)).ToString();
            stage_text_mesh3.text = (Mathf.Floor(stage)).ToString();
        }
    }

    public void EndStage()
    {
        is_stage = false;
    }
    public void Goldpp()
    {
        gold += 1000;
    }
}
