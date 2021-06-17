using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardStatus : MonoBehaviour
{
    //이름, 인구, 하위자원, 고급자원
    public int number;
    public string u_name;
    public int population;
    public int cost_low;
    public string description;

    //텍스트의 오브젝트
    public GameObject name_object;
    public GameObject population_object;
    public GameObject cost_object;
    public GameObject description_object;

    //텍스트들
    TextMeshProUGUI name_text;
    TextMeshProUGUI population_text;
    TextMeshProUGUI cost_low_text;
    TextMeshProUGUI description_text;
    public bool selectable;

    //설명문을 위해서
    int a;
    int b;
    int c;
    int d;
    int e;
    int f;

    private void Awake()
    {
        name_object = transform.GetChild(9).gameObject;
        population_object = transform.GetChild(10).gameObject;
        cost_object = transform.GetChild(11).gameObject;
        description_object = transform.GetChild(12).gameObject;
    }

    //추후에 마법이나 그런것들 추가
    public void StatusSetting(int unit_number, string unit_name, int unit_population, int unit_cost_low, string unit_description)
    {
        number = unit_number;
        u_name = unit_name;
        population = unit_population;
        cost_low = unit_cost_low;
        description = unit_description;
        if (number == 114 || number == 116 || number == 119 || number == 120 || number == 210)
        {
            selectable = true;
        }
        else
        {
            selectable = false;
        }
        TextInit();
    }

    public void TextInit()
    {
        //텍스트 연결
        name_text = name_object.GetComponent<TextMeshProUGUI>();
        population_text = population_object.GetComponent<TextMeshProUGUI>();
        cost_low_text = cost_object.GetComponent<TextMeshProUGUI>();
        description_text = description_object.GetComponent<TextMeshProUGUI>();


        DescriptionUpdate(number - 1);

        //텍스트에 입력
        name_text.text = u_name;
        population_text.text = population.ToString();
        cost_low_text.text = cost_low.ToString();
        description_text.text = description;
    }

    //정보창 업데이트
    public void DescriptionUpdate(int num)
    {
        if (num < 100)
        {
            a = (int)GameData.Instance.unit_all_list.list[num].attack_damage;
            b = (int)GameData.Instance.unit_all_list.list[num].health;
            c = (int)GameData.Instance.unit_all_list.list[num].attack_speed;
            d = (int)GameData.Instance.unit_all_list.list[num].defense;
            e = (int)GameData.Instance.unit_all_list.list[num].move_speed;
            f = (int)GameData.Instance.unit_all_list.list[num].critical_per;

            description = string.Format(GameData.Instance.unit_all_list.list[num].description, a, b, c, d, e, f);
        }
        else if (num < 200)
        {
            a = (int)GameData.Instance.magic_all_list.list[num - 100].attack_damage;
            b = (int)GameData.Instance.magic_all_list.list[num - 100].health;
            c = (int)GameData.Instance.magic_all_list.list[num - 100].attack_speed;
            d = (int)GameData.Instance.magic_all_list.list[num - 100].defense;
            e = (int)GameData.Instance.magic_all_list.list[num - 100].move_speed;
            f = (int)GameData.Instance.magic_all_list.list[num - 100].critical_per;

            description = string.Format(GameData.Instance.magic_all_list.list[num - 100].description, a, b, c, d, e, f);
        }
        else if (num < 300)
        {
            a = (int)GameData.Instance.buff_all_list.list[num - 200].attack_damage;
            b = (int)GameData.Instance.buff_all_list.list[num - 200].health;
            c = (int)GameData.Instance.buff_all_list.list[num - 200].attack_speed;
            d = (int)GameData.Instance.buff_all_list.list[num - 200].defense;
            e = (int)GameData.Instance.buff_all_list.list[num - 200].move_speed;
            f = (int)GameData.Instance.buff_all_list.list[num - 200].critical_per;

            description = string.Format(GameData.Instance.buff_all_list.list[num - 200].description, a, b, c, d, e, f);
        }
        else if (num < 400)
        {
            a = (int)GameData.Instance.passive_all_list.list[num - 300].attack_damage;
            b = (int)GameData.Instance.passive_all_list.list[num - 300].health;
            c = (int)GameData.Instance.passive_all_list.list[num - 300].attack_speed;
            d = (int)GameData.Instance.passive_all_list.list[num - 300].defense;
            e = (int)GameData.Instance.passive_all_list.list[num - 300].move_speed;
            f = (int)GameData.Instance.passive_all_list.list[num - 300].critical_per;

            description = string.Format(GameData.Instance.passive_all_list.list[num - 300].description, a, b, c, d, e, f);
        }
    }
}
