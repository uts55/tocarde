using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    private static CardData instance = null;
    public GameObject miner;
    public Transform MinerSpawnpoint;
    public Transform SpawnPoint;
    public GameObject Bbomberman;
    public GameObject Carrot;
    public GameObject[] Bigfriend;
    public GameObject Kaze;
    public Enemy_castleAI enemyCastle;
    public GameManager gameManager;
    public WaveSystem wavesystem;
    public MinionSpawn minionSpawn;
    public Enemy_castleAI enemycastle;
    public int use;
    int Feverlevel;
    int hirestack;
    int level;
    internal bool Fevertime = false;
    CardDraw drawsystem;
    GameObject[] Ally;
    GameObject[] Enemy;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        { 
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        drawsystem = GameObject.FindGameObjectWithTag("Drawsystem").GetComponent<CardDraw>();
        hirestack = 0;
    }

    void Update()
    {
        if(Fevertime == true)
        {
            if(use >= 1)
            {
                use--;
                gameManager.gold += 15 + (5 * (Feverlevel));
            }
        }
        else
        {
            use = 0;
        }
    }

    public static CardData Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    //대강 카드별 함수, 프리팹 여기서 관리하기
    //카드 드랍할때 카드 스테이터스 안의 unitnumber에 따라
    public void Functionstart(int unitnumber)
    {
        if(unitnumber > 100 && unitnumber < 200)
        {
            level = GameData.Instance.magic_all_list.list[unitnumber-100].unit_level;
        }
        else if(unitnumber > 200)
        {
            level = GameData.Instance.magic_all_list.list[unitnumber - 200].unit_level;
        }
        
        switch (unitnumber)
        {
            /*case 101:
                spawnMiner();
                break;
            case 102:
                MinerSpeedUp();
                break;
            case 103:
                Bomberman();
                break;
            case 104:
                AllyAttackSpeedBuff();
                break;
            case 105:
                AllyAttackBuff();
                break;
            case 106:
                AllySpeedBuff();
                break;
            case 107:
                AllyHeal();
                break;
            case 108:
                EnemyAttackSpeedDebuff();
                break;
            case 109:
                EnemyAttackDebuff();
                break;
            case 110:
                EnemySlow();
                break;
            case 111:
                Thunder();
                break;
            case 112:
                DrawCarrot();
                break;*/
            case 101:
                DrawCarrot(level);
                break;
            case 102:
                Reload();
                break;
            case 106:
                SlotMachine(level);
                break;
            case 107:
                BigFriend(level);
                break;
            case 108:
                Steal(level);
                break;
            case 109:
                FeverTime(level);
                break;
            case 110:
                FortuneCookie(level);
                break;
            case 111:
                FreshCarrot(level);
                break;
            case 112:
                HugeHire(level);
                break;
            case 113:
                MissForcha(level);
                break;
            case 114:
                Thunder(level);
                break;
            case 115:
                Bomberman();
                break;
            case 116:
                Fatman();
                break;
            case 117:
                Fest(level);
                break;
            case 118:
                Kamikaze();
                break;
            case 119:
                Toxicc(level);
                break;
            case 120:
                FriendShield();
                break;
            case 121:
                AngelShield();
                break;
            case 122:
                spawnMiner();
                break;
            case 201:
                Emergency(level);
                break;
            case 202:
                Cheers(level);
                break;
            case 203:
                GoldMine(level);
                break;
            case 204:
                BreakingCastle(level);
                break;
            case 205:
                RabbitCollector(level);
                break;
            case 206:
                Berserker(level);
                break;
            case 207:
                LuckyFortune(level);
                break;
            case 208:
                StoneSkin(level);
                break;
            case 209:
                MinionRage(level);
                break;
            case 210:
                HealTotem();
                break;
            case 211:
                Haste(level);
                break;
            default:
                break;
        }
    }
    public void spawnMiner()
    {
        float random = UnityEngine.Random.Range(-0.3f, 0.3f);
        Vector3 randomspot = new Vector3(MinerSpawnpoint.transform.position.x, MinerSpawnpoint.transform.position.y + random, random * 100);
        Instantiate(miner, randomspot, Quaternion.identity);
    }
    public void MinerSpeedUp()
    {
        GameObject[] miners = GameObject.FindGameObjectsWithTag("Miner");
        for (int i = 0; i < miners.Length; i++)
        {
            miners[i].GetComponent<Stat>().BuffSpeed(2);
        }
    }
    public void Bomberman()
    {
        GameObject BombMan = Instantiate(Bbomberman, SpawnPoint.position, Quaternion.identity);
        BombMan.SendMessage("Getlevel",level);
    }
    public void AllyAttackSpeedBuff()
    {
        Ally = null;
        Ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < Ally.Length; i++)
        {
            Ally[i].SendMessage("BuffAttackSpeed", 2);
        }
    }
    public void AllyAttackBuff()
    {
        Ally = null;
        Ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < Ally.Length; i++)
        {
            Ally[i].SendMessage("BuffAttack", 2);
        }
    }
    public void AllySpeedBuff()
    {
        Ally = null;
        Ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < Ally.Length; i++)
        {
            Ally[i].SendMessage("BuffSpeed", 2);
        }
    }
    public void AllyHeal()
    {
        Ally = null;
        Ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < Ally.Length; i++)
        {
            GameObject HealCarrot = Instantiate(Carrot, SpawnPoint.position, Quaternion.identity);
            HealCarrot.SendMessage("GetTarget",Ally[i].gameObject);
            HealCarrot.SendMessage("GetHeal", 5);
        }
    }
    public void EnemyAttackSpeedDebuff()
    {
        Enemy = null;
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i].SendMessage("BuffAttackSpeed", -2);
        }
    }
    public void EnemyAttackDebuff()
    {
        Enemy = null;
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i].SendMessage("BuffAttack", -2);
        }
    }
    public void EnemySlow()
    {
        Enemy = null;
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i].SendMessage("BuffAttack", -2);
            Enemy[i].SendMessage("BuffAttackSpeed", -2);
        }
    }
    public void Thunder(int level)
    {

    }
    public void DrawCarrot(int level)
    {
        StartCoroutine(drawC(level));
    }
    IEnumerator drawC(int level)
    {
        level = (int)(1 + Mathf.Floor(level * 0.33f)); 
        for (int i = 0; i < 1+level; i++)
        {
            drawsystem.OnDraw();
            yield return new WaitForSeconds(0.5f);
        }
        /*float rand = Random.Range(0, 10);
        if(rand <=1)
        {
            drawsystem.OnDraw();
        }*/
    }
    public void Reload()
    {
        int hand = drawsystem.card_count;
        drawsystem.DeleteHandAll();
        StartCoroutine(Reloading(hand));
    }
    IEnumerator Reloading(int hand)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < hand; i++)
        {
            drawsystem.OnDraw();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void SlotMachine(int level)
    {
        StartCoroutine(RandomD(level));
    }
    IEnumerator RandomD(int level)
    {
        for (int i = 0; i < level + 2; i++)
        {
            drawsystem.RandomDraw();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void BigFriend(int level)
    {
        StartCoroutine(SpawnBifFriend(level));
    }
    IEnumerator SpawnBifFriend(int level)
    {
        for (int i = 0; i < level; i++)
        {
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y + random, random * 100);
            int rand = UnityEngine.Random.Range(0, Bigfriend.Length);
            Instantiate(Bigfriend[rand], randomspot, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void Steal(int level)
    {
        enemyCastle = GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<Enemy_castleAI>();
        enemyCastle.health -= 50 + (50 * 0.3f * (level-1));
        gameManager.gold += 50 + (50 * 0.2f * (level - 1));
    }
    public void FeverTime(int level)
    {
        StartCoroutine(StartFever(level));
    }
    IEnumerator StartFever(int level)
    {
        yield return new WaitForSeconds(0.5f);
        Feverlevel = level;
        Fevertime = true;
        yield return new WaitForSeconds(6);
        Fevertime = false;
        Feverlevel = 0;
    }
    public void FortuneCookie(int level)
    {
        float randomPercent = Random.Range(0, 101);
        float special = 10 + (10 * 0.2f * (level - 1));
        float rare = 60 + (60 * 0.05f * (level - 1));
        float normal = 100 - special - rare;
        if(randomPercent <= special)
        {
            int randomnumber = Random.Range(0, GameData.Instance.normal_card_list.list.Count + 1);
            int unitnumber = GameData.Instance.normal_card_list.list[randomnumber];
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y + random, random * 100);
            Instantiate(GameManager.Instance.unit_list_all[unitnumber], randomspot, Quaternion.identity);
        }
        else if(randomPercent > special && randomPercent <= rare + special)
        {
            int randomnumber = Random.Range(0, GameData.Instance.rare_card_list.list.Count + 1);
            int unitnumber = GameData.Instance.normal_card_list.list[randomnumber];
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y + random, random * 100);
            Instantiate(GameManager.Instance.unit_list_all[unitnumber], randomspot, Quaternion.identity);
        }
        else if (randomPercent > rare + special && randomPercent <= 100)
        {
            int randomnumber = Random.Range(0, GameData.Instance.unique_card_list.list.Count + 1);
            int unitnumber = GameData.Instance.normal_card_list.list[randomnumber];
            float random = UnityEngine.Random.Range(-0.3f, 0.3f);
            Vector3 randomspot = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y + random, random * 100);
            Instantiate(GameManager.Instance.unit_list_all[unitnumber], randomspot, Quaternion.identity);
        }
    }
    public void FreshCarrot(int level)
    {
        gameManager.gold += 40 + (40 * 1.1f * (level -1));
    }
    public void MissForcha(int level)
    {

    }
    public void Fatman()
    {

    }
    public void Kamikaze()
    {
        float random = UnityEngine.Random.Range(-0.3f, 0.3f);
        Vector3 randomspot = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y + random, random * 100);
        GameObject bom = Instantiate(Kaze, randomspot, Quaternion.identity);
        bom.GetComponent<Stat>().Aattack = 100 + (100 * 0.3f * (level - 1));
    }
    public void Emergency(int level)
    {
        List<Stat> Allystatlist = new List<Stat>();
        GameObject[] ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < ally.Length; i++)
        {
            if(ally[i].GetComponent<Stat>() != null)
                Allystatlist.Add(ally[i].gameObject.GetComponent<Stat>());
        }
        for (int i = 0; i < Allystatlist.Count; i++)
        {
            Allystatlist[i].gameObject.SendMessage("Healed", Allystatlist[i].maxHealth * (0.25f +((level-1) * 0.05f )));
        }
    }
    public void Cheers(int level)
    {
        List<Stat> Allystatlist = new List<Stat>();
        GameObject[] ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i].GetComponent<Stat>() != null)
                Allystatlist.Add(ally[i].gameObject.GetComponent<Stat>());
        }
        for (int i = 0; i < Allystatlist.Count; i++)
        {
            Allystatlist[i].gameObject.SendMessage("BuffAttack", Allystatlist[i].attack * (0.1f + ((level-1) * 0.05f)));
        }
    }
    public void GoldMine(int level)
    {
        List<Stat> Allystatlist = new List<Stat>();
        GameObject[] ally = GameObject.FindGameObjectsWithTag("Miner");
        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i].GetComponent<Stat>() != null)
                Allystatlist.Add(ally[i].gameObject.GetComponent<Stat>());
        }
        for (int i = 0; i < Allystatlist.Count; i++)
        {
            Allystatlist[i].gameObject.SendMessage("BuffSpeed", Allystatlist[i].speed * (0.55f + ((level-1) * 0.05f)));
        }
    }
    public void RabbitCollector(int level)
    {
        GameManager.Instance.gold += drawsystem.card_count * (15 + (level - 1) * 5);
    }
    public void Berserker(int level)
    {
        List<Stat> Allystatlist = new List<Stat>();
        GameObject[] ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i].GetComponent<Stat>() != null)
                Allystatlist.Add(ally[i].gameObject.GetComponent<Stat>());
        }
        for (int i = 0; i < Allystatlist.Count; i++)
        {
            StartCoroutine(berserk(Allystatlist[i], level));
        }
    }
    IEnumerator berserk(Stat obj, int level)
    {
        obj.health = 1;
        obj.SendMessage("BuffAttack", obj.attack * (0.5f + ((level-1) * 0.1f)));
        obj.SendMessage("BuffAttackSpeed", obj.attackspeed * (0.5f + ((level - 1) * 0.1f)));
        obj.invincible = true;
        yield return new WaitForSeconds(5);
        obj.invincible = false;
    }
    public void LuckyFortune(int level)
    {
        int rand = Random.Range(0, 100);
        List<Stat> Allystatlist = new List<Stat>();
        GameObject[] ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i].GetComponent<Stat>() != null)
                Allystatlist.Add(ally[i].gameObject.GetComponent<Stat>());
        }
        for (int i = 0; i < Allystatlist.Count; i++)
        {
            if(rand < 50 + (level - 1) * 5)
            {
                Allystatlist[i].gameObject.SendMessage("BuffAttack",Allystatlist[i].attack * 0.5f);
                Allystatlist[i].gameObject.SendMessage("Healed", Allystatlist[i].maxHealth * 0.5f);
            }
            else
            {
                Allystatlist[i].gameObject.SendMessage("BuffAttack", Allystatlist[i].attack * 0.5f * -1);
                Allystatlist[i].gameObject.SendMessage("Healed", Allystatlist[i].maxHealth * 0.5f * -1);
            }
        }
    }
    public void StoneSkin(int level)
    {
        List<Stat> Allystatlist = new List<Stat>();
        GameObject[] ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i].GetComponent<Stat>() != null)
                Allystatlist.Add(ally[i].gameObject.GetComponent<Stat>());
        }
        for (int i = 0; i < Allystatlist.Count; i++)
        {
            Allystatlist[i].gameObject.SendMessage("BuffDefence", Allystatlist[i].defence * (0.5f + (level * 0.5f)));
        }
    }
    public void MinionRage(int level)
    {
        if (minionSpawn.minionlevel < 6)
        {
            minionSpawn.minionlevel++;
            minionSpawn.cardlevel = level;
        }
        else if(minionSpawn.minionlevel > 6)
        {
            minionSpawn.spawntime -= 2f;
            
        }
    }
    public void HealTotem()
    {

    }
    public void Haste(int level)
    {
        List<Stat> Allystatlist = new List<Stat>();
        GameObject[] ally = GameObject.FindGameObjectsWithTag("Ally");
        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i].GetComponent<Stat>() != null)
                Allystatlist.Add(ally[i].gameObject.GetComponent<Stat>());
        }
        for (int i = 0; i < Allystatlist.Count; i++)
        {
            Allystatlist[i].gameObject.SendMessage("BuffAttackSpeed", Allystatlist[i].attackspeed * (0.2f + (level * 0.05f)));
            Allystatlist[i].gameObject.SendMessage("BuffSpeed", Allystatlist[i].speed * (0.2f + (level * 0.05f)));
        }
    }
    public void BreakingCastle(int level)
    {
        enemycastle.Breaking(0.4f + (0.05f * (level - 1)));
    }
    public void HugeHire(int level)
    {
        hirestack++;
        if(hirestack > 5)
        {
            hirestack = 0;
            StartCoroutine(Hiring(level));
        }
    }
    IEnumerator Hiring(int level)
    {
        for (int i = 0; i < level + 4; i++)
        {
            drawsystem.SettingDraw(120);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void Fest(int level)
    {
        Enemy = null;
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        int at = Enemy.Length;
        if (at > 3)
            at = 3;
        for (int i = 0; i < at; i++)
        {
            int random = Random.Range(0, Enemy.Length);
            Enemy[random].AddComponent<Fest>();
            Enemy[random].SendMessage("Festlevel", level);
        }
    }
    public void Toxicc(int level)
    {

    }
    public void FriendShield()
    {

    }
    public void AngelShield()
    {

    }
}
