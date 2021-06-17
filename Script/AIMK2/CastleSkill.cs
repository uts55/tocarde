using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleSkill : MonoBehaviour
{
    public float attack;

    public GameObject castleskill;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Bomb()
    {
        GameObject bomb = Instantiate(castleskill, new Vector3(transform.position.x +2,transform.position.y +1,transform.position.z), Quaternion.identity);
        bomb.SendMessage("GetAttack",attack);
    }
}
