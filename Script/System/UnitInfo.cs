using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitInfo : MonoBehaviour
{
    public Text level_text;
    public Text attack_damage_text;
    public Text health_text;
    public Text defense_text;
    public Text attack_speed_text;
    public Text move_speed_text;
    public Text critical_text;
    public Text low_cost_text;


    public int unit_index;
    public float level;
    public float attack_damage;
    public float health;
    public float defense;
    public float attack_speed;
    public float move_speed;
    public float critical;
    public int low_cost;
    public int high_cost;


    //업그레이드 미리보기 텍스트
    public Text level_text_up;
    public Text attack_damage_text_up;
    public Text health_text_up;
    public Text defense_text_up;
    public Text attack_speed_text_up;
    public Text move_speed_text_up;
    public Text critical_text_up;
    public Text low_cost_text_up;

    //업그레이드 미리보기 온오프
    bool is_pre_on;
    bool is_pre_description_on;

    //카드 프리팹
    public GameObject card_prefab;

    //정보창 설명
    string info_description;
    public TextMeshProUGUI info_description_object;

    //a = attack_damage, b = health, c = attack_speed, d = defense, e = move_speed, f = critical
    int a;
    int b;
    int c;
    int d;
    int e;
    int f;

    //정보 미리보기
    string pre_info_description;
    public TextMeshProUGUI pre_info_description_object;

    //a = attack_damage, b = health, c = attack_speed, d = defense, e = move_speed, f = critical
    int pre_a;
    int pre_b;
    int pre_c;
    int pre_d;
    int pre_e;
    int pre_f;

    //업그레이드 전, 후

    // Start is called before the first frame update
    void Start()
    {
        is_pre_on = false;
        is_pre_description_on = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InfoUpdate(int n)
    {
        unit_index = n;
        
        //유닛
        if (n < 100)
        {
            UnitInfoUpdate(n);
        }
        //마법
        else if (n < 200)
        {
            MagicInfoUpdate(n - 100);
        }
        //버프
        else if (n < 300)
        {
            BuffInfoUpdate(n - 200);
        }
        //그뭐냐 패시브
        else
        {
            PassiveInfoUpdate(n - 300);
        }
    }

    //유닛카드 정보 업데이트
    public void UnitInfoUpdate(int n)
    {
        //레벨
        level = GameData.Instance.unit_all_list.list[n].unit_level;
        //level_text.text = level.ToString();
        
        //공격력
        attack_damage = GameData.Instance.unit_all_list.list[n].attack_damage;
        attack_damage_text.text = attack_damage.ToString();

        //체력
        health = GameData.Instance.unit_all_list.list[n].health;
        health_text.text = health.ToString();

        //방어력
        defense = GameData.Instance.unit_all_list.list[n].defense;
        defense_text.text = defense.ToString();

        //공격속도
        attack_speed = GameData.Instance.unit_all_list.list[n].attack_speed;
        attack_speed_text.text = attack_speed.ToString();

        //이동속도
        move_speed = GameData.Instance.unit_all_list.list[n].move_speed;
        move_speed_text.text = move_speed.ToString();

        //크리티컬
        critical = GameData.Instance.unit_all_list.list[n].critical_per;
        critical_text.text = critical.ToString();

        //코스트
        low_cost = GameData.Instance.unit_all_list.list[n].cost1;
        //low_cost_text.text = low_cost.ToString();

        //defense_text.text = level.ToString();

        //프리팹 정보 업데이트
        card_prefab.GetComponent<CardStatus>().StatusSetting(GameData.Instance.unit_all_list.list[n].unit_number,
                                                            GameData.Instance.unit_all_list.list[n].unit_name,
                                                            GameData.Instance.unit_all_list.list[n].population,
                                                            GameData.Instance.unit_all_list.list[n].cost1,
                                                            GameData.Instance.unit_all_list.list[n].description
                                                            );
    }

    //마법카드 정보 업데이트
    public void MagicInfoUpdate(int n)
    {
        level = GameData.Instance.magic_all_list.list[n].unit_level;
        //level_text.text = level.ToString();

        //프리팹 정보 업데이트
        card_prefab.GetComponent<CardStatus>().StatusSetting(GameData.Instance.magic_all_list.list[n].unit_number,
                                                            GameData.Instance.magic_all_list.list[n].unit_name,
                                                            GameData.Instance.magic_all_list.list[n].population,
                                                            GameData.Instance.magic_all_list.list[n].cost1,
                                                            GameData.Instance.magic_all_list.list[n].description
                                                            );
    }

    //버프카드 정보 업데이트
    public void BuffInfoUpdate(int n)
    {
        level = GameData.Instance.buff_all_list.list[n].unit_level;
        //level_text.text = level.ToString();

        //프리팹 정보 업데이트
        card_prefab.GetComponent<CardStatus>().StatusSetting(GameData.Instance.buff_all_list.list[n].unit_number,
                                                            GameData.Instance.buff_all_list.list[n].unit_name,
                                                            GameData.Instance.buff_all_list.list[n].population,
                                                            GameData.Instance.buff_all_list.list[n].cost1,
                                                            GameData.Instance.buff_all_list.list[n].description
                                                            );

    }

    //패시브카드 정보 업데이트
    public void PassiveInfoUpdate(int n)
    {
        level = GameData.Instance.passive_all_list.list[n].unit_level;
        //level_text.text = level.ToString();

        //프리팹 정보 업데이트
        card_prefab.GetComponent<CardStatus>().StatusSetting(GameData.Instance.passive_all_list.list[n].unit_number,
                                                            GameData.Instance.passive_all_list.list[n].unit_name,
                                                            GameData.Instance.passive_all_list.list[n].population,
                                                            GameData.Instance.passive_all_list.list[n].cost1,
                                                            GameData.Instance.passive_all_list.list[n].description
                                                            );
    }

    //업그레이드 미리보기 클릭
    public void PreTextChange()
    {
        if (is_pre_on == false)
        {
            //level_text.gameObject.SetActive(false);
            attack_damage_text.gameObject.SetActive(false);
            health_text.gameObject.SetActive(false);
            defense_text.gameObject.SetActive(false);
            attack_speed_text.gameObject.SetActive(false);
            move_speed_text.gameObject.SetActive(false);
            critical_text.gameObject.SetActive(false);
            //low_cost_text.gameObject.SetActive(false);

            //level_text_up.gameObject.SetActive(true);
            attack_damage_text_up.gameObject.SetActive(true);
            health_text_up.gameObject.SetActive(true);
            defense_text_up.gameObject.SetActive(true);
            attack_speed_text_up.gameObject.SetActive(true);
            move_speed_text_up.gameObject.SetActive(true);
            critical_text_up.gameObject.SetActive(true);
            //low_cost_text_up.gameObject.SetActive(true);

            is_pre_on = true;
        }
        else
        {
            //level_text.gameObject.SetActive(true);
            attack_damage_text.gameObject.SetActive(true);
            health_text.gameObject.SetActive(true);
            defense_text.gameObject.SetActive(true);
            attack_speed_text.gameObject.SetActive(true);
            move_speed_text.gameObject.SetActive(true);
            critical_text.gameObject.SetActive(true);
            //low_cost_text.gameObject.SetActive(true);

            //level_text_up.gameObject.SetActive(false);
            attack_damage_text_up.gameObject.SetActive(false);
            health_text_up.gameObject.SetActive(false);
            defense_text_up.gameObject.SetActive(false);
            attack_speed_text_up.gameObject.SetActive(false);
            move_speed_text_up.gameObject.SetActive(false);
            critical_text_up.gameObject.SetActive(false);
            //low_cost_text_up.gameObject.SetActive(false);

            is_pre_on = false;
        }


    }

    // 공격, 체력, 방어, 공속, 이속, 크리
    public void UpgradeInfo()
    {
        attack_damage_text.text = attack_damage.ToString();

        health_text.text = health.ToString();

        defense_text.text = defense.ToString();

        attack_speed_text.text = attack_speed.ToString();

        move_speed_text.text = move_speed.ToString();

        critical_text.text = critical.ToString();
    }

    public void PreUpgradeInfoUpdate(float at_damage, float heal, float defen, float at_speed, float m_speed, float cri)
    {
        attack_damage_text_up.text = at_damage.ToString();
        health_text_up.text = heal.ToString();
        defense_text_up.text = defen.ToString();
        attack_speed_text_up.text = at_speed.ToString();
        move_speed_text_up.text = m_speed.ToString();
        critical_text_up.text = cri.ToString();
    }

    //정보창 업데이트
    public void InfoDescriptionUpdate(int num)
    {
        if (num < 100)
        {
            a = (int)GameData.Instance.unit_all_list.list[num].attack_damage;
            b = (int)GameData.Instance.unit_all_list.list[num].health;
            c = (int)GameData.Instance.unit_all_list.list[num].attack_speed;
            d = (int)GameData.Instance.unit_all_list.list[num].defense;
            e = (int)GameData.Instance.unit_all_list.list[num].move_speed;
            f = (int)GameData.Instance.unit_all_list.list[num].critical_per;

            info_description = string.Format(GameData.Instance.unit_all_list.list[num].description, a, b, c, d, e, f);

            info_description_object.text = info_description;
        }
        else if (num < 200)
        {
            a = (int)GameData.Instance.magic_all_list.list[num - 100].attack_damage;
            b = (int)GameData.Instance.magic_all_list.list[num - 100].health;
            c = (int)GameData.Instance.magic_all_list.list[num - 100].attack_speed;
            d = (int)GameData.Instance.magic_all_list.list[num - 100].defense;
            e = (int)GameData.Instance.magic_all_list.list[num - 100].move_speed;
            f = (int)GameData.Instance.magic_all_list.list[num - 100].critical_per;

            info_description = string.Format(GameData.Instance.magic_all_list.list[num - 100].description, a, b, c, d, e, f);

            info_description_object.text = info_description;
        }
        else if (num < 300)
        {
            a = (int)GameData.Instance.buff_all_list.list[num - 200].attack_damage;
            b = (int)GameData.Instance.buff_all_list.list[num - 200].health;
            c = (int)GameData.Instance.buff_all_list.list[num - 200].attack_speed;
            d = (int)GameData.Instance.buff_all_list.list[num - 200].defense;
            e = (int)GameData.Instance.buff_all_list.list[num - 200].move_speed;
            f = (int)GameData.Instance.buff_all_list.list[num - 200].critical_per;

            info_description = string.Format(GameData.Instance.buff_all_list.list[num - 200].description, a, b, c, d, e, f);

            info_description_object.text = info_description;
        }
        else if (num < 400)
        {
            a = (int)GameData.Instance.passive_all_list.list[num - 300].attack_damage;
            b = (int)GameData.Instance.passive_all_list.list[num - 300].health;
            c = (int)GameData.Instance.passive_all_list.list[num - 300].attack_speed;
            d = (int)GameData.Instance.passive_all_list.list[num - 300].defense;
            e = (int)GameData.Instance.passive_all_list.list[num - 300].move_speed;
            f = (int)GameData.Instance.passive_all_list.list[num - 300].critical_per;

            info_description = string.Format(GameData.Instance.passive_all_list.list[num - 300].description, a, b, c, d, e, f);

            info_description_object.text = info_description;
        }
    }

    //정보창 미리보기 업데이트
    public void PreInfoDescriptionUpdate(int num)
    {
        if (num < 100)
        {
            pre_info_description = string.Format(GameData.Instance.unit_all_list.list[num].description, a, b, c, d, e, f);

            pre_info_description_object.text = pre_info_description;
        }
        else if (num < 200)
        {
            pre_info_description = string.Format(GameData.Instance.magic_all_list.list[num - 100].description, a, b, c, d, e, f);

            pre_info_description_object.text = pre_info_description;
        }
        else if (num < 300)
        {
            pre_info_description = string.Format(GameData.Instance.buff_all_list.list[num - 200].description, a, b, c, d, e, f);

            pre_info_description_object.text = pre_info_description;
        }
        else if (num < 400)
        {
            pre_info_description = string.Format(GameData.Instance.passive_all_list.list[num - 300].description, a, b, c, d, e, f);

            pre_info_description_object.text = pre_info_description;
        }
    }

    public void SetPre(int pa, int pb, int pc, int pd, int pe, int pf)
    {
        pre_a = pa;
        pre_b = pb;
        pre_c = pc;
        pre_d = pd;
        pre_e = pe;
        pre_f = pf;
    }

    //미리보기 설명편
    public void PreDescriptionTextChange()
    {
        if (is_pre_description_on == false)
        {
            info_description_object.gameObject.SetActive(false);

            pre_info_description_object.gameObject.SetActive(true);


            is_pre_description_on = true;
        }
        else
        {
            info_description_object.gameObject.SetActive(true);

            pre_info_description_object.gameObject.SetActive(false);

            is_pre_description_on = false;
        }
    }
}
