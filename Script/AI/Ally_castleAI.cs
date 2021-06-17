using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ally_castleAI : MonoBehaviour
{
    public float defence;
    public float health;
    public Slider slider;
    public GameObject effect;
    public GameObject goldtext;
    int thisglod = 0;
    Rigidbody2D rigid;
    float maxhealth;
    Animator ani;
    new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponentInChildren<AudioSource>();
        ani = GetComponent<Animator>();

        rigid = GetComponent<Rigidbody2D>();
        //체력 설정
        maxhealth = health;

        if (gameObject.tag == "Ally")
        {
            Physics2D.IgnoreLayerCollision(9, 9);
        }
        if (gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(8, 8);
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health / maxhealth;
        rigid.velocity = Vector2.up * 0.0000001f;
        if(thisglod != (int)GameManager.Instance.gold)
        {
            float random = Random.Range(-0.5f, 0.5f);
            GameObject Goldtext = Instantiate(goldtext, new Vector3(transform.position.x + random, transform.position.y + 1f + random / 2, transform.position.z - 3), Quaternion.identity);
            Goldtext.transform.parent = gameObject.transform;
            Goldtext.SendMessage("GetDamage", (int)GameManager.Instance.gold - thisglod);
            if((int)GameManager.Instance.gold - thisglod > 10)
            {
                goldtext.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            }
            else if((int)GameManager.Instance.gold - thisglod > 20)
            {
                goldtext.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            else if ((int)GameManager.Instance.gold - thisglod > 30)
            {
                goldtext.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else
            {
                goldtext.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            thisglod = (int)GameManager.Instance.gold;
        }
    }
    void Attacked(float attack)
    {
        health -= attack / defence;
        ani.SetTrigger("Attacked");
        GameObject eff = Instantiate(effect, new Vector3(transform.position.x + Random.Range(-2f, 0.5f), transform.position.y + Random.Range(-0.5f, 1f), transform.position.z - 3), Quaternion.identity);
        eff.transform.parent = gameObject.transform;
        audio.Play();
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Background_Canvas").transform.Find("Defeat").gameObject.SetActive(true);
            AudioSource[] audio = GameObject.Find("GameBGMHelper").GetComponentsInChildren<AudioSource>();
            for (int i = 0; i < audio.Length; i++)
            {
                audio[i].Stop();
            }
            Time.timeScale = 0;
        }
    }
    void Fixed(float amount)
    {
        if (health < maxhealth)
        {
            health += amount;
        }
        if(health > maxhealth)
        {
            health = maxhealth;
        }
    }
}
