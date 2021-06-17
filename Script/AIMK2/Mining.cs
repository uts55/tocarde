using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public GameObject Gem;
    public GameObject blueG;
    public float mineTime;
    bool bluegem;
    OverloadSystem overloadsystem;
    AIMK2 ai;

    // Start is called before the first frame update
    void Start()
    {
        overloadsystem = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<OverloadSystem>();
        overloadsystem.AddMiner(this.gameObject);
        ai = gameObject.GetComponent<AIMK2>();
        Gem.SetActive(false);
        blueG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mine")
        {
            StartCoroutine(GetGem());
        }
        else if (collision.gameObject.tag == "Castle")
        {
            StartCoroutine(GiveGem());
        }
    }

    IEnumerator GetGem()
    {
        ai.ani.Play("Attack");
        yield return new WaitForSeconds(mineTime);
        float rand = Random.Range(0, 100);
        if(rand <= 20)
        {
            bluegem = true;
            blueG.SetActive(true);
        }
        else
        {
            bluegem = false;
        }
        Gem.SetActive(true);
    }
    IEnumerator GiveGem()
    {
        yield return new WaitForSeconds(0.1f);
        Gem.SetActive(false);
        if (bluegem == true)
        {
            bluegem = false;
            blueG.SetActive(false);
            GameManager.Instance.gold += 3;
        }
        else
        {
            GameManager.Instance.gold++;
        }
    }
}
