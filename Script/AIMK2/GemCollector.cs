using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollector : MonoBehaviour
{
    public float GemTime;
    public GameObject text;
    Animator ani;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > GemTime)
        {
            GameManager.Instance.gem++;
            ani.SetTrigger("Get");
            float random = Random.Range(-0.5f, 0.5f);
            GameObject Gemtext = Instantiate(text, new Vector3(transform.position.x + random, transform.position.y + 1f + random / 2, transform.position.z - 3), Quaternion.identity);
            Gemtext.SendMessage("GetDamage", 1);
            Gemtext.transform.parent = gameObject.transform;
            timer = 0;
        }
    }
}
