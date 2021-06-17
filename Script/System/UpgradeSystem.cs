using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public int num;

    //그냥 여기서 유닛정보도 같이 관리하자
    public GameObject info_object;

    public GameObject info_card;
    Image unit_image;
    Image card_image;

    GameObject unit_image_parent;
    GameObject magic_image_parent;
    GameObject buff_image_parent;
    GameObject passive_image_parent;

    GameObject card_image_parent;

    

    public float pre_attack_damage;
    public float pre_health;
    public float pre_defense;
    public float pre_attack_speed;
    public float pre_move_speed;
    public float pre_critical;
    public float pre_cost;

    //미리보기 계산용
    int pre_a;
    int pre_b;
    int pre_c;
    int pre_d;
    int pre_e;
    int pre_f;

    //업그레이드 패널 (유닛 / 마법)
    public GameObject unit_upgrade_panel;
    public GameObject magic_upgrade_panel;

    public GameObject deck_data;


    // Start is called before the first frame update
    void Start()
    {
        unit_image = info_card.transform.GetChild(1).GetComponent<Image>();
        card_image = info_card.transform.GetChild(2).GetComponent<Image>();

        unit_image_parent = GameObject.FindGameObjectWithTag("UnitImageParent");
        magic_image_parent = GameObject.FindGameObjectWithTag("MagicImageParent");
        buff_image_parent = GameObject.FindGameObjectWithTag("BuffImageParent");
        passive_image_parent = GameObject.FindGameObjectWithTag("PassiveImageParent");

        card_image_parent = GameObject.FindGameObjectWithTag("CardImageParent");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickUnit()
    {
        //클릭한 버튼의 name을 int형으로 변환
        num = int.Parse(EventSystem.current.currentSelectedGameObject.name);

        info_object.GetComponent<UnitInfo>().InfoUpdate(num);
        info_object.GetComponent<UnitInfo>().InfoDescriptionUpdate(num);
        CardImageChange(num);
        PreUpgrade(num);
    }

    public void Upgrade()
    {
        //유닛
        if (num < 100)
        {
            if (GameData.Instance.unit_all_list.list[num].grade == 0)
            {
                if (GameData.Instance.unit_all_list.list[num].unit_level == 1)
                {
                    if (GameData.Instance.basic_data.account_gold < 1000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.basic_data.account_gold -= 1000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 2)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 2 || GameData.Instance.basic_data.account_gold < 1000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 1000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 3)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 4 || GameData.Instance.basic_data.account_gold < 2500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 2500;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 4)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 10 || GameData.Instance.basic_data.account_gold < 7500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 7500;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 5)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 20 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 6)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 50 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 50;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 7)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 100 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 100;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 8)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 200 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 200;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 9)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 400 || GameData.Instance.basic_data.account_gold < 400000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 400;
                        GameData.Instance.basic_data.account_gold -= 400000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
            else if (GameData.Instance.unit_all_list.list[num].grade == 1)
            {
                if (GameData.Instance.unit_all_list.list[num].unit_level == 1)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 2 || GameData.Instance.basic_data.account_gold < 2500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 2500;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 2)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 4 || GameData.Instance.basic_data.account_gold < 7500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 7500;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 3)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 10 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 4)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 20 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 5)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 50 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 50;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 6)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 100 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 100;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 7)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 200 || GameData.Instance.basic_data.account_gold < 400000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 200;
                        GameData.Instance.basic_data.account_gold -= 400000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
            else if (GameData.Instance.unit_all_list.list[num].grade == 2)
            {
                if (GameData.Instance.unit_all_list.list[num].unit_level == 1)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 2 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 2)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 4 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 3)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 10 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].unit_level == 4)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_count < 20 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.unit_all_list.list[num].unit_level += 1;
                        GameData.Instance.unit_all_list.list[num].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        UnitUpgrade(num, GameData.Instance.unit_all_list.list[num].type);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
        }
        //마법
        else if (num < 200)
        {
            if (GameData.Instance.magic_all_list.list[num - 100].grade == 0)
            {
                if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 1)
                {
                    if (GameData.Instance.basic_data.account_gold < 1000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.basic_data.account_gold -= 1000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 2)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 2 || GameData.Instance.basic_data.account_gold < 1000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 1000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 3)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 4 || GameData.Instance.basic_data.account_gold < 2500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 2500;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 4)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 10 || GameData.Instance.basic_data.account_gold < 7500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 7500;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 5)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 20 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 6)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 50 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 50;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 7)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 100 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 100;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 8)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 200 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 200;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 9)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 400 || GameData.Instance.basic_data.account_gold < 400000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 400;
                        GameData.Instance.basic_data.account_gold -= 400000;
                        MagicUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
            else if (GameData.Instance.magic_all_list.list[num - 100].grade == 1)
            {
                if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 1)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 2 || GameData.Instance.basic_data.account_gold < 2500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 2500;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 2)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 4 || GameData.Instance.basic_data.account_gold < 7500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 7500;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 3)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 10 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 4)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 20 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 5)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 50 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 50;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 6)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 100 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 100;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 7)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 200 || GameData.Instance.basic_data.account_gold < 400000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 200;
                        GameData.Instance.basic_data.account_gold -= 400000;
                        MagicUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
            else if (GameData.Instance.magic_all_list.list[num - 100].grade == 2)
            {
                if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 1)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 2 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 2)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 4 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 3)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 10 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        MagicUpgrade(num);
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 4)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_count < 20 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.magic_all_list.list[num - 100].unit_level += 1;
                        GameData.Instance.magic_all_list.list[num - 100].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        MagicUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
        }
        //버프
        else if (num < 300)
        {
            if (GameData.Instance.buff_all_list.list[num - 200].grade == 0)
            {
                if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 1)
                {
                    if (GameData.Instance.basic_data.account_gold < 1000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.basic_data.account_gold -= 1000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 2)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 2 || GameData.Instance.basic_data.account_gold < 1000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 1000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 3)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 4 || GameData.Instance.basic_data.account_gold < 2500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 2500;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 4)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 10 || GameData.Instance.basic_data.account_gold < 7500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 7500;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 5)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 20 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 6)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 50 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 50;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 7)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 100 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 100;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 8)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 200 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 200;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 9)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 400 || GameData.Instance.basic_data.account_gold < 400000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 400;
                        GameData.Instance.basic_data.account_gold -= 400000;
                        BuffUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
            else if (GameData.Instance.buff_all_list.list[num - 200].grade == 1)
            {
                if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 1)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 2 || GameData.Instance.basic_data.account_gold < 2500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 2500;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 2)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 4 || GameData.Instance.basic_data.account_gold < 7500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 7500;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 3)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 10 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 4)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 20 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 5)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 50 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 50;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 6)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 100 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 100;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 7)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 200 || GameData.Instance.basic_data.account_gold < 400000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 200;
                        GameData.Instance.basic_data.account_gold -= 400000;
                        BuffUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
            else if (GameData.Instance.buff_all_list.list[num - 200].grade == 2)
            {
                if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 1)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 2 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 2)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 4 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 3)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 10 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        BuffUpgrade(num);
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 4)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_count < 20 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.buff_all_list.list[num - 200].unit_level += 1;
                        GameData.Instance.buff_all_list.list[num - 200].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        BuffUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
        }
        //패시브
        else
        {
            if (GameData.Instance.passive_all_list.list[num - 300].grade == 0)
            {
                if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 1)
                {
                    if (GameData.Instance.basic_data.account_gold < 1000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.basic_data.account_gold -= 1000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 2)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 2 || GameData.Instance.basic_data.account_gold < 1000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 1000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 3)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 4 || GameData.Instance.basic_data.account_gold < 2500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 2500;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 4)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 10 || GameData.Instance.basic_data.account_gold < 7500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 7500;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 5)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 20 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 6)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 50 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 50;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 7)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 100 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 100;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 8)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 200 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 200;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 9)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 400 || GameData.Instance.basic_data.account_gold < 400000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 400;
                        GameData.Instance.basic_data.account_gold -= 400000;
                        PassiveUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
            else if (GameData.Instance.passive_all_list.list[num - 300].grade == 1)
            {
                if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 1)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 2 || GameData.Instance.basic_data.account_gold < 2500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 2500;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 2)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 4 || GameData.Instance.basic_data.account_gold < 7500)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 7500;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 3)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 10 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 4)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 20 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 5)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 50 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 50;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 6)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 100 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 100;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 7)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 200 || GameData.Instance.basic_data.account_gold < 400000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 200;
                        GameData.Instance.basic_data.account_gold -= 400000;
                        PassiveUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
            else if (GameData.Instance.passive_all_list.list[num - 300].grade == 2)
            {
                if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 1)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 2 || GameData.Instance.basic_data.account_gold < 20000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 2;
                        GameData.Instance.basic_data.account_gold -= 20000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 2)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 4 || GameData.Instance.basic_data.account_gold < 50000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 4;
                        GameData.Instance.basic_data.account_gold -= 50000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 3)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 10 || GameData.Instance.basic_data.account_gold < 100000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 10;
                        GameData.Instance.basic_data.account_gold -= 100000;
                        PassiveUpgrade(num);
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 4)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_count < 20 || GameData.Instance.basic_data.account_gold < 200000)
                    {
                        //부족
                    }
                    else
                    {
                        //레벨업
                        GameData.Instance.passive_all_list.list[num - 300].unit_level += 1;
                        GameData.Instance.passive_all_list.list[num - 300].unit_count -= 20;
                        GameData.Instance.basic_data.account_gold -= 200000;
                        PassiveUpgrade(num);
                    }
                }
                else
                {
                    //최대레벨 or 버그
                }
            }
        }
    }

    //유닛 업그레이드
    void UnitUpgrade(int n, int type)
    {
        unit_upgrade_panel.SetActive(true);
        unit_upgrade_panel.GetComponent<UpgradePanel>().UnitUpgradePanelUpdate(n);
        unit_upgrade_panel.GetComponent<UpgradePanel>().GetNextStatus(pre_attack_damage, pre_health, pre_attack_speed, pre_defense, pre_move_speed, pre_critical);

        // 0. 원거리, 1. 근거리, 2. 탱커, 3. 딜탱, 4. 공속딜러, 5. 치명타딜러

        if (type == 0)
        {
            RangeUnitUpgrade(n);
        }
        else if (type == 1)
        {
            MeleeUnitUpgrade(n);
        }
        else if (type == 2)
        {
            TankingUnitUpgrade(n);
        }
        else if (type == 3)
        {
            DealTangUnitUpgrade(n);
        }
        else if (type == 4)
        {
            AttackSpeedUnitUpgrade(n);
        }
        else if (type == 5)
        {
            CriticalUnitUpgrade(n);
        }

        SliderUpdate();
    }

    //마법 업그레이드
    void MagicUpgrade(int n)
    {
        // 0. 
        if (n == 100)
        {
            //101번 욕망의 당근
            Magic101Upgrade(n);
        }
        else if (n == 101)
        {
            Magic102Upgrade(n);
        }
        else if (n == 102)
        {
            Magic103Upgrade(n);
        }
        else if (n == 103)
        {
            Magic104Upgrade(n);
        }
        else if (n == 104)
        {
            Magic105Upgrade(n);
        }
        else if (n == 105)
        {
            Magic106Upgrade(n);
        }
        else if (n == 106)
        {
            Magic107Upgrade(n);
        }
        else if (n == 107)
        {
            Magic108Upgrade(n);
        }
        else if (n == 108)
        {
            Magic109Upgrade(n);
        }
        else if (n == 109)
        {
            Magic110Upgrade(n);
        }
        else if (n == 110)
        {
            Magic111Upgrade(n);
        }
        else if (n == 111)
        {
            Magic112Upgrade(n);
        }
        else if (n == 112)
        {
            Magic113Upgrade(n);
        }
        else if (n == 113)
        {
            Magic114Upgrade(n);
        }
        else if (n == 114)
        {
            Magic115Upgrade(n);
        }
        else if (n == 115)
        {
            Magic116Upgrade(n);
        }
        else if (n == 116)
        {
            Magic117Upgrade(n);
        }
        else if (n == 117)
        {
            Magic118Upgrade(n);
        }
        else if (n == 118)
        {
            Magic119Upgrade(n);
        }
        else if (n == 119)
        {
            Magic120Upgrade(n);
        }

        magic_upgrade_panel.SetActive(true);
        magic_upgrade_panel.GetComponent<UpgradePanel>().MagicUpgradePanelUpdate(n);
        magic_upgrade_panel.GetComponent<UpgradePanel>().GetNextDescription(n, pre_a, pre_b, pre_c, pre_d, pre_e, pre_f);

        SliderUpdate();
    }

    //버프 업그레이드
    void BuffUpgrade(int n)
    {
        // 0. 
        if (n == 100)
        {
            Buff201Upgrade(n);
        }
        else if (n == 101)
        {
            Buff202Upgrade(n);
        }
        else if (n == 102)
        {
            Buff203Upgrade(n);
        }
        else if (n == 103)
        {
            Buff204Upgrade(n);
        }
        else if (n == 104)
        {
            Buff205Upgrade(n);
        }
        else if (n == 105)
        {
            Buff206Upgrade(n);
        }
        else if (n == 106)
        {
            Buff207Upgrade(n);
        }
        else if (n == 107)
        {
            Buff208Upgrade(n);
        }
        else if (n == 108)
        {
            Buff209Upgrade(n);
        }
        else if (n == 109)
        {
            Buff210Upgrade(n);
        }
        else if (n == 110)
        {
            Buff211Upgrade(n);
        }
        else if (n == 111)
        {
            Buff212Upgrade(n);
        }

        magic_upgrade_panel.SetActive(true);
        magic_upgrade_panel.GetComponent<UpgradePanel>().MagicUpgradePanelUpdate(n);
        magic_upgrade_panel.GetComponent<UpgradePanel>().GetNextDescription(n, pre_a, pre_b, pre_c, pre_d, pre_e, pre_f);

        SliderUpdate();
    }

    //패시브 업그레이드
    void PassiveUpgrade(int n)
    {
        // 0. 
        if (n == 100)
        {
            //101번 욕망의 당근
            Passive301Upgrade(n);
        }
        else if (n == 101)
        {
            Passive302Upgrade(n);
        }
        else if (n == 102)
        {
            Passive303Upgrade(n);
        }
        else if (n == 103)
        {
            Passive304Upgrade(n);
        }
        else if (n == 104)
        {
            Passive305Upgrade(n);
        }
        else if (n == 105)
        {
            Passive306Upgrade(n);
        }
        else if (n == 106)
        {
            Passive307Upgrade(n);
        }
        else if (n == 107)
        {
            Passive308Upgrade(n);
        }
        else if (n == 108)
        {
            Passive309Upgrade(n);
        }

        magic_upgrade_panel.SetActive(true);
        magic_upgrade_panel.GetComponent<UpgradePanel>().MagicUpgradePanelUpdate(n);
        magic_upgrade_panel.GetComponent<UpgradePanel>().GetNextDescription(n, pre_a, pre_b, pre_c, pre_d, pre_e, pre_f);

        SliderUpdate();
    }


    //업그레이드 클릭시
    //유닛
    void RangeUnitUpgrade(int n)
    {
        //공격력 증가 10%
        GameData.Instance.unit_all_list.list[n].attack_damage *= 1.1f;

        //체력 증가 10%
        GameData.Instance.unit_all_list.list[n].health *= 1.1f;

        //공격속도 증가 3%
        GameData.Instance.unit_all_list.list[n].attack_speed *= 1.03f;

        //코스트 증가 10%
        GameData.Instance.unit_all_list.list[n].cost1 = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void MeleeUnitUpgrade(int n)
    {
        //공격력 증가 15%
        GameData.Instance.unit_all_list.list[n].attack_damage *= 1.15f;

        //체력 증가 5%
        GameData.Instance.unit_all_list.list[n].health *= 1.05f;

        //공격속도 증가 5%
        GameData.Instance.unit_all_list.list[n].attack_speed *= 1.05f;

        //코스트 증가 10%
        GameData.Instance.unit_all_list.list[n].cost1 = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void TankingUnitUpgrade(int n)
    {
        //공격력 증가 5%
        GameData.Instance.unit_all_list.list[n].attack_damage *= 1.05f;

        //체력 증가 15%
        GameData.Instance.unit_all_list.list[n].health *= 1.15f;

        //공격속도 증가 3%
        GameData.Instance.unit_all_list.list[n].attack_speed *= 1.03f;

        //코스트 증가 10%
        GameData.Instance.unit_all_list.list[n].cost1 = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void DealTangUnitUpgrade(int n)
    {
        //공격력 증가 10%
        GameData.Instance.unit_all_list.list[n].attack_damage *= 1.1f;

        //체력 증가 10%
        GameData.Instance.unit_all_list.list[n].health *= 1.1f;

        //공격속도 증가 3%
        GameData.Instance.unit_all_list.list[n].attack_speed *= 1.03f;

        //코스트 증가 10%
        GameData.Instance.unit_all_list.list[n].cost1 = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void AttackSpeedUnitUpgrade(int n)
    {
        //공격력 증가 5%
        GameData.Instance.unit_all_list.list[n].attack_damage *= 1.05f;

        //체력 증가 5%
        GameData.Instance.unit_all_list.list[n].health *= 1.05f;

        //공격속도 증가 15%
        GameData.Instance.unit_all_list.list[n].attack_speed *= 1.15f;

        //코스트 증가 10%
        GameData.Instance.unit_all_list.list[n].cost1 = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void CriticalUnitUpgrade(int n)
    {
        //공격력 증가 5%
        GameData.Instance.unit_all_list.list[n].attack_damage *= 1.15f;

        //체력 증가 5%
        GameData.Instance.unit_all_list.list[n].health *= 1.05f;

        //공격속도 증가 5%
        GameData.Instance.unit_all_list.list[n].attack_speed *= 1.05f;

        //치명타 증가 5%
        GameData.Instance.unit_all_list.list[n].critical_per += 5;

        //코스트 증가 10%
        GameData.Instance.unit_all_list.list[n].cost1 = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    //마법
    //1번효과 = attack_damage, 2번효과 = health, 3번효과 = attack_speed, 4번효과 = defense, 5번효과 = move_speed, 6번효과 = critical
    //욕망의 당근
    void Magic101Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //일정 구간마다 뽑는카드 증가
        if (GameData.Instance.magic_all_list.list[n - 100].unit_level == 3)
        {
            GameData.Instance.magic_all_list.list[n - 100].attack_damage += 1;
        }
        else if (GameData.Instance.magic_all_list.list[n - 100].unit_level == 6)
        {
            GameData.Instance.magic_all_list.list[n - 100].attack_damage += 1;
        }
        else if (GameData.Instance.magic_all_list.list[n - 100].unit_level == 9)
        {
            GameData.Instance.magic_all_list.list[n - 100].attack_damage += 1;
        }
    }

    //리로드
    void Magic102Upgrade(int n)
    {
        //코스트 -3
        GameData.Instance.unit_all_list.list[n - 100].cost1 -= 3;
    }

    //맥가이버 패키지
    void Magic103Upgrade(int n)
    {

    }

    //천재지변 패키지
    void Magic104Upgrade(int n)
    {

    }

    //폭풍 레벨업 패키지
    void Magic105Upgrade(int n)
    {

    }

    //두근두근 슬롯머신
    void Magic106Upgrade(int n)
    {
        //코스트 -4
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 0.95f);
    }

    //긴급 출동 패밀리
    void Magic107Upgrade(int n)
    {
        //코스트 증가 10%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //소환 유닛 수
        GameData.Instance.magic_all_list.list[n - 100].attack_damage += 1;
    }

    //약탈
    void Magic108Upgrade(int n)
    {
        //코스트 증가 10%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);

        //미네랄 약탈 증가 20%
        GameData.Instance.magic_all_list.list[n - 100].health = (int)(GameData.Instance.magic_all_list.list[n - 100].health * 1.2f);
    }

    //피버타임
    void Magic109Upgrade(int n)
    {
        //코스트 증가 10%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.1f);

        //미네랄 증가 +5
        GameData.Instance.magic_all_list.list[n - 100].health += 5;
    }

    //뽑기의 달인
    void Magic110Upgrade(int n)
    {
        //코스트 증가 10%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.1f);

        //노말 유닛 확률 감소 -5
        GameData.Instance.magic_all_list.list[n - 100].attack_damage -= 5;

        //레어 유닛 확률 증가 +3
        GameData.Instance.magic_all_list.list[n - 100].health += 3;

        //스페셜 유닛 확률 증가 +2
        GameData.Instance.magic_all_list.list[n - 100].attack_speed += 2;
    }

    //유기농 당근
    void Magic111Upgrade(int n)
    {
        //미네랄 획득 증가 10%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.1f);
    }

    //대규모 광부 채용
    void Magic112Upgrade(int n)
    {
        //코스트 증가 10%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.1f);

        //이동속도 증가 +1%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage += 1;

        //광부 수 증가 +1
        GameData.Instance.magic_all_list.list[n - 100].attack_speed += 1;
    }

    //소나기(미스포차)
    void Magic113Upgrade(int n)
    {
        //코스트 증가 10%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);

        //이동속도 감소 10%
        GameData.Instance.magic_all_list.list[n - 100].health = (int)(GameData.Instance.magic_all_list.list[n - 100].health * 1.1f);

    }

    //날벼락
    void Magic114Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);

        //공격속도 감소량 증가 10%
        GameData.Instance.magic_all_list.list[n - 100].health = (int)(GameData.Instance.magic_all_list.list[n - 100].health * 1.1f);
    }

    //대폭발 (폭주기관차)
    void Magic115Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 40%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.4f);
    }

    //당근폭탄 (양자폭탄)
    void Magic116Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);

        //초당 화상 데미지 증가 20%
        GameData.Instance.magic_all_list.list[n - 100].health = (int)(GameData.Instance.magic_all_list.list[n - 100].health * 1.2f);
    }

    //전염병
    void Magic117Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 20%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.2f);
    }

    //폭탄 토끼
    void Magic118Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);
    }

    //독 안개
    void Magic119Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 20%
        GameData.Instance.magic_all_list.list[n - 100].attack_damage = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.2f);
    }

    //프렌드 실드
    void Magic120Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //체력 증가 +50
        GameData.Instance.magic_all_list.list[n - 100].attack_damage += 50;

        //지속시간 증가 +1
        GameData.Instance.magic_all_list.list[n - 100].health += 1;
    }


    //버프
    //긴급 수혈
    void Buff201Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //회복량 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 5;
    }

    //치얼스
    void Buff202Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //공격력 버프량 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 5;
    }

    //금광 발견
    void Buff203Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //이동속도 버프량 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 5;
    }

    //해체쇼
    void Buff204Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 5;
    }

    //토끼 수집가
    void Buff205Upgrade(int n)
    {
        //코스트 증가 8%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.08f);

        //미네랄 획득량 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 5;
    }

    //광전사
    void Buff206Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //공격력 버프 증가 +10
        GameData.Instance.buff_all_list.list[n - 200].attack_speed += 10;

        //공격속도 버프 증가 +10
        GameData.Instance.buff_all_list.list[n - 200].defense += 10;
    }

    //행운의 포춘쿠키
    void Buff207Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //성공확률 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 5;
    }

    //단단한 피부
    void Buff208Upgrade(int n)
    {

    }

    //미니언의 분노
    void Buff209Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //미니언 공격력 버프 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 5;

        //미니언 체력 버프 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].health += 5;
    }

    //천사의 선율 (치유토템)
    void Buff210Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //초당 체력 회복량 증가 +1
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 1;
    }

    //태엽 감기 (헤이스트)
    void Buff211Upgrade(int n)
    {
        //코스트 증가 5%
        GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //공격속도 버프 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].attack_damage += 5;

        //이동속도 버프 증가 +5
        GameData.Instance.buff_all_list.list[n - 200].health += 5;
    }

    //너만믿는다
    void Buff212Upgrade(int n)
    {

    }


    //패시브
    //풍성한 돈다발
    void Passive301Upgrade(int n)
    {
        //획득 골드 증가 +5
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 5;
    }

    //단단한 철방패
    void Passive302Upgrade(int n)
    {
        //아군유닛 체력 증가 +50
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 50;
    }

    //신속의 장화
    void Passive303Upgrade(int n)
    {
        //이동속도 증가 +1
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 1;
    }

    //인첸트 소드
    void Passive304Upgrade(int n)
    {
        //레어유닛 데미지 증가 +5
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 5;
    }

    //피칠갑 단도
    void Passive305Upgrade(int n)
    {
        //아군유닛 흡혈량 증가 +2
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 2;
    }

    //금지된 마도서
    void Passive306Upgrade(int n)
    {
        //마법카드 공격력 증가 +5
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 5;
    }

    //대장군 언월도
    void Passive307Upgrade(int n)
    {
        //아군 유닛 공격력 증가 +10
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 10;
    }

    //바람의 창
    void Passive308Upgrade(int n)
    {
        //아군 유닛 공격속도 증가 +10
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 10;
    }

    //도박꾼의 카드
    void Passive309Upgrade(int n)
    {
        //카드 드로우시 한번 더 뽑을확률 증가 +10
        GameData.Instance.passive_all_list.list[n - 300].attack_damage += 10;
    }

    //카드 이미지 변경
    public void CardImageChange(int number)
    {
        if (number < 100)
        {
            unit_image.sprite = unit_image_parent.transform.GetChild(number).GetComponent<SpriteRenderer>().sprite;

            if (GameData.Instance.unit_all_list.list[number].grade == 0)
            {
                card_image.sprite = card_image_parent.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            }
            else if (GameData.Instance.unit_all_list.list[number].grade == 1)
            {
                card_image.sprite = card_image_parent.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
            }
            else if (GameData.Instance.unit_all_list.list[number].grade == 2)
            {
                card_image.sprite = card_image_parent.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
            }
        }
        else if (number < 200)
        {
            unit_image.sprite = magic_image_parent.transform.GetChild(number - 100).GetComponent<SpriteRenderer>().sprite;

            if (GameData.Instance.magic_all_list.list[number - 100].grade == 0)
            {
                card_image.sprite = card_image_parent.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite;
            }
            else if (GameData.Instance.magic_all_list.list[number - 100].grade == 1)
            {
                card_image.sprite = card_image_parent.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite;
            }
            else if (GameData.Instance.magic_all_list.list[number - 100].grade == 2)
            {
                card_image.sprite = card_image_parent.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite;
            }
        }
        else if (number < 300)
        {
            unit_image.sprite = buff_image_parent.transform.GetChild(number - 200).GetComponent<SpriteRenderer>().sprite;

            if (GameData.Instance.buff_all_list.list[number - 200].grade == 0)
            {
                card_image.sprite = card_image_parent.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite;
            }
            else if (GameData.Instance.buff_all_list.list[number - 200].grade == 1)
            {
                card_image.sprite = card_image_parent.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite;
            }
            else if (GameData.Instance.buff_all_list.list[number - 200].grade == 2)
            {
                card_image.sprite = card_image_parent.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite;
            }
        }
        else if (number < 400)
        {
            unit_image.sprite = passive_image_parent.transform.GetChild(number - 300).GetComponent<SpriteRenderer>().sprite;

            if (GameData.Instance.passive_all_list.list[number - 300].grade == 0)
            {
                card_image.sprite = card_image_parent.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite;
            }
            else if (GameData.Instance.passive_all_list.list[number - 300].grade == 1)
            {
                card_image.sprite = card_image_parent.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite;
            }
            else if (GameData.Instance.passive_all_list.list[number - 300].grade == 2)
            {
                card_image.sprite = card_image_parent.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    public void PreUpgrade(int n)
    {
        //유닛?
        if (n < 100) 
        {
            if (GameData.Instance.unit_all_list.list[n].grade == 0)
            {
                if (GameData.Instance.unit_all_list.list[n].unit_level < 10)
                {
                    //타입?
                    UnitPreUpgrade(n, GameData.Instance.unit_all_list.list[n].type);
                }
                else
                {

                }
            }
            else if (GameData.Instance.unit_all_list.list[n].grade == 1)
            {
                if (GameData.Instance.unit_all_list.list[n].unit_level < 8)
                {
                    //타입?
                    UnitPreUpgrade(n, GameData.Instance.unit_all_list.list[n].type);
                }
                else
                {

                }
            }
            else if (GameData.Instance.unit_all_list.list[n].grade == 2)
            {
                if (GameData.Instance.unit_all_list.list[n].unit_level < 5)
                {
                    //타입?
                    UnitPreUpgrade(n, GameData.Instance.unit_all_list.list[n].type);
                }
                else
                {

                }
            }
        }
        //마법?
        else if (n < 200)
        {
            if (GameData.Instance.magic_all_list.list[n - 100].grade == 0)
            {
                if (GameData.Instance.magic_all_list.list[n - 100].unit_level < 10)
                {
                    //타입?
                    MagicPreUpgrade(n);
                }
                else
                {

                }
            }
            else if (GameData.Instance.magic_all_list.list[n - 100].grade == 1)
            {
                if (GameData.Instance.magic_all_list.list[n - 100].unit_level < 8)
                {
                    //타입?
                    MagicPreUpgrade(n);
                }
                else
                {

                }
            }
            else if (GameData.Instance.magic_all_list.list[n - 100].grade == 2)
            {
                if (GameData.Instance.magic_all_list.list[n - 100].unit_level < 5)
                {
                    //타입?
                    MagicPreUpgrade(n);
                }
                else
                {

                }
            }
        }
        //버프?
        else if (n < 300)
        {
            if (GameData.Instance.buff_all_list.list[n - 200].grade == 0)
            {
                if (GameData.Instance.buff_all_list.list[n - 200].unit_level < 10)
                {
                    //타입?
                    BuffPreUpgrade(n);
                }
                else
                {

                }
            }
            else if (GameData.Instance.buff_all_list.list[n - 200].grade == 1)
            {
                if (GameData.Instance.buff_all_list.list[n - 200].unit_level < 8)
                {
                    //타입?
                    BuffPreUpgrade(n);
                }
                else
                {

                }
            }
            else if (GameData.Instance.buff_all_list.list[n - 200].grade == 2)
            {
                if (GameData.Instance.buff_all_list.list[n - 200].unit_level < 5)
                {
                    //타입?
                    BuffPreUpgrade(n);
                }
                else
                {

                }
            }
        }
        //패시브?
        else
        {
            if (GameData.Instance.passive_all_list.list[n - 300].grade == 0)
            {
                if (GameData.Instance.passive_all_list.list[n - 300].unit_level < 10)
                {
                    //타입?
                    PassivePreUpgrade(n);
                }
                else
                {

                }
            }
            else if (GameData.Instance.passive_all_list.list[n - 300].grade == 1)
            {
                if (GameData.Instance.passive_all_list.list[n - 300].unit_level < 8)
                {
                    //타입?
                    PassivePreUpgrade(n);
                }
                else
                {

                }
            }
            else if (GameData.Instance.passive_all_list.list[n - 300].grade == 2)
            {
                if (GameData.Instance.passive_all_list.list[n - 300].unit_level < 5)
                {
                    //타입?
                    PassivePreUpgrade(n);
                }
                else
                {

                }
            }
        }
        if (n >= 100)
        {
            info_object.GetComponent<UnitInfo>().SetPre(pre_a, pre_b, pre_c, pre_d, pre_e, pre_f);
        }
    }

    //유닛 미리보기 업그레이드
    void UnitPreUpgrade(int n, int type)
    {
        // 0. 원거리, 1. 근거리, 2. 탱커, 3. 딜탱, 4. 공속딜러, 5. 치명타딜러

        if (type == 0)
        {
            PreRangeUnitUpgrade(n);
        }
        else if (type == 1)
        {
            PreMeleeUnitUpgrade(n);
        }
        else if (type == 2)
        {
            PreTankingUnitUpgrade(n);
        }
        else if (type == 3)
        {
            PreDealTangUnitUpgrade(n);
        }
        else if (type == 4)
        {
            PreAttackSpeedUnitUpgrade(n);
        }
        else if (type == 5)
        {
            PreCriticalUnitUpgrade(n);
        }


        info_object.GetComponent<UnitInfo>().PreUpgradeInfoUpdate(pre_attack_damage, pre_health, pre_defense, pre_attack_speed, pre_move_speed, pre_critical);
    }

    //마법 미리보기 업그레이드
    public void MagicPreUpgrade(int n)
    {
        // pre 변수들 초기화
        pre_a = (int)GameData.Instance.magic_all_list.list[n - 100].attack_damage;
        pre_b = (int)GameData.Instance.magic_all_list.list[n - 100].health;
        pre_c = (int)GameData.Instance.magic_all_list.list[n - 100].attack_speed;
        pre_d = (int)GameData.Instance.magic_all_list.list[n - 100].defense;
        pre_e = (int)GameData.Instance.magic_all_list.list[n - 100].move_speed;
        pre_f = (int)GameData.Instance.magic_all_list.list[n - 100].critical_per;

        if (n == 100)
        {
            PreMagic101Upgrade(n);
        }
        else if (n == 101)
        {
            PreMagic102Upgrade(n);
        }
        else if (n == 102)
        {
            PreMagic103Upgrade(n);
        }
        else if (n == 103)
        {
            PreMagic104Upgrade(n);
        }
        else if (n == 104)
        {
            PreMagic105Upgrade(n);
        }
        else if (n == 105)
        {
            PreMagic106Upgrade(n);
        }
        else if (n == 106)
        {
            PreMagic107Upgrade(n);
        }
        else if (n == 107)
        {
            PreMagic108Upgrade(n);
        }
        else if (n == 108)
        {
            PreMagic109Upgrade(n);
        }
        else if (n == 109)
        {
            PreMagic110Upgrade(n);
        }
        else if (n == 110)
        {
            PreMagic111Upgrade(n);
        }
        else if (n == 111)
        {
            PreMagic112Upgrade(n);
        }
        else if (n == 112)
        {
            PreMagic113Upgrade(n);
        }
        else if (n == 113)
        {
            PreMagic114Upgrade(n);
        }
        else if (n == 114)
        {
            PreMagic115Upgrade(n);
        }
        else if (n == 115)
        {
            PreMagic116Upgrade(n);
        }
        else if (n == 116)
        {
            PreMagic117Upgrade(n);
        }
        else if (n == 117)
        {
            PreMagic118Upgrade(n);
        }
        else if (n == 118)
        {
            PreMagic119Upgrade(n);
        }
        else if (n == 119)
        {
            PreMagic120Upgrade(n);
        }
    }

    //버프 미리보기 업그레이드
    void BuffPreUpgrade(int n)
    {
        // pre 변수들 초기화
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage;
        pre_b = (int)GameData.Instance.buff_all_list.list[n - 200].health;
        pre_c = (int)GameData.Instance.buff_all_list.list[n - 200].attack_speed;
        pre_d = (int)GameData.Instance.buff_all_list.list[n - 200].defense;
        pre_e = (int)GameData.Instance.buff_all_list.list[n - 200].move_speed;
        pre_f = (int)GameData.Instance.buff_all_list.list[n - 200].critical_per;

        if (n == 200)
        {
            PreBuff201Upgrade(n);
        }
        else if (n == 201)
        {
            PreBuff202Upgrade(n);
        }
        else if (n == 202)
        {
            PreBuff203Upgrade(n);
        }
        else if (n == 203)
        {
            PreBuff204Upgrade(n);
        }
        else if (n == 204)
        {
            PreBuff205Upgrade(n);
        }
        else if (n == 205)
        {
            PreBuff206Upgrade(n);
        }
        else if (n == 206)
        {
            PreBuff207Upgrade(n);
        }
        else if (n == 207)
        {
            PreBuff208Upgrade(n);
        }
        else if (n == 208)
        {
            PreBuff209Upgrade(n);
        }
        else if (n == 209)
        {
            PreBuff210Upgrade(n);
        }
        else if (n == 210)
        {
            PreBuff211Upgrade(n);
        }
        else if (n == 211)
        {
            PreBuff212Upgrade(n);
        }
    }

    //패시브 미리보기 업그레이드
    void PassivePreUpgrade(int n)
    {
        // pre 변수들 초기화
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage;
        pre_b = (int)GameData.Instance.passive_all_list.list[n - 300].health;
        pre_c = (int)GameData.Instance.passive_all_list.list[n - 300].attack_speed;
        pre_d = (int)GameData.Instance.passive_all_list.list[n - 300].defense;
        pre_e = (int)GameData.Instance.passive_all_list.list[n - 300].move_speed;
        pre_f = (int)GameData.Instance.passive_all_list.list[n - 300].critical_per;

        if (n == 300)
        {
            PrePassive301Upgrade(n);
        }
        else if (n == 301)
        {
            PrePassive302Upgrade(n);
        }
        else if (n == 302)
        {
            PrePassive303Upgrade(n);
        }
        else if (n == 303)
        {
            PrePassive304Upgrade(n);
        }
        else if (n == 304)
        {
            PrePassive305Upgrade(n);
        }
        else if (n == 305)
        {
            PrePassive306Upgrade(n);
        }
        else if (n == 306)
        {
            PrePassive307Upgrade(n);
        }
        else if (n == 307)
        {
            PrePassive308Upgrade(n);
        }
        else if (n == 308)
        {
            PrePassive309Upgrade(n);
        }
    }

    //미리보기 함수
    //원거리 유닛
    void PreRangeUnitUpgrade(int n)
    {
        //공격력 증가 10%
        pre_attack_damage = GameData.Instance.unit_all_list.list[n].attack_damage * 1.1f;

        //체력 증가 10%
        pre_health = GameData.Instance.unit_all_list.list[n].health * 1.1f;

        //방어
        pre_defense = GameData.Instance.unit_all_list.list[n].defense;

        //공격속도 증가 3%
        pre_attack_speed = GameData.Instance.unit_all_list.list[n].attack_speed * 1.03f;

        //이동속도
        pre_move_speed = GameData.Instance.unit_all_list.list[n].move_speed;

        //치명타
        pre_critical = GameData.Instance.unit_all_list.list[n].critical_per;

        //코스트 증가 10%
        pre_cost = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void PreMeleeUnitUpgrade(int n)
    {
        //공격력 증가 15%
        pre_attack_damage = GameData.Instance.unit_all_list.list[n].attack_damage * 1.15f;

        //체력 증가 5%
        pre_health = GameData.Instance.unit_all_list.list[n].health * 1.05f;

        //방어
        pre_defense = GameData.Instance.unit_all_list.list[n].defense;

        //공격속도 증가 5%
        pre_attack_speed = GameData.Instance.unit_all_list.list[n].attack_speed * 1.05f;

        //이동속도
        pre_move_speed = GameData.Instance.unit_all_list.list[n].move_speed;

        //치명타
        pre_critical = GameData.Instance.unit_all_list.list[n].critical_per;

        //코스트 증가 10%
        pre_cost = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void PreTankingUnitUpgrade(int n)
    {
        //공격력 증가 5%
        pre_attack_damage = GameData.Instance.unit_all_list.list[n].attack_damage * 1.05f;

        //체력 증가 15%
        pre_health = GameData.Instance.unit_all_list.list[n].health * 1.15f;

        //방어
        pre_defense = GameData.Instance.unit_all_list.list[n].defense;

        //공격속도 증가 3%
        pre_attack_speed = GameData.Instance.unit_all_list.list[n].attack_speed * 1.03f;

        //이동속도
        pre_move_speed = GameData.Instance.unit_all_list.list[n].move_speed;

        //치명타
        pre_critical = GameData.Instance.unit_all_list.list[n].critical_per;

        //코스트 증가 10%
        pre_cost = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void PreDealTangUnitUpgrade(int n)
    {
        //공격력 증가 10%
        pre_attack_damage = GameData.Instance.unit_all_list.list[n].attack_damage * 1.1f;

        //체력 증가 10%
        pre_health = GameData.Instance.unit_all_list.list[n].health * 1.1f;

        //방어
        pre_defense = GameData.Instance.unit_all_list.list[n].defense;

        //공격속도 증가 3%
        pre_attack_speed = GameData.Instance.unit_all_list.list[n].attack_speed * 1.03f;

        //이동속도
        pre_move_speed = GameData.Instance.unit_all_list.list[n].move_speed;

        //치명타
        pre_critical = GameData.Instance.unit_all_list.list[n].critical_per;

        //코스트 증가 10%
        pre_cost = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void PreAttackSpeedUnitUpgrade(int n)
    {
        //공격력 증가 5%
        pre_attack_damage = GameData.Instance.unit_all_list.list[n].attack_damage * 1.05f;

        //체력 증가 5%
        pre_health = GameData.Instance.unit_all_list.list[n].health * 1.05f;

        //방어
        pre_defense = GameData.Instance.unit_all_list.list[n].defense;

        //공격속도 증가 15%
        pre_attack_speed = GameData.Instance.unit_all_list.list[n].attack_speed * 1.15f;

        //이동속도
        pre_move_speed = GameData.Instance.unit_all_list.list[n].move_speed;

        //치명타
        pre_critical = GameData.Instance.unit_all_list.list[n].critical_per;

        //코스트 증가 10%
        pre_cost = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    void PreCriticalUnitUpgrade(int n)
    {
        //공격력 증가 5%
        pre_attack_damage = GameData.Instance.unit_all_list.list[n].attack_damage * 1.15f;

        //체력 증가 5%
        pre_health = GameData.Instance.unit_all_list.list[n].health * 1.05f;

        //방어
        pre_defense = GameData.Instance.unit_all_list.list[n].defense;

        //공격속도 증가 5%
        pre_attack_speed = GameData.Instance.unit_all_list.list[n].attack_speed * 1.05f;

        //이동속도
        pre_move_speed = GameData.Instance.unit_all_list.list[n].move_speed;

        //치명타 증가 5%
        pre_critical = GameData.Instance.unit_all_list.list[n].critical_per + 5;

        //코스트 증가 10%
        pre_cost = (int)(GameData.Instance.unit_all_list.list[n].cost1 * 1.1f);
    }

    //마법
    //1번효과 = attack_damage, 2번효과 = health, 3번효과 = attack_speed, 4번효과 = defense, 5번효과 = move_speed, 6번효과 = critical
    //욕망의 당근
    void PreMagic101Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //일정 구간마다 뽑는카드 증가
        if (GameData.Instance.magic_all_list.list[n - 100].unit_level == 3)
        {
            pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage + 1);
        }
        else if (GameData.Instance.magic_all_list.list[n - 100].unit_level == 6)
        {
            pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage + 1);
        }
        else if (GameData.Instance.magic_all_list.list[n - 100].unit_level == 9)
        {
            pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage + 1);
        }
    }

    //리로드
    void PreMagic102Upgrade(int n)
    {
        //코스트 -3
        //GameData.Instance.unit_all_list.list[n - 100].cost1 -= 3;
    }

    //맥가이버 패키지
    void PreMagic103Upgrade(int n)
    {

    }

    //천재지변 패키지
    void PreMagic104Upgrade(int n)
    {

    }

    //폭풍 레벨업 패키지
    void PreMagic105Upgrade(int n)
    {

    }

    //두근두근 슬롯머신
    void PreMagic106Upgrade(int n)
    {
        //코스트 -4
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 0.95f);
    }

    //긴급 출동 패밀리
    void PreMagic107Upgrade(int n)
    {
        //코스트 증가 10%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //소환 유닛 수
        pre_a = (int)GameData.Instance.magic_all_list.list[n - 100].attack_damage + 1;
    }

    //약탈
    void PreMagic108Upgrade(int n)
    {
        //코스트 증가 10%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);

        //미네랄 약탈 증가 20%
        pre_b = (int)(GameData.Instance.magic_all_list.list[n - 100].health * 1.2f);
    }

    //피버타임
    void PreMagic109Upgrade(int n)
    {
        //코스트 증가 10%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.1f);

        //미네랄 증가 +5
        pre_a = (int)GameData.Instance.magic_all_list.list[n - 100].health + 5;
    }

    //뽑기의 달인
    void PreMagic110Upgrade(int n)
    {
        //코스트 증가 10%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.1f);

        //노말 유닛 확률 감소 -5
        pre_a = (int)GameData.Instance.magic_all_list.list[n - 100].attack_damage - 5;

        //레어 유닛 확률 증가 +3
        pre_b = (int)GameData.Instance.magic_all_list.list[n - 100].health + 3;

        //스페셜 유닛 확률 증가 +2
        pre_c = (int)GameData.Instance.magic_all_list.list[n - 100].attack_speed + 2;
    }

    //유기농 당근
    void PreMagic111Upgrade(int n)
    {
        //미네랄 획득 증가 10%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.1f);
    }

    //대규모 광부 채용
    void PreMagic112Upgrade(int n)
    {
        //코스트 증가 10%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.1f);

        //이동속도 증가 +1%
        pre_a = (int)GameData.Instance.magic_all_list.list[n - 100].attack_damage + 1;

        //광부 수 증가 +1
        pre_c = (int)GameData.Instance.magic_all_list.list[n - 100].attack_speed + 1;
    }

    //소나기(미스포차)
    void PreMagic113Upgrade(int n)
    {
        //코스트 증가 10%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);

        //이동속도 감소 10%
        pre_b = (int)(GameData.Instance.magic_all_list.list[n - 100].health * 1.1f);

    }

    //날벼락
    void PreMagic114Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);

        //공격속도 감소량 증가 10%
        pre_b = (int)(GameData.Instance.magic_all_list.list[n - 100].health * 1.1f);
    }

    //대폭발 (폭주기관차)
    void PreMagic115Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 40%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.4f);
    }

    //당근폭탄 (양자폭탄)
    void PreMagic116Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);

        //초당 화상 데미지 증가 20%
        pre_b = (int)(GameData.Instance.magic_all_list.list[n - 100].health * 1.2f);
    }

    //전염병
    void PreMagic117Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 20%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.2f);
    }

    //폭탄 토끼
    void PreMagic118Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 30%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.3f);
    }

    //독 안개
    void PreMagic119Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //데미지 증가 20%
        pre_a = (int)(GameData.Instance.magic_all_list.list[n - 100].attack_damage * 1.2f);
    }

    //프렌드 실드
    void PreMagic120Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.magic_all_list.list[n - 100].cost1 = (int)(GameData.Instance.magic_all_list.list[n - 100].cost1 * 1.05f);

        //체력 증가 +50
        pre_a = (int)GameData.Instance.magic_all_list.list[n - 100].attack_damage + 50;

        //지속시간 증가 +1
        pre_b = (int)GameData.Instance.magic_all_list.list[n - 100].health + 1;
    }


    //버프
    //긴급 수혈
    void PreBuff201Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //회복량 증가 +5
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 5;
    }

    //치얼스
    void PreBuff202Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //공격력 버프량 증가 +5
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 5;
    }

    //금광 발견
    void PreBuff203Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //이동속도 버프량 증가 +5
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 5;
    }

    //해체쇼
    void PreBuff204Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //데미지 증가 5%
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 5;
    }

    //토끼 수집가
    void PreBuff205Upgrade(int n)
    {
        //코스트 증가 8%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.08f);

        //미네랄 획득량 증가 +5
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 5;
    }

    //광전사
    void PreBuff206Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //공격력 버프 증가 +10
        pre_c = (int)GameData.Instance.buff_all_list.list[n - 200].attack_speed + 10;

        //공격속도 버프 증가 +10
        pre_d = (int)GameData.Instance.buff_all_list.list[n - 200].defense + 10;
    }

    //행운의 포춘쿠키
    void PreBuff207Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //성공확률 증가 +5
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 5;
    }

    //단단한 피부
    void PreBuff208Upgrade(int n)
    {

    }

    //미니언의 분노
    void PreBuff209Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //미니언 공격력 버프 증가 +5
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 5;

        //미니언 체력 버프 증가 +5
        pre_b = (int)GameData.Instance.buff_all_list.list[n - 200].health + 5;
    }

    //천사의 선율 (치유토템)
    void PreBuff210Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //초당 체력 회복량 증가 +1
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 1;
    }

    //태엽 감기 (헤이스트)
    void PreBuff211Upgrade(int n)
    {
        //코스트 증가 5%
        //GameData.Instance.buff_all_list.list[n - 200].cost1 = (int)(GameData.Instance.buff_all_list.list[n - 200].cost1 * 1.05f);

        //공격속도 버프 증가 +5
        pre_a = (int)GameData.Instance.buff_all_list.list[n - 200].attack_damage + 5;

        //이동속도 버프 증가 +5
        pre_b = (int)GameData.Instance.buff_all_list.list[n - 200].health + 5;
    }

    //너만믿는다
    void PreBuff212Upgrade(int n)
    {

    }


    //패시브
    //풍성한 돈다발
    void PrePassive301Upgrade(int n)
    {
        //획득 골드 증가 +5
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 5;
    }

    //단단한 철방패
    void PrePassive302Upgrade(int n)
    {
        //아군유닛 체력 증가 +50
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 50;
    }

    //신속의 장화
    void PrePassive303Upgrade(int n)
    {
        //이동속도 증가 +1
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 1;
    }

    //인첸트 소드
    void PrePassive304Upgrade(int n)
    {
        //레어유닛 데미지 증가 +5
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 5;
    }

    //피칠갑 단도
    void PrePassive305Upgrade(int n)
    {
        //아군유닛 흡혈량 증가 +2
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 2;
    }

    //금지된 마도서
    void PrePassive306Upgrade(int n)
    {
        //마법카드 공격력 증가 +5
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 5;
    }

    //대장군 언월도
    void PrePassive307Upgrade(int n)
    {
        //아군 유닛 공격력 증가 +10
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 10;
    }

    //바람의 창
    void PrePassive308Upgrade(int n)
    {
        //아군 유닛 공격속도 증가 +10
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 10;
    }

    //도박꾼의 카드
    void PrePassive309Upgrade(int n)
    {
        //카드 드로우시 한번 더 뽑을확률 증가 +10
        pre_a = (int)GameData.Instance.passive_all_list.list[n - 300].attack_damage + 10;
    }

    //슬라이드 최신화
    public void SliderUpdate()
    {
        if (num < 100)
        {
            deck_data.GetComponent<DeckData>().all_unit_list[num].unit_object.GetComponent<UnitCountSlider>().SliderInit();
        }
        else if (num < 200)
        {
            deck_data.GetComponent<DeckData>().all_magic_list[num - 100].unit_object.GetComponent<UnitCountSlider>().SliderInit();
        }
        else if (num < 300)
        {
            deck_data.GetComponent<DeckData>().all_buff_list[num - 200].unit_object.GetComponent<UnitCountSlider>().SliderInit();
        }
        else if (num < 400)
        {
            deck_data.GetComponent<DeckData>().all_passive_list[num - 300].unit_object.GetComponent<UnitCountSlider>().SliderInit();
        }
    }
}