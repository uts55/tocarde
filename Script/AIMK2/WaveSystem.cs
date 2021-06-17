using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class Wave
{
    public List<GameObject> Unit = new List<GameObject>();
    public List<float> UnitCount = new List<float>();
}
public class WaveSystem : MonoBehaviour
{
    public Slider waveSlider;
    public Image thiswaveImage;
    public Image nextwaveImage;
    public Sprite Normalwave;
    //public Sprite Middlewave;
    public Sprite Bosswave;
    public TextMeshProUGUI thiswaveMesh;
    public TextMeshProUGUI NextwaveMesh;
    //public TextMeshProUGUI waveMesh;
    public string file;
    public int MiddleBossRound;
    public int MiddleBossWave;
    public int thisWave;
    public Transform EnemyPortal;
    public GameObject OnDefence;
    public GameObject OnDefence2;
    public GameObject OnOffence;
    public GameObject OnOffence2;
    public int BossStage;

    public GameObject skipon;
    public GameObject skippanel;
    internal bool skip;
    internal float waveTime;

    internal bool bossOn;
    internal bool middleOn;
    float time;
    internal bool WaveFinish;
    GameManager gamemanager;

    public List<GameObject> EnemyList = new List<GameObject>();
    public List<Wave> waves = new List<Wave>();

    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<GameManager>();
        if (gamemanager.isOffence == true)
        {
            OnDefence.SetActive(false);
            OnDefence2.SetActive(false);
            OnOffence.SetActive(true);
            OnOffence2.SetActive(true);
            Read(file);
        }
        else
        {
            OnDefence.SetActive(true);
            OnDefence2.SetActive(true);
            OnOffence.SetActive(false);
            OnOffence2.SetActive(false);
            Read(file);
        }
        if (gamemanager.isOffence == false)
        {
            thisWave = 1;
            waveTime = 20;
            WaveFinish = false;
            waveSlider.maxValue = waveTime;
            time = 0;
            bossOn = false;
            middleOn = false;
        }
        else
        {
            thisWave = 1;
            waveTime = 20;
            WaveFinish = false;
            bossOn = false;
            middleOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.isOffence == false)
        {
            if (thisWave % waves.Count == waves.Count - 1)
            {
                //thiswaveImage.sprite = Normalwave;
                nextwaveImage.sprite = Bosswave;
            }
            else if (thisWave % waves.Count == 0)
            {
                //thiswaveImage.sprite = Bosswave;
                nextwaveImage.sprite = Normalwave;
            }else
            {
                //thiswaveImage.sprite = Normalwave;
                nextwaveImage.sprite = Normalwave;
            }
            /*else if (thisWave % middlebossTime == 0)
            {
                thiswaveImage.sprite = Middlewave;
                nextwaveImage.sprite = Normalwave;
            }
            else if (thisWave % middlebossTime == middlebossTime - 1)
            {
                thiswaveImage.sprite = Normalwave;
                nextwaveImage.sprite = Middlewave;
            }*/
            
            //waveMesh.text = thisWave + " " + "웨이브";
            time += Time.deltaTime;
            waveSlider.value = time;
            thiswaveMesh.text = thisWave + "";
            if (thisWave + 1 > waves.Count)
            {
                NextwaveMesh.text = "" + waves.Count;
            }
            else
            {
                NextwaveMesh.text = "" + (thisWave + 1);
            }

            if (WaveFinish == false)
            {
                for (int i = 0; i < waves[thisWave - 1].Unit.Count; i++)
                {
                    StartCoroutine(WaveStart(waves[thisWave - 1].Unit[i], waves[thisWave - 1].UnitCount[i]));
                }
                StartCoroutine(NextWave());
            }
        }
        else
        {
            if(thisWave == 19)
            {
                nextwaveImage.sprite = Bosswave;
            }
            if(thisWave >= 20)
            {
                thiswaveImage.sprite = Bosswave;
                nextwaveImage.sprite = Bosswave;
            }
            if (WaveFinish == false)
            {
                for (int i = 0; i < waves[thisWave - 1].Unit.Count; i++)
                {
                    StartCoroutine(WaveStart(waves[thisWave - 1].Unit[i], waves[thisWave - 1].UnitCount[i]));
                }
                StartCoroutine(NextWave());
            }
        }
    }
    public void Read(string file)
    {
        TextAsset csv = (TextAsset)Resources.Load("Stage/" + file + gamemanager.stage) as TextAsset;
        string All = csv.text;
        string[] Line = All.Split('\n');
        for (int i = 0; i < Line.Length; i++)
        {
            var data = Line[i].Split(',');
            for (int j = 0; j < data.Length / 2; j++)
            {
                if (data[j * 2] != "0")
                    waves[i].Unit.Add(EnemyList[int.Parse(data[j * 2]) - 1]);
                if (data[j * 2 + 1] != "0")
                    waves[i].UnitCount.Add(int.Parse(data[j * 2 + 1]));
            }
        }
        //StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/" + file + gamemanager.stage + ".csv");
        /*int lineofFile = 0;
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            
            var data_values = data_String.Split(',');
            for (int i = 0; i < data_values.Length / 2; i++)
            {
                if (data_values[i * 2] != "0")
                    waves[lineofFile].Unit.Add(EnemyList[int.Parse(data_values[i * 2]) - 1]);
                if (data_values[i * 2 + 1] != "0")
                    waves[lineofFile].UnitCount.Add(int.Parse(data_values[i * 2 + 1]));
            }
            lineofFile++;
        }*/
    }

    IEnumerator WaveStart(GameObject waveUnit,float waveCount)
    {
        for (int i = 0; i < waveCount; i++)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 5));
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(EnemyPortal.position.x, EnemyPortal.position.y + random, random * 100);
            Instantiate(waveUnit, randomspot, Quaternion.identity);
        }
    }
    IEnumerator NextWave()
    {
        WaveFinish = true;
        yield return new WaitForSeconds(waveTime);
        thisWave++;
        waveTime += 4;
        WaveFinish = false;
        gamemanager.gold += thisWave;
        waveSlider.maxValue = waveTime;
        time = 0;

        if (thisWave == 6 && BossStage == gamemanager.stage)
        {
            bossOn = true;
        }
        if(gamemanager.stage == MiddleBossRound && thisWave == MiddleBossWave)
        {
            middleOn = true;
        }
        if (thisWave > waves.Count)
        {
            if (gamemanager.isOffence == true)
            {
                thisWave = waves.Count;
            }
            else
            {
                GameObject.Find("Background_Canvas").transform.Find("Victory").gameObject.SetActive(true);
                AudioSource[] audio = GameObject.Find("GameBGMHelper").GetComponentsInChildren<AudioSource>();
                for (int i = 0; i < audio.Length; i++)
                {
                    audio[i].Stop();
                }
                if (GameData.Instance.basic_data.game_progress <= GameManager.Instance.stage)
                {
                    GameData.Instance.basic_data.game_progress = GameManager.Instance.stage;
                    if (GameManager.Instance.stage == 0)
                    {
                        GameData.Instance.basic_data.game_progress = 1;
                    }
                    GameData.Instance.SaveData();
                }
                Time.timeScale = 0;
            }
        }
        /*else
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Minion");
            foreach (GameObject One in obj)
            {
                GameObject objectMain = One.transform.parent.gameObject;
                Animator ani = objectMain.GetComponent<Animator>();
                ani.SetBool("Die", true);
            }
        }*/
    }
    public void Skip()
    {
        if (gamemanager.gold >= thisWave * 10)
        {
            if (skipon.activeSelf == true)
            {
                skip = true;
            }
            if (skip == true)
            {
                gamemanager.gold -= thisWave * 10;
                StopAllCoroutines();
                thisWave++;
                waveTime += 4;
                WaveFinish = false;
                waveSlider.maxValue = waveTime;
                time = 0;

                if (thisWave == 6 && BossStage == gamemanager.stage)
                {
                    bossOn = true;
                }
                if (gamemanager.stage == MiddleBossRound && thisWave == MiddleBossWave)
                {
                    middleOn = true;
                }
                if (thisWave > waves.Count)
                {
                    if (gamemanager.isOffence == true)
                    {
                        thisWave = waves.Count;
                    }
                    else
                    {
                        GameObject.Find("Background_Canvas").transform.Find("Victory").gameObject.SetActive(true);
                        AudioSource[] audio = GameObject.Find("GameBGMHelper").GetComponentsInChildren<AudioSource>();
                        for (int i = 0; i < audio.Length; i++)
                        {
                            audio[i].Stop();
                        }
                        if (GameData.Instance.basic_data.game_progress <= GameManager.Instance.stage)
                        {
                            GameData.Instance.basic_data.game_progress = GameManager.Instance.stage;
                            if (GameManager.Instance.stage == 0)
                            {
                                GameData.Instance.basic_data.game_progress = 1;
                            }
                            GameData.Instance.SaveData();
                        }
                        Time.timeScale = 0;
                    }
                }

            }
            else if (skippanel.activeSelf == true)
            {
                gamemanager.gold -= thisWave * 10;
                StopAllCoroutines();
                thisWave++;
                waveTime += 4;
                WaveFinish = false;
                waveSlider.maxValue = waveTime;
                time = 0;

                if (thisWave == 6 && BossStage == gamemanager.stage)
                {
                    bossOn = true;
                }
                if (gamemanager.stage == MiddleBossRound && thisWave == MiddleBossWave)
                {
                    middleOn = true;
                }
                if (thisWave > waves.Count)
                {
                    if (gamemanager.isOffence == true)
                    {
                        thisWave = waves.Count;
                    }
                    else
                    {
                        GameObject.Find("Background_Canvas").transform.Find("Victory").gameObject.SetActive(true);
                        AudioSource[] audio = GameObject.Find("GameBGMHelper").GetComponentsInChildren<AudioSource>();
                        for (int i = 0; i < audio.Length; i++)
                        {
                            audio[i].Stop();
                        }
                        if (GameData.Instance.basic_data.game_progress <= GameManager.Instance.stage)
                        {
                            GameData.Instance.basic_data.game_progress = GameManager.Instance.stage;
                            if (GameManager.Instance.stage == 0)
                            {
                                GameData.Instance.basic_data.game_progress = 1;
                            }
                            GameData.Instance.SaveData();
                        }
                        Time.timeScale = 0;
                    }
                }
            }
            else
            {
                skippanel.SetActive(true);
            }
        }
    }
}
