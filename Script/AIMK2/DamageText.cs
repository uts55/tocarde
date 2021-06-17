using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    float damage;
    TextMeshPro text;
    float timer;
    Color alpha;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();        
        text.text = damage.ToString();
        alpha = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * 2);
        timer += Time.deltaTime;
        if(timer > 1f)
        {
            Destroy(gameObject);
        }
        text.color = alpha;
    }
    void GetDamage(float amount)
    {
        damage = amount;
    }
}
