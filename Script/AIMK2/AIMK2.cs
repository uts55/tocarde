using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIMK2 : MonoBehaviour
{
    internal Stat stat;
    internal Attack attack;
    internal Move move;
    internal HealAlone heal;
    internal Animator ani;
    internal MirrorAttack mirror;
    public GameObject coin;
    bool stop;
    SoundSystem soundsystem;
    AudioSource[] sound;
    OverloadSystem overloadsystem;
    public int overload;

    public bool isStun;
    internal bool die;
    // Start is called before the first frame update
    void Start()
    {
        if (overload > 0)
        {
            overloadsystem = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<OverloadSystem>();
            overloadsystem.overloadstack += overload;
        }
        sound = GetComponentsInChildren<AudioSource>();
        if (GameObject.FindGameObjectWithTag("SoundSystem"))
        {
            soundsystem = GameObject.FindGameObjectWithTag("SoundSystem").GetComponent<SoundSystem>();
        }
        ani = GetComponentInChildren<Animator>();
        stat = gameObject.GetComponent<Stat>();
        stat.enabled = true;
        if (gameObject.GetComponent<Move>() != null)
        {
            move = gameObject.GetComponent<Move>();
        }
        if (gameObject.GetComponent<Attack>() != null)
        {
            attack = gameObject.GetComponent<Attack>();
        }
        if (gameObject.GetComponent<HealAlone>() != null)
        {
            heal = gameObject.GetComponent<HealAlone>();
        }
        if (gameObject.GetComponent<MirrorAttack>() != null)
        {
            mirror = gameObject.GetComponent<MirrorAttack>();
        }
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetFloat("AttackSpeed", stat.attackspeed);
        ani.SetFloat("Speed", stat.speed);
        if (GameObject.FindGameObjectWithTag("SoundSystem"))
        {
            for (int i = 0; i < sound.Length; i++)
            {
                sound[i].volume = soundsystem.EffectsoundValue;
            }
        }
        if (attack != null)
        {
            attack.attack = stat.attack;
            attack.attackspeed = stat.attackspeed;
            attack.range = stat.range;
            attack.critical = stat.critical;
        }
        if (move != null)
        {
            move.speed = stat.speed;
        }
        if(mirror != null)
        {
            move.knockback = false;
        }
        if (stat.health <= 0)
        {
            die = true;
        }
        if (attack != null)
        {
            if (isStun == false)
            {
                if (attack.target != null)
                {
                    if (move != null)
                    {
                        move.move = false;
                    }
                    if (attack.attackable == true)
                    {
                        if (attack.realbullet != 0)
                        {
                            if (attack.bullet <= 0)
                            {
                                StartCoroutine(Reload());
                            }
                            else
                            {
                                StartCoroutine(Attack());
                            }
                        }
                        else
                        {
                            StartCoroutine(Attack());
                        }
                    }
                    if (mirror != null)
                    {
                        mirror.mirror = true;
                        ani.SetBool("Attack", true);
                    }
                }
                else
                {
                    if (move != null)
                    {
                        move.move = true;
                    }
                    ani.SetBool("Attack", false);
                    if (mirror != null)
                    {
                        mirror.mirror = false;
                        ani.SetBool("Attack", false);
                    }
                }
            }
        }

        if (move != null)
        {
            if (move.move == true)
            {
                ani.SetBool("Run", true);
            }
            else if (move.move == false)
            {
                ani.SetBool("Run", false);
            }
            if (stop == true)
            {
                move.move = false;
                ani.SetBool("Run", false);
            }
        }
        if (heal != null)
        {
            if (heal.isHeal == true)
            {
                ani.Play("Attack");
                ani.SetBool("Run", false);
            }
            else if (heal.isHeal == false)
            {
                ani.SetBool("Run", true);
            }
        }
        if (die == true)
        {
            ani.speed = 1;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            gameObject.layer = 0;
            if (attack != null)
            {
                attack.target = null;
                attack.attackable = false;
            }
            ani.SetBool("Die", true);
            StopAllCoroutines();
            if (move != null)
            {
                move.move = false;
            }
            if (heal != null)
            {
                heal.isHeal = false;
            }
        }
    }
    public void knockback()
    {
        StartCoroutine(Knockback());
    }
    public void Bigknockback()
    {
        StartCoroutine(BigKnockback());
    }
    public void stun(float time)
    {
        StartCoroutine(Stunned(time));
    }
    public void TimeStop(float time)
    {
        if (stat.health > 0)
        {
            StopCoroutine("TimeST");
            StartCoroutine(TimeST(time));
        }
        else
        {
            ani.speed = 1;
        }
    }
    public void Stop()
    {
        stop = true;
    }
    public void StopFinish()
    {
        stop = false;
    }
    void Die()
    {
        if (gameObject.tag == "Ally")
        {
            if (overload > 0)
            {
                overloadsystem.overloadstack -= overload;
            }
        }
        if (gameObject.tag == "Enemy")
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    IEnumerator Stunned(float Time)
    {
        isStun = true;
        move.move = false;
        if (heal != null)
        {
            heal.HealAv = false;
            heal.StopAllCoroutines();
        }
        yield return new WaitForSeconds(Time);
        isStun = false;
        move.move = true;
        if (heal != null)
        {
            heal.HealAv = true;
        }
    }
    IEnumerator Knockback()
    {
        ani.Play("Knockback");
        move.knockback = true;
        StartCoroutine(Stunned(1f));
        yield return new WaitForSeconds(1f);
        move.knockback = false;
        isStun = false;
    }
    IEnumerator Attack()
    {
        ani.Play("Attack");
        ani.SetBool("Attack", true);
        attack.attackable = false;
        yield return new WaitForSeconds(3f/stat.attackspeed);
        attack.attackable = true;
    }
    IEnumerator BigKnockback()
    {
        ani.Play("Knockback");
        move.Bigknock = true;
        StartCoroutine(Stunned(1f));
        yield return new WaitForSeconds(1f);
        move.Bigknock = false;
        isStun = false;
    }
    IEnumerator Reload()
    {
        attack.attackable = false;
        ani.SetBool("Attack", false);
        yield return new WaitForSeconds(3f);
        attack.bullet = attack.realbullet;
        attack.attackable = true;
    }
    IEnumerator TimeST(float time)
    {
        ani.speed = 0;
        yield return new WaitForSeconds(time);
        ani.speed = 1;
    }
}