using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_castleAI : MonoBehaviour
{

    public float defence;
    public float health;
    public Slider slider;
    public Slider slider2;
    public GameObject effect;
    public SpriteRenderer body;
    public Sprite lvl1;
    public Sprite lvl2;
    public Sprite lvl3;

    Rigidbody2D rigid;
    public float CastleLevel;
    float maxhealth;
    float DB;
    new CameraDrag camera;

    new AudioSource audio;

    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraDrag>();
        audio = GetComponentInChildren<AudioSource>();
        ani = GetComponent<Animator>();

        rigid = GetComponent<Rigidbody2D>();
        //체력 설정
        maxhealth = health;
        CastleLevel = 1;
        body.sprite = lvl1;
        if(gameObject.tag == "Ally")
        {
            Physics2D.IgnoreLayerCollision(9, 9);
        }
        if(gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(8, 8);
        }
        DB = 1;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health / maxhealth;
        slider2.value = health / maxhealth;
        rigid.velocity = Vector2.up * 0.0000001f;
    }
    void Attacked(float attack)
    {
        audio.Play();
        GameObject eff = Instantiate(effect, new Vector3(transform.position.x + Random.Range(-0.5f, 2f), transform.position.y + Random.Range(-0.5f, 1f), transform.position.z - 3), Quaternion.identity);
        eff.transform.parent = gameObject.transform;
        ani.SetTrigger("Attacked");
        health -= attack / defence * DB;
        if (health <= 0)
        {
            /*if (CastleLevel == 1)
            {
                maxhealth = maxhealth * 2f;
                health = maxhealth;
                body.sprite = lvl2;
                CastleLevel = 2;
                knockbackall();
                Debug.Log("levelup");
            }
            else if (CastleLevel == 2)
            {
                maxhealth = maxhealth * 2f;
                health = maxhealth;
                body.sprite = lvl3;
                CastleLevel = 3;
                knockbackall();
                Debug.Log("level 2up");
            }
            else if (CastleLevel == 3)
            {*/
                Destroy(gameObject);
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
            //}
        }
    }
    void healed(float amount)
    {
    }
    void knockbackall()
    {
        camera.shake = true;
        Collider2D[] obj = Physics2D.OverlapCircleAll(gameObject.transform.position, 100);
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].tag == "Ally")
            {
                obj[i].SendMessage("Bigknockback");
            }
        }
    }
    public void Breaking(float time)
    {
        StartCoroutine(Break(time));
    }
    IEnumerator Break(float time)
    {
        DB = 1 + time;
        yield return new WaitForSeconds(10);
        DB = 1;
    }
}
