using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradePanel : MonoBehaviour
{
    //레벨
    public Text pre_level_text;
    public Text next_level_text;

    //이름
    public TextMeshProUGUI name_text;

    //스탯 전
    public Text pre_attack_damage_text;
    public Text pre_health_text;
    public Text pre_attack_speed_text;
    public Text pre_defense_text;
    public Text pre_move_speed_text;
    public Text pre_critical_text;

    //스탯 후
    public Text next_attack_damage_text;
    public Text next_health_text;
    public Text next_attack_speed_text;
    public Text next_defense_text;
    public Text next_move_speed_text;
    public Text next_critical_text;

    //마법 설명 전, 후
    public Text pre_description_text;
    public Text next_description_text;

    //각종 이미지 모음
    public GameObject unit_image_parent;
    public GameObject magic_image_parent;
    public GameObject buff_image_parent;
    public GameObject passive_image_parent;

    //이미지
    public Image upgrade_image;

    UnitNumberData panel_card_data;


    void Awake()
    {
        unit_image_parent = GameObject.FindGameObjectWithTag("UnitImageParent").gameObject;
        magic_image_parent = GameObject.FindGameObjectWithTag("MagicImageParent").gameObject;
        buff_image_parent = GameObject.FindGameObjectWithTag("BuffImageParent").gameObject;
        passive_image_parent = GameObject.FindGameObjectWithTag("PassiveImageParent").gameObject;
    }

    //유닛 업글용
    public void UnitUpgradePanelUpdate(int num)
    {

        panel_card_data = GameData.Instance.unit_all_list.list[num];

        name_text.text = panel_card_data.unit_name;

        pre_level_text.text = "LV " + (panel_card_data.unit_level - 1).ToString();
        next_level_text.text = "LV " + panel_card_data.unit_level.ToString();

        pre_attack_damage_text.text = panel_card_data.attack_damage.ToString();
        pre_health_text.text = panel_card_data.health.ToString();
        pre_attack_speed_text.text = panel_card_data.attack_speed.ToString();
        pre_defense_text.text = panel_card_data.defense.ToString();
        pre_move_speed_text.text = panel_card_data.move_speed.ToString();
        pre_critical_text.text = panel_card_data.critical_per.ToString();

        ImageChange(num);
    }

    public void GetNextStatus(float a_damage, float hp, float a_speed, float defens, float m_speed, float cri)
    {
        next_attack_damage_text.text = a_damage.ToString();
        next_health_text.text = hp.ToString();
        next_attack_speed_text.text = a_speed.ToString();
        next_defense_text.text = defens.ToString();
        next_move_speed_text.text = m_speed.ToString();
        next_critical_text.text = cri.ToString();
    }

    //마법 버프 패시브 업그레이드용
    public void MagicUpgradePanelUpdate(int num)
    {
        if (num < 100)
        {

        }
        else if (num < 200)
        {
            panel_card_data = GameData.Instance.magic_all_list.list[num - 100];
            pre_description_text.text = string.Format(GameData.Instance.magic_all_list.list[num - 100].description, (int)panel_card_data.attack_damage,
                (int)panel_card_data.health, (int)panel_card_data.attack_speed, (int)panel_card_data.defense, (int)panel_card_data.move_speed, (int)panel_card_data.critical_per);
        }
        else if (num < 300)
        {
            panel_card_data = GameData.Instance.buff_all_list.list[num - 200];
            pre_description_text.text = string.Format(GameData.Instance.buff_all_list.list[num - 200].description, (int)panel_card_data.attack_damage,
                (int)panel_card_data.health, (int)panel_card_data.attack_speed, (int)panel_card_data.defense, (int)panel_card_data.move_speed, (int)panel_card_data.critical_per);
        }
        else if (num < 400)
        {
            panel_card_data = GameData.Instance.passive_all_list.list[num - 300];
            pre_description_text.text = string.Format(GameData.Instance.passive_all_list.list[num - 300].description, (int)panel_card_data.attack_damage,
                (int)panel_card_data.health, (int)panel_card_data.attack_speed, (int)panel_card_data.defense, (int)panel_card_data.move_speed, (int)panel_card_data.critical_per);
        }

        name_text.text = panel_card_data.unit_name;

        pre_level_text.text = "LV " + (panel_card_data.unit_level - 1).ToString();
        next_level_text.text = "LV " + panel_card_data.unit_level.ToString();

        ImageChange(num);
    }

    public void GetNextDescription(int num, int a_damage, int hp, int a_speed, int defens, int m_speed, int cri)
    {
        if (num < 100)
        {

        }
        else if (num < 200)
        {
            next_description_text.text = string.Format(GameData.Instance.magic_all_list.list[num - 100].description, a_damage, hp, a_speed, defens, m_speed, cri);
        }
        else if (num < 300)
        {
            next_description_text.text = string.Format(GameData.Instance.buff_all_list.list[num - 200].description, a_damage, hp, a_speed, defens, m_speed, cri);
        }
        else if (num < 400)
        {
            next_description_text.text = string.Format(GameData.Instance.passive_all_list.list[num - 300].description, a_damage, hp, a_speed, defens, m_speed, cri);
        }
    }

    public void ImageChange(int num)
    {
        if (num < 100)
        {
            upgrade_image.sprite = unit_image_parent.transform.GetChild(num).GetComponent<SpriteRenderer>().sprite;
        }
        else if (num < 200)
        {
            upgrade_image.sprite = magic_image_parent.transform.GetChild(num - 100).GetComponent<SpriteRenderer>().sprite;
        }
        else if (num < 300)
        {
            upgrade_image.sprite = buff_image_parent.transform.GetChild(num - 200).GetComponent<SpriteRenderer>().sprite;
        }
        else if (num < 400)
        {
            upgrade_image.sprite = passive_image_parent.transform.GetChild(num - 300).GetComponent<SpriteRenderer>().sprite;
        }
    }
}
