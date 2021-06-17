using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour
{
    public GameObject bomb;
    public float Bombtime;
    public float runtime;
    public int level;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bye(runtime));
        Physics2D.IgnoreLayerCollision(1, 11);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > Bombtime)
        {
            GameObject boming = Instantiate(bomb, transform.position, Quaternion.identity);
            boming.SendMessage("GetAttack", (300 + (300 * 0.4f * (level - 1)))/10);
            time = 0;
        }
    }
    IEnumerator bye(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    public void Getlevel(int l)
    {
        level = l;
    }
}
