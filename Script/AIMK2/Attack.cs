using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    sword,
    arrow,
    gun,
    mage,
    rangeattack,
    headattack,
    heal,
    buff,
    fix
}
public class Attack : MonoBehaviour
{
    AIMK2 ai;
    public AttackType attacktype;
    public GameObject Object;
    public int bullet;
    public bool knockback;
    public float stun;
    public Transform Shootposition;
    public bool castleattack;
    public bool Iscastle;
    public bool IsCriticleDouble;
    new public AudioSource audio;

    internal float attack;
    internal float attackspeed;
    internal float range;
    internal float critical;
    internal bool isattack;
    internal float Rattack;

    internal bool attackable;
    internal GameObject target;
    internal GameObject target2;
    internal GameObject target3;
    internal string targettag;
    internal string targettag2;
    float distance;
    internal int realbullet;
    // Start is called before the first frame update
    void Start()
    {
        ai = gameObject.GetComponent<AIMK2>();
        attackable = true;
        realbullet = bullet;

        if (gameObject.tag == "Ally")
        {
            targettag = "Enemy";
            targettag2 = "EnemyCastle";
        }
        else if (gameObject.tag == "Enemy")
        {
            targettag = "Ally";
            targettag2 = "AllyCastle";
        }
        if (attacktype == AttackType.heal || attacktype == AttackType.buff)
        {
            targettag = "Ally";
            targettag2 = null;
        }
        else if (attacktype == AttackType.fix)
        {
            targettag = "AllyCastle";
            targettag2 = null;
        }
        if(Shootposition == null)
        {
            Shootposition = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            distance = Vector2.Distance(gameObject.transform.position, target.transform.position);
        }
        if (distance > range)
        {
            target = null;
        }
        if (attacktype == AttackType.buff)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, range);
            List<GameObject> targetobj = new List<GameObject>();
            List<GameObject> targetbobj = new List<GameObject>();
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].tag == targettag && targets[i].gameObject != this.gameObject)
                {
                    if (targets[i].GetComponent<Stat>().Battack <= 0)
                    {
                        targetobj.Add(targets[i].gameObject);
                    }
                    else
                    {
                        targetbobj.Add(targets[i].gameObject);
                    }
                }
            }
            if (targetobj.Count > 0)
            {
                int rand = UnityEngine.Random.Range(0, targetobj.Count);
                target = targetobj[rand];
            }
            else if(targetbobj.Count > 0)
            {
                int rand = UnityEngine.Random.Range(0, targetbobj.Count);
                target = targetbobj[rand];
            }
        }
        if (attacktype == AttackType.heal)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, range);
            List<GameObject> targetobj = new List<GameObject>();
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].tag == targettag && targets[i].gameObject != this.gameObject)
                {
                    if (targets[i].GetComponent<Stat>().maxHealth > targets[i].GetComponent<Stat>().health)
                    {
                        targetobj.Add(targets[i].gameObject);
                    }
                }
            }
            if (targetobj.Count > 0)
            {
                target = targetobj[0];
                if (targetobj.Count > 1)
                {
                    target2 = targetobj[1];
                    if (targetobj.Count > 2)
                    {
                        target3 = targetobj[2];
                    }
                    else
                    {
                        target3 = null;
                    }
                }
                else
                {
                    target2 = null;
                    target3 = null;
                }
            }
        }
        if (attacktype == AttackType.fix)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, range);
            List<GameObject> targetobj = new List<GameObject>();
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].tag == targettag && targets[i].gameObject != this.gameObject)
                {
                    targetobj.Add(targets[i].gameObject);
                }
            }
            if (targetobj.Count >= 1)
            {
                target = targetobj[targetobj.Count - 1];
            }            
        }

        /*if (attackable == true)
        {
            if(target != null)
            {

                switch (attacktype)
                {
                    case AttackType.sword:
                        isattack = true;
                        StartCoroutine(Attackdelay());
                        StartCoroutine(Wait(3f / attackspeed));
                        break;

                    case AttackType.arrow:
                        isattack = true;
                        GameObject arrow = Instantiate(Object, transform.position, Quaternion.identity);
                        arrow.SendMessage("GetTarget", target.gameObject);
                        arrow.SendMessage("GetAttack", attack);
                        StartCoroutine(Wait(3f / attackspeed));
                        break;

                    case AttackType.gun:
                        StartCoroutine(Gunfire(bullet));
                        break;

                    case AttackType.mage:
                        isattack = true;
                        GameObject mage = Instantiate(Object, target.transform.position, Quaternion.identity);
                        mage.SendMessage("GetTarget", target.gameObject);
                        mage.SendMessage("GetAttack", attack);
                        mage.SendMessage("GetTag", gameObject.tag);
                        StartCoroutine(Wait(3f / attackspeed));
                        break;

                    case AttackType.rangeattack:
                        isattack = true;
                        GameObject rangeattack = Instantiate(Object, transform.position, Quaternion.Euler(0, 0, -90));
                        rangeattack.SendMessage("GetAttack", attack);
                        rangeattack.SendMessage("GetTag", gameObject.tag);
                        StartCoroutine(Wait(3f / attackspeed));
                        break;
                }

            }
        }*/
    }
    void AttackEnemy()
    {
        if (target != null)
        {
            if (IsCriticleDouble == false)
            {
                float rand = UnityEngine.Random.Range(0, 100);
                if (rand < critical)
                {
                    Rattack = attack * 2f;
                    target.SendMessage("Criticaling", true);
                }
                else
                {
                    Rattack = attack;
                }
            }
            
            if (audio != null)
            {
                audio.Play();
            }
            switch (attacktype)
            {
                case AttackType.sword:
                    if(castleattack == true && Iscastle == true)
                    {
                        target.SendMessage("Attacked", Rattack * 2);
                    }
                    else
                    {
                        target.SendMessage("Attacked", Rattack);
                    }

                    if (knockback == true)
                    {
                        target.SendMessage("knockback");
                    }
                    if (stun > 0)
                    {
                        target.SendMessage("stun", stun);
                    }
                    break;

                case AttackType.arrow:
                    GameObject arrow = Instantiate(Object, Shootposition.position, Quaternion.identity);
                    arrow.SendMessage("GetTarget", target.gameObject);
                    arrow.SendMessage("GetAttack", Rattack);
                    arrow.SendMessage("GetLevel", ai.stat.level);
                    break;

                case AttackType.gun:
                    GameObject gun = Instantiate(Object, Shootposition.position, Quaternion.identity);
                    gun.SendMessage("GetTarget", target.gameObject);
                    gun.SendMessage("GetAttack", Rattack);
                    gun.SendMessage("GetLevel", ai.stat.level);
                    bullet--;
                    break;

                case AttackType.mage:
                    GameObject mage = Instantiate(Object, target.transform.position, Quaternion.identity);
                    mage.SendMessage("GetTarget", target.gameObject);
                    mage.SendMessage("GetAttack", Rattack);
                    mage.SendMessage("GetTag", gameObject.tag);
                    mage.SendMessage("GetLevel", ai.stat.level);
                    break;
                case AttackType.headattack:
                    GameObject head = Instantiate(Object, new Vector3(target.transform.position.x, target.transform.position.y + 3), Quaternion.identity);
                    head.transform.parent = target.transform;
                    head.SendMessage("GetTarget", target.gameObject);
                    head.SendMessage("GetAttack", Rattack);
                    head.SendMessage("GetTag", gameObject.tag);
                    head.SendMessage("GetLevel", ai.stat.level);
                    break;
                case AttackType.rangeattack:
                    GameObject rangeattack = Instantiate(Object, Shootposition.position, Quaternion.Euler(0, 0, -90));
                    rangeattack.SendMessage("GetAttack", Rattack);
                    rangeattack.SendMessage("GetTag", gameObject.tag);
                    rangeattack.SendMessage("GetLevel", ai.stat.level);
                    break;
                case AttackType.heal:
                    Stat targetstatheal = target.GetComponent<Stat>();
                    GameObject shoot = Instantiate(Object, Shootposition.position, Quaternion.identity);
                    shoot.SendMessage("GetHeal", targetstatheal.maxHealth / 100 * 13);
                    shoot.SendMessage("GetTarget", target);
                    if (target2 != null)
                    {
                        Stat targetstatheal2 = target2.GetComponent<Stat>();
                        GameObject shoot2 = Instantiate(Object, Shootposition.position, Quaternion.identity);
                        shoot2.SendMessage("GetHeal", targetstatheal2.maxHealth / 100 * 13);
                        shoot2.SendMessage("GetTarget", target2);
                    }
                    if (target3 != null)
                    {
                        Stat targetstatheal3 = target2.GetComponent<Stat>();
                        GameObject shoot3 = Instantiate(Object, Shootposition.position, Quaternion.identity);
                        shoot3.SendMessage("GetHeal", targetstatheal3.maxHealth / 100 * 13);
                        shoot3.SendMessage("GetTarget", target3);
                    }
                    break;
                case AttackType.buff:
                    Stat targetstat = target.GetComponent<Stat>();
                    target.SendMessage("BuffAttack", targetstat.attack / 5);
                    target.SendMessage("BuffAttackSpeed", targetstat.attackspeed / 5);
                    break;
            }
        }
    }
    void FixCastle()
    {
        if(attacktype == AttackType.fix)
        {
            target.SendMessage("Fixed", attack);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        float distance = Vector2.Distance(gameObject.transform.position, collision.transform.position);

        if (target == null)
        {
            if (collision.tag == targettag || collision.tag == targettag2)
            {
                if (distance < range)
                {
                    if (collision.tag == targettag2 && tag == "Ally")
                    {
                        target = collision.gameObject.transform.parent.gameObject;
                        Iscastle = true;
                    }
                    else
                    {
                        target = collision.gameObject;
                        Iscastle = false;
                    }
                }
            }
        }
        else if (target != null)
        {
            if (collision.tag == targettag || collision.tag == targettag2)
            {
                float targetdistance = Vector2.Distance(gameObject.transform.position, target.transform.position);
                if (distance < targetdistance)
                {
                    if (collision.tag == targettag2)
                    {
                        target = collision.gameObject.transform.parent.gameObject;
                        Iscastle = true;
                    }
                    else
                    {
                        target = collision.gameObject;
                        Iscastle = false;
                    }
                }
            }
        }
    }
    IEnumerator Wait(float time)
    {
        attackable = false;
        yield return new WaitForSeconds(time);
        attackable = true;
    }
    IEnumerator Attackdelay()
    {
        yield return new WaitForSeconds(0.5f);
        target.SendMessage("Attacked", attack);
        if(knockback == true)
        {
            target.SendMessage("knockback");
        }
        if(stun > 0)
        {
            target.SendMessage("stun", stun);
        }
    }
    IEnumerator Gunfire(int bullet)
    {
        for (int i = 0; i < bullet; i++)
        {
            isattack = true;
            GameObject gun = Instantiate(Object, transform.position, Quaternion.identity);
            gun.SendMessage("GetTarget", target.gameObject);
            gun.SendMessage("GetAttack", attack);

            attackable = false;
            yield return new WaitForSeconds(1 / attackspeed);
            attackable = true;
        }
        StartCoroutine(Wait(3f / attackspeed));
    }
}
