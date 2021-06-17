using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicField : MonoBehaviour
{
    public float distance;
    public float time = 7;
    float timer;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > time)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        float targetdistance = Vector2.Distance(gameObject.transform.position, collision.transform.position);
        if (targetdistance < distance)
        {
            if (collision.tag == "Enemy")
            {
                if (collision.gameObject.GetComponent<Toxic>() == null)
                {
                    collision.gameObject.AddComponent<Toxic>();
                    collision.gameObject.SendMessage("Toxiclevel", level);
                }
            }
        }
    }
    public void Getlevel(int amount)
    {
        level = amount;
    }
}
