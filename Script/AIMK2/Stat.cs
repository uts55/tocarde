using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UnitType
{
    원거리,
    근거리,
    탱커,
    딜탱,
    공속,
    치명타
}
public class Stat : MonoBehaviour
{
    public UnitType unittype;
    AIMK2 ai;
    public Slider slider;
    float timer;
    public int unitNumber;
    public int level;

    public float attack;
    public float defence;
    public float health;
    public float speed;
    public float attackspeed;
    public float range;
    public float critical;

    internal float Aattack;
    internal float Adefence;
    internal float Aspeed;
    internal float Aattackspeed;
    internal float Arange;

    internal float Battack;
    internal float Bdefence;
    internal float Bspeed;
    internal float Battackspeed;

    internal float maxHealth;
    public GameObject DamageText;
    public GameObject BuffText;
    public GameObject Debuff;
    public GameObject blood;
    public GameObject AttackedEff;
    public GameObject healEff;
    public GameObject toxicEff;
    public GameObject festEff;
    public GameObject burnEff;

    bool isBattack;
    bool isBdefence;
    bool isBspeed;
    bool isBattackspeed;
    bool guage = false;
    bool isHealed;
    bool Criticaled;
    internal bool invincible = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (unitNumber > 0)
        {
            level = GameData.Instance.unit_all_list.list[unitNumber - 1].unit_level;
            attack = GameData.Instance.unit_all_list.list[unitNumber - 1].attack_damage;
            health = GameData.Instance.unit_all_list.list[unitNumber - 1].health;
            attackspeed = GameData.Instance.unit_all_list.list[unitNumber - 1].attack_speed;
            critical = GameData.Instance.unit_all_list.list[unitNumber - 1].critical_per;
        }
        /*
        if (unittype == UnitType.원거리)
        {
            float a = GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            float h = GameData.Instance.unit_all_list.list[unitNumber].health;
            float s = GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
            for (int i = 0; i < level - 1; i++)
            {
                a *= 1.1f;
                h *= 1.1f;
                s *= 1.1f;
            }
            //attack = (level - 1) * 0.1f * GameData.Instance.unit_all_list.list[unitNumber].attack_damage + GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            //health = (level - 1) * 0.1f * GameData.Instance.unit_all_list.list[unitNumber].health + GameData.Instance.unit_all_list.list[unitNumber].health;
            //attackspeed = (level - 1) * 0.1f * GameData.Instance.unit_all_list.list[unitNumber].attack_speed + GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
        }
        else if (unittype == UnitType.근거리)
        {
            float a = GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            float h = GameData.Instance.unit_all_list.list[unitNumber].health;
            float s = GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
            for (int i = 0; i < level - 1; i++)
            {
                a *= 1.15f;
                h *= 1.05f;
                s *= 1.05f;
            }
            //attack = (level - 1) * 0.15f * GameData.Instance.unit_all_list.list[unitNumber].attack_damage + GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            //health = (level - 1) * 0.05f * GameData.Instance.unit_all_list.list[unitNumber].health + GameData.Instance.unit_all_list.list[unitNumber].health;
            //attackspeed = (level - 1) * 0.05f * GameData.Instance.unit_all_list.list[unitNumber].attack_speed + GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
        }
        else if (unittype == UnitType.탱커)
        {
            float a = GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            float h = GameData.Instance.unit_all_list.list[unitNumber].health;
            float s = GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
            for (int i = 0; i < level - 1; i++)
            {
                a *= 1.05f;
                h *= 1.15f;
                s *= 1.03f;
            }
            //attack = (level - 1) * 0.05f * GameData.Instance.unit_all_list.list[unitNumber].attack_damage + GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            //health = (level - 1) * 0.15f * GameData.Instance.unit_all_list.list[unitNumber].health + GameData.Instance.unit_all_list.list[unitNumber].health;
            //attackspeed = (level - 1) * 0.03f * GameData.Instance.unit_all_list.list[unitNumber].attack_speed + GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
        }
        else if (unittype == UnitType.딜탱)
        {
            float a = GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            float h = GameData.Instance.unit_all_list.list[unitNumber].health;
            float s = GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
            for (int i = 0; i < level - 1; i++)
            {
                a *= 1.1f;
                h *= 1.1f;
                s *= 1.03f;
            }
            //attack = (level - 1) * 0.1f * GameData.Instance.unit_all_list.list[unitNumber].attack_damage + GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            //health = (level - 1) * 0.1f * GameData.Instance.unit_all_list.list[unitNumber].health + GameData.Instance.unit_all_list.list[unitNumber].health;
            //attackspeed = (level - 1) * 0.03f * GameData.Instance.unit_all_list.list[unitNumber].attack_speed + GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
        }
        else if (unittype == UnitType.공속)
        {
            float a = GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            float h = GameData.Instance.unit_all_list.list[unitNumber].health;
            float s = GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
            for (int i = 0; i < level - 1; i++)
            {
                a *= 1.05f;
                h *= 1.05f;
                s *= 1.15f;
            }
            //attack = (level - 1) * 0.05f * GameData.Instance.unit_all_list.list[unitNumber].attack_damage + GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            //health = (level - 1) * 0.05f * GameData.Instance.unit_all_list.list[unitNumber].health + GameData.Instance.unit_all_list.list[unitNumber].health;
            //attackspeed = (level - 1) * 0.15f * GameData.Instance.unit_all_list.list[unitNumber].attack_speed + GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
        }
        else if (unittype == UnitType.치명타)
        {
            float a = GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            float h = GameData.Instance.unit_all_list.list[unitNumber].health;
            float s = GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
            for (int i = 0; i < level - 1; i++)
            {
                a *= 1.05f;
                h *= 1.05f;
                s *= 1.05f;
            }
            //attack = (level - 1) * 0.05f * GameData.Instance.unit_all_list.list[unitNumber].attack_damage + GameData.Instance.unit_all_list.list[unitNumber].attack_damage;
            //health = (level - 1) * 0.05f * GameData.Instance.unit_all_list.list[unitNumber].health + GameData.Instance.unit_all_list.list[unitNumber].health;
            //attackspeed = (level - 1) * 0.05f * GameData.Instance.unit_all_list.list[unitNumber].attack_speed + GameData.Instance.unit_all_list.list[unitNumber].attack_speed;
        }*/
    }
    void Start()
    {
        ai = gameObject.GetComponent<AIMK2>();
        range = range + Random.Range(-0.5f, 0.5f);

        Aattack = attack;
        Adefence = defence;
        Aspeed = speed;
        Aattackspeed = attackspeed;
        Arange = range;
        isBattack = true;
        isBdefence = true;
        isBspeed = true;
        isBattackspeed = true;
        isHealed = false;
        guage = false;
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider != null)
        {
            slider.value = health / maxHealth;
        }
        if(guage == true)
        {
            slider.gameObject.SetActive(true);
        }
        else if(guage == false)
        {
            slider.gameObject.SetActive(false);
        }
        attack = Aattack + Battack;
        defence = Adefence + Bdefence;
        speed = Aspeed + Bspeed;
        attackspeed = Aattackspeed + Battackspeed;

        if (Battack > 0)
        {
            if (isBattack == true)
            {
                float randomX = Random.Range(-0.5f, 0.5f);
                float randomY = Random.Range(-0.5f, 0.5f);
                float randomZ = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(BuffText, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), Quaternion.identity);
                text.transform.parent = gameObject.transform;
                text.SendMessage("GetBuffType", "Attack");
                StartCoroutine(buffshow("Attack", Battack));
            }
        }
        else if(Battack < 0)
        {
            if (isBattack == true)
            {
                float randomX = Random.Range(-0.5f, 0.5f);
                float randomY = Random.Range(-0.5f, 0.5f);
                float randomZ = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(Debuff, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), new Quaternion(0,0,180,0));
                text.transform.parent = gameObject.transform;
                text.SendMessage("GetBuffType", "Attack");
                StartCoroutine(buffshow("Attack", Battack));
            }
        }
        if (Bdefence > 0)
        {
            if (isBdefence == true)
            {
                float randomX = Random.Range(-0.5f, 0.5f);
                float randomY = Random.Range(-0.5f, 0.5f);
                float randomZ = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(BuffText, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), Quaternion.identity);
                text.transform.parent = gameObject.transform;
                text.SendMessage("GetBuffType", "Defence");
                StartCoroutine(buffshow("Defence", Bdefence));
            }
        }
        else if(Bdefence <0)
        {
            if (isBdefence == true)
            {
                float randomX = Random.Range(-0.5f, 0.5f);
                float randomY = Random.Range(-0.5f, 0.5f);
                float randomZ = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(Debuff, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), new Quaternion(0, 0, 180, 0));
                text.transform.parent = gameObject.transform;
                text.SendMessage("GetBuffType", "Defence");
                StartCoroutine(buffshow("Defence", Bdefence));
            }
        }
        if (Bspeed > 0)
        {
            if (isBspeed == true)
            {
                float randomX = Random.Range(-0.5f, 0.5f);
                float randomY = Random.Range(-0.5f, 0.5f);
                float randomZ = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(BuffText, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), Quaternion.identity);
                text.transform.parent = gameObject.transform;
                text.SendMessage("GetBuffType", "Speed");
                StartCoroutine(buffshow("Speed", Bspeed));
            }
        }
        else if(Bspeed < 0)
        {
            if (isBspeed == true)
            {
                float randomX = Random.Range(-0.5f, 0.5f);
                float randomY = Random.Range(-0.5f, 0.5f);
                float randomZ = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(Debuff, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), new Quaternion(0, 0, 180, 0));
                text.transform.parent = gameObject.transform;
                text.SendMessage("GetBuffType", "Speed");
                StartCoroutine(buffshow("Speed", Bspeed));
            }
        }
        if (Battackspeed > 0)
        {
            if (isBattackspeed == true)
            {
                float randomX = Random.Range(-0.5f, 0.5f);
                float randomY = Random.Range(-0.5f, 0.5f);
                float randomZ = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(BuffText, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), Quaternion.identity);
                text.transform.parent = gameObject.transform;
                text.SendMessage("GetBuffType", "AttackSpeed");
                StartCoroutine(buffshow("AttackSpeed", Battackspeed));
            }
        }
        else if(Battackspeed <0)
        {
            if (isBattackspeed == true)
            {
                float randomX = Random.Range(-0.5f, 0.5f);
                float randomY = Random.Range(-0.5f, 0.5f);
                float randomZ = Random.Range(-0.5f, 0.5f);
                GameObject text = Instantiate(Debuff, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), new Quaternion(0, 0, 180, 0));
                text.transform.parent = gameObject.transform;
                text.SendMessage("GetBuffType", "AttackSpeed");
                StartCoroutine(buffshow("AttackSpeed", Battackspeed));
            }
        }
        /*if (isHealed == true)
        {
            float randomX = Random.Range(-0.5f, 0.5f);
            float randomY = Random.Range(-0.5f, 0.5f);
            float randomZ = Random.Range(-0.5f, 0.5f);
            GameObject text = Instantiate(BuffText, new Vector3(transform.position.x + randomX, transform.position.y + randomY * 2f, transform.position.z + randomZ), new Quaternion(0, 180, 0, 0));
            text.transform.parent = gameObject.transform;
            text.SendMessage("GetBuffType", "Heal");
        }*/
    }
    void selfAttacked()
    {
        if (health > 0)
        {
            ai.ani.SetTrigger("Attacked");
            health -= attack / defence;
            float random = Random.Range(-0.5f, 0.5f);
            StartCoroutine(bloodshow());
            StartCoroutine(Guageshow());
            StartCoroutine(Effectshow());
            GameObject text = Instantiate(DamageText, new Vector3(transform.position.x + random, transform.position.y + 1f + random / 2, transform.position.z - 3), Quaternion.identity);
            text.transform.parent = gameObject.transform;
            text.SendMessage("GetDamage", attack / defence);
        }
        else if (health <= 0)
        {
            ai.die = true;
        }
    }
    public void Criticaling(bool c)
    {
        Criticaled = c;
    }
    public void Attacked(float attack)
    {
        if (invincible != true)
        {
            if (gameObject.GetComponent<MirrorAttack>() != null)
            {
                gameObject.SendMessage("getMAttack", true);
            }

            if (attack / defence >= maxHealth * 0.3f && ai.ani.speed > 0)
            {
                ai.knockback();
            }
            /*if (audio != null)
            {
                audio.Play();
            }*/
            ai.ani.SetTrigger("Attacked");
            health -= attack / defence;
            StartCoroutine(Guageshow());
            StartCoroutine(bloodshow());
            StartCoroutine(Effectshow());
            float random = Random.Range(-0.5f, 0.5f);
            GameObject text = Instantiate(DamageText, new Vector3(transform.position.x + random, transform.position.y + 1f + random / 2, transform.position.z - 3), Quaternion.identity);
            text.transform.parent = gameObject.transform;
            if(Criticaled == true)
            {
                text.transform.localScale = new Vector3(0.2f, 0.2f);
                Criticaled = false;
            }
            text.SendMessage("GetDamage", attack / defence);
        }
    }
    public void BuffAttack(float amount)
    {
        Battack = amount;
        BuffReset("Attack",amount);
    }
    public void BuffDefence(float amount)
    {
        Bdefence = amount;
        BuffReset("Defence",amount);
    }
    public void BuffSpeed(float amount)
    {
        Bspeed = amount;
        BuffReset("Speed",amount);
    }
    public void BuffAttackSpeed(float amount)
    {
        Battackspeed = amount;
        BuffReset("AttackSpeed",amount);
    }

    public void Healed(float amount)
    {
        if(health < maxHealth)
        {
            StartCoroutine(Guageshow());
            StartCoroutine(Healshow());
            health += amount;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
    IEnumerator Healshow()
    {
        healEff.SetActive(true);
        yield return new WaitForSeconds(2f);
        healEff.SetActive(false);
    }
    public void BuffReset(string type, float amount) 
    {
        StartCoroutine(buffreset(type, amount)); 
    }
    IEnumerator buffreset(string type,float amount)
    {
        yield return new WaitForSeconds(5f);
        if(type == "Attack")
        {
            Battack -= amount;
        }
        if (type == "Defence")
        {
            Bdefence -= amount;
        }
        if (type == "Speed")
        {
            Bspeed -= amount;
        }
        if (type == "AttackSpeed")
        {
            Battack -= amount;
        }
    }
    IEnumerator buffshow(string type, float amount)
    {
        if (type == "Attack")
        {
            isBattack = false;
        }
        if (type == "Defence")
        {
            isBdefence = false;
        }
        if (type == "Speed")
        {
            isBspeed = false;
        }
        if (type == "AttackSpeed")
        {
            isBattackspeed = false;
        }
        yield return new WaitForSeconds(0.2f/amount);
        if (type == "Attack")
        {
            isBattack = true;
        }
        if (type == "Defence")
        {
            isBdefence = true;
        }
        if (type == "Speed")
        {
            isBspeed = true;
        }
        if (type == "AttackSpeed")
        {
            isBattackspeed = true;
        }
    }
    IEnumerator bloodshow()
    {
        if (gameObject.tag == "Ally")
        {
            if (blood != null)
            {
                GameObject bloo = Instantiate(blood, new Vector3(transform.position.x + Random.Range(1f, 1.5f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z - 3), Quaternion.identity);
                bloo.transform.parent = gameObject.transform;
                yield return new WaitForSeconds(1f);
                Destroy(bloo);
            }
        }
        if (gameObject.tag == "Enemy")
        {
            if (blood != null)
            {
                GameObject bloo = Instantiate(blood, new Vector3(transform.position.x + Random.Range(-1.5f, -1f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z - 3), Quaternion.identity);
                bloo.transform.parent = gameObject.transform;
                yield return new WaitForSeconds(1f);
                Destroy(bloo);
            }
        }
    }
    IEnumerator Guageshow()
    {
        guage = true;
        yield return new WaitForSeconds(1.5f);
        guage = false;
    }
    IEnumerator Effectshow()
    {
        if (gameObject.tag == "Ally")
        {
            GameObject effect = Instantiate(AttackedEff, new Vector3(transform.position.x + Random.Range(0.5f, 1f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z - 3), Quaternion.identity);
            effect.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(1f);
            Destroy(effect);
        }
        if (gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(AttackedEff, new Vector3(transform.position.x + Random.Range(-0.5f, -1f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z - 3), Quaternion.identity);
            effect.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(1f);
            Destroy(effect);
        }
    }
}
