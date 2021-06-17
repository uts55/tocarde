using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    public WaveSystem wavesystem;
    public GameObject minion;
    public float spawntime;
    public int minionlevel;
    public int cardlevel;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        minionlevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (wavesystem.OnDefence.activeSelf == true)
        {
            if (wavesystem.WaveFinish == false)
            {
                StopAllCoroutines();
                StartCoroutine(minionStart());
            }
        }
        else
        {*/
            timer += Time.deltaTime;
        if (timer > spawntime)
        {
            timer = 0;
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 100);
            GameObject mini = Instantiate(minion, randomspot, Quaternion.identity);
            Stat stat = mini.GetComponent<Stat>();
            if (minionlevel > 1)
            {
                stat.attack *= 1.1f + (cardlevel - 1) * 0.05f;
                stat.health *= 1.1f + (cardlevel - 1) * 0.05f;
            }
        }
        //}
        /*
        timer += Time.deltaTime;
        if(timer > spawntime)
        {
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
            Instantiate(minion, randomspot, Quaternion.identity);
            timer = 0;
        }*/
    }
    /*IEnumerator minionStart()
    {
        for (int i = 0; i < spawntime; i++)
        {
            yield return new WaitForSeconds(spawntime - UnityEngine.Random.Range(0f, 1));
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
            GameObject mini = Instantiate(minion, randomspot, Quaternion.identity);
            Stat stat = mini.GetComponent<Stat>();
            stat.attack *= minionlevel;
            stat.health *= minionlevel;
        }
    }*/
}
