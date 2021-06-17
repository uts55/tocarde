using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castleattack : MonoBehaviour
{
    float attack;
    float timer;
    public float attacktime;
    string Tag;
    public float distance;
    public bool knockback;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > attacktime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float targetdistance = Vector2.Distance(gameObject.transform.position, collision.transform.position);
        if (targetdistance < distance)
        {
            if (collision.tag == "Enemy")
            {
                StartCoroutine(Magic(collision.gameObject));
            }
            else if(collision.tag == "EnemyCastle")
            {
                collision.gameObject.transform.parent.gameObject.SendMessage("Attacked", attack);
            }
        }
    }
    void GetAttack(float a)
    {
        attack = a;
    }
    IEnumerator Magic(GameObject target)
    {
        if (knockback == true)
        {
            target.SendMessage("knockback");
        }
        target.SendMessage("Attacked", attack);
        yield return new WaitForSeconds(0.25f);
    }
}
