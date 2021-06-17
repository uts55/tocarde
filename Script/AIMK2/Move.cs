using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    internal float speed;
    internal bool move;
    public float knockbackspeed;
    public GameObject gem;
    float maxknockback;
    AIMK2 ai;

    new Rigidbody2D rigidbody;
    Vector2 moveDirection;
    internal bool knockback;
    internal bool Bigknock;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<AIMK2>();
        rigidbody = GetComponent<Rigidbody2D>();
        maxknockback = knockbackspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody != null)
        {
            if (move == true)
            {
                if (gameObject.layer == 9)
                    moveDirection = new Vector2(1, 0);
                else if (gameObject.layer == 8)
                    moveDirection = new Vector2(-1, 0);
                else if (gameObject.layer == 10)
                {
                    if (gem.activeSelf == true)
                    {
                        moveDirection = new Vector2(1, 0);
                        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (gem.activeSelf == false)
                    {
                        moveDirection = new Vector2(-1, 0);
                        gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                    }
                }
            }
            else if (move == false)
            {
                moveDirection = new Vector2(0, 0);
            }
            if (ai.die == false)
            {
                rigidbody.velocity = moveDirection * speed;
            }
            if (knockback == true)
            {
                if (ai.ani.speed > 0)
                {
                    if (knockbackspeed > 0)
                        knockbackspeed -= 0.01f * knockbackspeed * 3;
                    if (gameObject.layer == 9)
                        moveDirection = new Vector2(-1, 0);
                    else if (gameObject.layer == 8)
                        moveDirection = new Vector2(1, 0);
                    rigidbody.velocity = moveDirection * knockbackspeed;
                }
            }
            else
            {
                knockbackspeed = maxknockback;
            }
            if (Bigknock == true)
            {
                if (knockbackspeed > 0)
                    knockbackspeed -= 0.01f * knockbackspeed * 3;
                if (gameObject.layer == 9)
                    moveDirection = new Vector2(-1, 0);
                else if (gameObject.layer == 8)
                    moveDirection = new Vector2(1, 0);
                rigidbody.velocity = moveDirection * knockbackspeed * 3;
            }
            else
            {
                knockbackspeed = maxknockback;
            }
        }
    }
}
