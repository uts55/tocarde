using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCall : MonoBehaviour
{
    public WaveSystem wavesystem;
    public GameObject boss;
    public float BossTime;
    public Image warning;
    public AudioSource bossAudio;
    public AudioSource normalAudio;
    public Transform EnemyPortal;
    int middleCount;
    bool a = false;
    public GameObject middleboss;
    Animator ani;
    public GameObject bossslider;
    public Slider bosslider;
    GameObject bos;
    Stat bosstat;
    bool Isbossspawn;
    // Start is called before the first frame update
    void Start()
    {
        ani = warning.GetComponent<Animator>();

        normalAudio.Play();
        middleCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wavesystem.bossOn == true)
        {
            StartCoroutine(bosscall());
            wavesystem.bossOn = false;
        }
        if (wavesystem.middleOn == true)
        {
            StartCoroutine(middlecall());
            wavesystem.middleOn = false;
        }
        if (bos != null)
        {
            bossslider.gameObject.SetActive(true);
            bosslider.value = bos.GetComponent<Stat>().health / bos.GetComponent<Stat>().maxHealth;
            if (bosstat.health <= 0)
            {
                warning.gameObject.SetActive(false);
                bossAudio.Stop();
                normalAudio.Play();
            }
            Isbossspawn = true;
        }
        else
        {
            bossslider.gameObject.SetActive(false);
            if (Isbossspawn == true)
            {
                GameObject.Find("Background_Canvas").transform.Find("Victory").gameObject.SetActive(true);
                AudioSource[] audio = GameObject.Find("GameBGMHelper").GetComponentsInChildren<AudioSource>();
                for (int i = 0; i < audio.Length; i++)
                {
                    audio[i].Stop();
                }
                if(GameData.Instance.basic_data.game_progress <= GameManager.Instance.stage)
                {
                    GameData.Instance.basic_data.game_progress = GameManager.Instance.stage;
                }
                Time.timeScale = 0;
                if(a == false)
                {
                    if (GameObject.FindGameObjectWithTag("BossTutorialManager"))
                    {
                        GameObject.FindGameObjectWithTag("BossTutorialManager").GetComponent<ActiveManager>().Interact();
                    }
                    a = true;
                }
            }
        }

    }
    IEnumerator bosscall()
    {
        yield return new WaitForSeconds(BossTime-2);
        warning.gameObject.SetActive(true);
        bossAudio.Play();
        normalAudio.Pause();
        yield return new WaitForSeconds(2f);
        ani.SetBool("Next",true);
        float random = UnityEngine.Random.Range(-0.3f, 0.3f);
        Vector3 randomspot = new Vector3(EnemyPortal.position.x, EnemyPortal.position.y + random, random * 100);
        bos = Instantiate(boss, randomspot, Quaternion.identity);
        bosstat = bos.GetComponent<Stat>();
        Collider2D[] obj = Physics2D.OverlapCircleAll(gameObject.transform.position, 100);
        for (int i = 0; i < obj.Length; i++)
        {
            if(obj[i].tag == "Ally")
            {
                obj[i].SendMessage("knockback");
            }
        }
        if (GameObject.FindGameObjectWithTag("BossTutorialManager"))
        {
            GameObject.FindGameObjectWithTag("BossTutorialManager").GetComponent<ActiveManager>().Interact();
        }
    }
    IEnumerator middlecall()
    {
        yield return new WaitForSeconds(Random.Range(1f, 20f));
        float random = UnityEngine.Random.Range(-0.3f, 0.3f);
        Vector3 randomspot = new Vector3(EnemyPortal.position.x, EnemyPortal.position.y + random, random * 100);
        Instantiate(middleboss, randomspot, Quaternion.identity);
    }
}
