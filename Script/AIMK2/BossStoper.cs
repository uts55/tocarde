using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStoper : MonoBehaviour
{
    AIMK2 ai;
    float timer;
    public float stopstart;
    public float stoptime;
    public GameObject Tic;
    public GameObject sprite;
    bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        ai = gameObject.transform.parent.GetComponent<AIMK2>();
        timer = 0;
        sprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > stopstart)
        {
            if (a == false)
            {
                StartCoroutine(Stop());
                a = true;
            }
            Tic.transform.Rotate(0, 0,-360 / stoptime * Time.deltaTime);
        }
    }
    IEnumerator Stop()
    {
        ai.Stop();
        sprite.SetActive(true);
        if (GameObject.FindGameObjectWithTag("BossTutorialManager"))
        {
            GameObject.FindGameObjectWithTag("BossTutorialManager").GetComponent<ActiveManager>().Interact();
        }
        yield return new WaitForSeconds(stoptime);
        ai.StopFinish();
        this.gameObject.SetActive(false);
    }
}
