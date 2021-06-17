using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffText : MonoBehaviour
{
    string Bufftype;
    float timer;
    Color alpha;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (Bufftype == "Attack")
        {
            alpha = new Color(1, 0, 0);
        }
        if (Bufftype == "Defence")
        {
            alpha = new Color(0, 0, 1);
        }
        if (Bufftype == "Speed")
        {
            alpha = new Color(1, 1, 0);
        }
        if (Bufftype == "AttackSpeed")
        {
            alpha = new Color(0, 1, 1);
        }
        if (Bufftype == "Heal")
        {
            alpha = new Color(0, 1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * 2);
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            Destroy(gameObject);
        }
        sprite.color = alpha;
    }
    void GetBuffType(string type)
    {
        Bufftype = type;
    }
}
