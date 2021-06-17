using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Coinmove : MonoBehaviour
{
    Transform target;
    Vector3 targetposition;
    public GameObject effect;
    new AudioSource audio;
    float timer;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Coin").GetComponentInChildren<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Coin").GetComponent<Transform>();
        on = true;
        //StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        targetposition = target.position;

        transform.position = Vector3.MoveTowards(transform.position, targetposition, Time.deltaTime * 100);
        timer += Time.deltaTime;
        if(timer > 0.05f)
        {
            StartCoroutine(glow());
            timer = 0;
        }

        if (transform.position.y == targetposition.y)
        {
            if (on == true)
            {
                GameManager.Instance.gold += 1;
                on = false;
                audio.Play();
                Destroy(gameObject);
            }
        }
        
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(1f);
        transform.DOMove(targetposition, 1f)
            .SetEase(Ease.InSine);
    }
    IEnumerator glow()
    {
        Vector3 randomspot = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z);
        GameObject glow = Instantiate(effect, randomspot, Quaternion.identity);
        //glow.transform.SetParent(this.gameObject.transform);
        yield return new WaitForSeconds(0.5f);
        Destroy(glow);
    }
}
