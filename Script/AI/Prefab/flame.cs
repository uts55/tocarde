using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{
    float attack;
    float timer;
    string Tag;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tag)
        {
            StartCoroutine(Fire(collision.gameObject));
        }
    }
    void GetAttack(float a)
    {
        attack = a;
    }
    void GetTag(string t)
    {
        if (t == "Ally")
            Tag = "Enemy";
        else if (t == "Enemy")
            Tag = "Ally";
    }
    IEnumerator Fire(GameObject target)
    {
        Debug.Log(target.name);
        target.SendMessage("Attacked", attack/4);
        yield return new WaitForSeconds(0.25f);
        target.SendMessage("Attacked", attack/4);
        yield return new WaitForSeconds(0.25f);
        target.SendMessage("Attacked", attack/4);
        yield return new WaitForSeconds(0.25f);
        target.SendMessage("Attacked", attack/4);
        yield return new WaitForSeconds(0.25f);
    }
}
