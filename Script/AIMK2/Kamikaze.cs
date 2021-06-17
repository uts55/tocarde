using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public GameObject Boom;
    public float BoomAttack;
    Attack attack;
    Move move;
    AIMK2 ai;
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        move = GetComponent<Move>();
        ai = GetComponent<AIMK2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attack.target != null)
        {
            move.move = false;
            ai.ani.SetBool("Bomb", true);
        }
    }
    public void Bomb()
    {
        GameObject boo = Instantiate(Boom, transform.position, Quaternion.identity);
        boo.SendMessage("GetAttack", BoomAttack);
        Destroy(gameObject);
    }
}
