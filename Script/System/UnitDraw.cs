using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDraw : MonoBehaviour
{
    //노말 뽑기 결과값
    public List<int> normal_draw_num;
    //레어 뽑기
    public List<int> rare_draw_num;
    //유니크
    public List<int> unique_draw_num;
    //레전드
    public List<int> legend_draw_num;

    public int deck_index;

    public Image warning;

    public AudioSource failsound;
    public AudioSource prizesound;
    public GameObject puff;
    private void Awake()
    {
        GameManager.Instance.StartStage();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameData.Instance.deck_size; i++)
        {

            normal_draw_num.Add(GameData.Instance.unit_deck_list.list[i].unit_num);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NormalDraw()
    {
        if (GameManager.Instance.gold >= 1)
        {
            
            deck_index = Random.Range(0, 4);
            int index_n = normal_draw_num[deck_index];
            Debug.Log(index_n);
            if(index_n == 0)
            {
                failsound.Play();
                Instantiate(puff, GameManager.Instance.spawn_point.transform.position, Quaternion.identity);
            }
            else
            {
                prizesound.Play();
            }
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
            Instantiate(GameManager.Instance.unit_list_all[index_n], randomspot, Quaternion.identity);
            GameManager.Instance.gold -= 1;
        }
        else
        {
            StartCoroutine(ShowWarn());
        }
    }

    public void RareDraw()
    {
        if (GameManager.Instance.gold >= 3)
        {
            
            deck_index = Random.Range(0, 4);
            int index_r = rare_draw_num[deck_index];
            Debug.Log(index_r);
            if (index_r == 0)
            {
                failsound.Play();
                Instantiate(puff, GameManager.Instance.spawn_point.transform.position, Quaternion.identity);
            }
            else
            {
                prizesound.Play();
            }
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
            Instantiate(GameManager.Instance.unit_list_all[index_r], randomspot, Quaternion.identity);
            GameManager.Instance.gold -= 3;
        }
        else
        {
            StartCoroutine(ShowWarn());
        }
    }

    public void UniqueDraw()
    {
        if (GameManager.Instance.gold >= 5)
        {
            deck_index = Random.Range(0, 4);
            int index_u = unique_draw_num[deck_index];
            Debug.Log(index_u);
            if (index_u == 0)
            {
                failsound.Play();
                Instantiate(puff, GameManager.Instance.spawn_point.transform.position, Quaternion.identity);
            }
            else
            {
                prizesound.Play();
            }
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
            Instantiate(GameManager.Instance.unit_list_all[index_u], randomspot, Quaternion.identity);
            GameManager.Instance.gold -= 5;
        }
        else
        {
            StartCoroutine(ShowWarn());
        }
    }

    public void LegendDraw()
    {
        if (GameManager.Instance.gold >= 7)
        {
            deck_index = Random.Range(0, 4);
            int index_l = legend_draw_num[deck_index];
            Debug.Log(index_l);
            if (index_l == 0)
            {
                failsound.Play();
                Instantiate(puff, GameManager.Instance.spawn_point.transform.position, Quaternion.identity);
            }
            else
            {
                prizesound.Play();
            }
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
            Instantiate(GameManager.Instance.unit_list_all[index_l], randomspot, Quaternion.identity);
            GameManager.Instance.gold -= 7;
        }
        else
        {
            StartCoroutine(ShowWarn());
        }
    }

    public void DrawAllUnitCheap()
    {
        if (GameManager.Instance.gold >= 2)
        {
            int percent = Random.Range(0, 100);
            if (percent < 50)
            {
                //꽝유닛
                failsound.Play();
                Instantiate(puff, GameManager.Instance.spawn_point.transform.position, Quaternion.identity);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[0], randomspot, Quaternion.identity);
            }
            else if (percent < 70)
            {
                int index_n;

                //노말

                deck_index = Random.Range(0, 4);
                index_n = normal_draw_num[deck_index];
                if (index_n == 0)
                {
                    DrawAllUnitCheap();
                    return;
                }

                prizesound.Play();
                Debug.Log(index_n);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[index_n], randomspot, Quaternion.identity);
            }
            else if (percent < 85)
            {
                int index_r;
                //레어

                deck_index = Random.Range(0, 4);
                index_r = rare_draw_num[deck_index];
                if (index_r == 0)
                {
                    DrawAllUnitCheap();
                    return;
                }

                prizesound.Play();
                Debug.Log(index_r);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[index_r], randomspot, Quaternion.identity);
            }
            else if (percent < 96)
            {
                int index_u;
                //유니크

                deck_index = Random.Range(0, 4);
                index_u = unique_draw_num[deck_index];
                if (index_u == 0)
                {
                    DrawAllUnitCheap();
                    return;
                }

                prizesound.Play();
                Debug.Log(index_u);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[index_u], randomspot, Quaternion.identity);
            }
            else if (percent < 100)
            {
                int index_l;
                //레전드

                deck_index = Random.Range(0, 4);
                index_l = legend_draw_num[deck_index];
                if (index_l == 0)
                {
                    DrawAllUnitCheap();
                    return;
                }

                prizesound.Play();
                Debug.Log(index_l);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[index_l], randomspot, Quaternion.identity);
            }

            GameManager.Instance.gold -= 2;
        }
        else
        {
            StartCoroutine(ShowWarn());
        }
    }

    public void DrawAllUnitExpensive()
    {
        if (GameManager.Instance.gold >= 6)
        {
            int percent = Random.Range(0, 100);
            if (percent < 10)
            {
                //꽝유닛
                failsound.Play();
                Instantiate(puff, GameManager.Instance.spawn_point.transform.position, Quaternion.identity);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[0], randomspot, Quaternion.identity);
            }
            else if (percent < 40)
            {
                int index_n;

                deck_index = Random.Range(0, 4);
                index_n = normal_draw_num[deck_index];
                if (index_n == 0)
                {
                    DrawAllUnitExpensive();
                    return;
                }

                prizesound.Play();
                Debug.Log(index_n);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[index_n], randomspot, Quaternion.identity);
            }
            else if (percent < 70)
            {
                int index_r;
                //레어

                deck_index = Random.Range(0, 4);
                index_r = rare_draw_num[deck_index];
                if (index_r == 0)
                {
                    DrawAllUnitExpensive();
                    return;
                }

                prizesound.Play();
                Debug.Log(index_r);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[index_r], randomspot, Quaternion.identity);
            }
            else if (percent < 90)
            {
                int index_u;
                //유니크

                deck_index = Random.Range(0, 4);
                index_u = unique_draw_num[deck_index];
                if (index_u == 0)
                {
                    DrawAllUnitExpensive();
                    return;
                }

                prizesound.Play();
                Debug.Log(index_u);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[index_u], randomspot, Quaternion.identity);
            }
            else if (percent < 100)
            {
                int index_l;
                //레전드
                deck_index = Random.Range(0, 4);
                index_l = legend_draw_num[deck_index];
                if (index_l == 0)
                {
                    DrawAllUnitExpensive();
                    return;
                }

                prizesound.Play();
                Debug.Log(index_l);
                float random = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 randomspot = new Vector3(GameManager.Instance.spawn_point.transform.position.x, GameManager.Instance.spawn_point.transform.position.y + random, random * 10);
                Instantiate(GameManager.Instance.unit_list_all[index_l], randomspot, Quaternion.identity);
            }

            GameManager.Instance.gold -= 6;
        }
        else
        {
            StartCoroutine(ShowWarn());
        }
    }

    public void ShowMeTheMoney()
    {
        GameManager.Instance.gold += 10000;
    }
    IEnumerator ShowWarn()
    {
        warning.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        warning.gameObject.SetActive(false);
    }
}
