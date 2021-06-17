using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyAI1 : MonoBehaviour
{
    public float attack;
    public float defence;
    public float health;
    public float speed;
    public float attackspeed;
    public float range;
    public bool knockback;
    public bool stun;
    public int bullet;
    public ParticleSystem blood;
    public ParticleSystem die;
    int shot;
    float timer;
    float bufftimer;
    float distance;
    bool stop;
    bool move;
    private Vector2 MoveDirection;
    new Rigidbody2D rigidbody;
    GameObject Enemy;
    public GameObject arrow;
    Animator ani;
    public Slider slider;
    float maxhealth;
    GameObject target;
    public GameObject RangeAttack;
    public GameObject flame;
    float Pattack = 1;
    float Pdefence = 1;
    float Pspeed = 1;
    float Pattackspeed = 1;
    float Fattack;
    float Fdefence;
    float Fspeed;
    float Fattackspeed;
    public ParticleSystem buffattack;
    public ParticleSystem buffdefence;
    public ParticleSystem buffspeed;
    public ParticleSystem buffattackspeed;
    SwordSkill swordskill;
    ArrowSkill arrowskill;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(9, 9);
        ani = GetComponentInChildren<Animator>();
        maxhealth = health;
        shot = bullet;
        if ((gameObject.GetComponent<SwordSkill>() as SwordSkill) != null)
        {
            swordskill = gameObject.GetComponent<SwordSkill>();
        }
        if ((gameObject.GetComponent<ArrowSkill>() as ArrowSkill) != null)
        {
            arrowskill = gameObject.GetComponent<ArrowSkill>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fattack = Pattack * attack;
        Fdefence = Pdefence * defence;
        Fspeed = Pspeed * speed;
        Fattackspeed = Pattackspeed * attackspeed;

        slider.value = health / maxhealth;
        if (stop == true)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                stop = false;
                timer = 0;
            }
        }
        else if (stop == false)
        {
            if (target != null)
            {
                distance = Vector2.Distance(gameObject.transform.position, target.transform.position);
                if (distance <= range)
                {
                    move = false;
                    timer += Time.deltaTime;
                    if (bullet != 0)
                    {
                        if (shot > 0)
                        {
                            if (timer > 3f / Fattackspeed)
                            {
                                ani.SetBool("Attack", true);
                                ani.Play("Attack");
                                Attack(target);
                                timer = 0;
                                shot--;
                            }
                        }
                        else if (shot == 0)
                        {
                            timer += Time.deltaTime;
                            if (timer > 20f / Fattackspeed)
                            {
                                shot = bullet;
                            }
                        }
                    }
                    else
                    {
                        if (timer > 3f / Fattackspeed)
                        {
                            ani.SetBool("Attack", true);
                            ani.Play("Attack");
                            Attack(target);
                            timer = 0;
                        }
                    }
                    ani.SetBool("Attack", false);
                }
                else
                {
                    target = null;
                }
            }
            if (target == null)
            {
                move = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        distance = Vector2.Distance(gameObject.transform.position, collision.transform.position);

        if (collision.tag == "Enemy")
        {
            if (distance < range)
            {
                target = collision.gameObject;
            }
        }
    }
    private void FixedUpdate()
    {
        if (move == true)
        {
            MoveDirection = new Vector2(1, 0);
            ani.SetBool("Run", true);
        }
        if (move == false)
        {
            MoveDirection = new Vector2(0, 0.000001f);
            ani.SetBool("Run", false);
        }

        rigidbody.velocity = MoveDirection * Fspeed;
    }
    void Attacked(float attack)
    {
        health -= attack / Fdefence;
        blood.Play(blood);
        if (health <= 0)
        {
            Instantiate(die,transform.position,Quaternion.identity);
            ani.SetBool("Die", true);
            ani.Play("Die");
            Destroy(gameObject);
        }
    }
    void Attack(GameObject target)
    {

        if (arrow)
        {
            if(arrowskill)
                arrowskill.count++;
            GameObject shoot = Instantiate(arrow, transform.position, Quaternion.identity);
            shoot.SendMessage("GetTarget", target.gameObject);
            shoot.SendMessage("GetAttack", Fattack);
        }
        else if(RangeAttack)
        {
            GameObject shoot = Instantiate(RangeAttack, target.transform.position, Quaternion.identity);
            shoot.SendMessage("GetTarget", target.gameObject);
            shoot.SendMessage("GetAttack", Fattack);
            shoot.SendMessage("GetTag", tag);
        }
        else if (flame)
        {
            GameObject shoot = Instantiate(flame, transform.position,Quaternion.Euler(0,0,-90));
            shoot.SendMessage("GetTarget", target.gameObject);
            shoot.SendMessage("GetAttack", Fattack);
            shoot.SendMessage("GetTag", tag);
        }
        else
        {
            if(swordskill)
                swordskill.count++;
            target.SendMessage("Attacked", Fattack);
            if(knockback == true)
            {
                target.SendMessage("Knockback", true);
            }
            if(stun == true)
            {
                Debug.Log("stun!");
                target.SendMessage("Stunned", true);
            }
        }
    }
    void Knockback(bool knock)
    {
        if (knock == true)
        {
            this.transform.position = new Vector3(this.transform.position.x - 1f, this.transform.position.y);
        }
    }
    void Stunned(bool stunn)
    {
        stop = true;
    }
    void Healed(float amount)
    {
        if (health < maxhealth)
            health += amount;
    }
    void BuffAttack(float amount)
    {
        Pattack = (amount / 10) + 1;
        bufftimer += Time.deltaTime;
        buffattack.Play(buffattack);
        if(bufftimer > 1f)
        {
            Pattack = 1;
            bufftimer = 0;
        }
    }
    void BuffDefence(float amount)
    {
        Pdefence = (amount / 10) + 1;
        bufftimer += Time.deltaTime;
        buffdefence.Play(buffdefence);
        if (bufftimer > 1f)
        {
            Pdefence = 1;
            bufftimer = 0;
        }
    }
    void BuffSpeed(float amount)
    {
        Pspeed = (amount / 10) + 1;
        bufftimer += Time.deltaTime;
        buffspeed.Play(buffspeed);
        if (bufftimer > 1f)
        {
            Pspeed = 1;
            bufftimer = 0;
        }
    }
    void BuffAttackSpeed(float amount)
    {
        Pattackspeed = (amount / 10) + 1;
        bufftimer += Time.deltaTime;
        buffattackspeed.Play(buffattackspeed);
        if (bufftimer > 1f)
        {
            Pattackspeed = 1;
            bufftimer = 0;
        }
    }
}
