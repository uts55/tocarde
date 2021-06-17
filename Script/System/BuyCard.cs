using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCard : MonoBehaviour
{
    public int rand_index;
    public int rand_count;
    int rand_grade_percent;

    public int unit_number;

    public GameObject panel_gem;
    public GameObject panel_gold;

    public GameObject panel_gotcha;

    public Text unit_name_text;

    //골드뽑기
    public void GoldCardGotcha()
    {
        if (GameData.Instance.basic_data.account_gold >= 5000)
        {
            rand_grade_percent = Random.Range(0, 100);

            if (rand_grade_percent < 80)
            {
                //임시로 일반 봉인
                //BuyNormalCard();
                BuyUniqueCard();
            }
            else if (rand_grade_percent < 100)
            {
                BuyUniqueCard();
            }
        }
        else
        {

        }
    }

    //보석뽑기
    public void GemCardGotcha()
    {
        if (GameData.Instance.basic_data.account_gem >= 30)
        {
            rand_grade_percent = Random.Range(0, 100);

            if (rand_grade_percent < 35)
            {
                //임시봉인
                //BuyNormalCard();
                BuyUniqueCard();
            }
            else if (rand_grade_percent < 95)
            {
                BuyUniqueCard();
            }
            else if (rand_grade_percent < 100)
            {
                BuyLegendCard();
            }
        }
        else
        {

        }
    }

    //광고뽑기
    public void AdCardGotcha()
    {
        rand_grade_percent = Random.Range(0, 100);

        if (rand_grade_percent < 60)
        {
            //임시봉인
            //BuyNormalCard();
            BuyUniqueCard();
        }
        else if (rand_grade_percent < 98)
        {
            BuyUniqueCard();
        }
        else if (rand_grade_percent < 100)
        {
            BuyLegendCard();
        }
    }

    //노말뽑기
    public void BuyNormalCard()
    {
        rand_index = Random.Range(0, GameData.Instance.normal_card_list.list.Count);

        unit_number = GameData.Instance.normal_card_list.list[rand_index];

        //유닛일때
        if (unit_number < 100)
        {
            if (GameData.Instance.unit_all_list.list[unit_number].is_have == false)
            {
                GameData.Instance.unit_all_list.list[unit_number].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.unit_all_list.list[unit_number].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.unit_all_list.list[unit_number].unit_name;
        }
        //마법일때
        else if (unit_number < 200)
        {
            if (GameData.Instance.magic_all_list.list[unit_number - 100].is_have == false)
            {
                GameData.Instance.magic_all_list.list[unit_number - 100].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.magic_all_list.list[unit_number - 100].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.magic_all_list.list[unit_number - 100].unit_name;
        }
        //버프일때
        else if (unit_number < 300)
        {
            if (GameData.Instance.buff_all_list.list[unit_number - 200].is_have == false)
            {
                GameData.Instance.buff_all_list.list[unit_number - 200].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.buff_all_list.list[unit_number - 200].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.buff_all_list.list[unit_number - 200].unit_name;
        }
        //패시브일때
        else
        {
            if (GameData.Instance.passive_all_list.list[unit_number - 300].is_have == false)
            {
                GameData.Instance.passive_all_list.list[unit_number - 300].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.passive_all_list.list[unit_number - 300].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.passive_all_list.list[unit_number - 300].unit_name;
        }

        Debug.Log(rand_count);

        panel_gotcha.SetActive(true);
    }


    //유니크뽑기
    public void BuyUniqueCard()
    {
        rand_index = Random.Range(0, GameData.Instance.unique_card_list.list.Count);

        unit_number = GameData.Instance.unique_card_list.list[rand_index];

        //유닛일때
        if (unit_number < 100)
        {
            if (GameData.Instance.unit_all_list.list[unit_number].is_have == false)
            {
                //임시봉인
                //GameData.Instance.unit_all_list.list[unit_number].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.unit_all_list.list[unit_number].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.unit_all_list.list[unit_number].unit_name;
        }
        //마법일때
        else if (unit_number < 200)
        {
            if (GameData.Instance.magic_all_list.list[unit_number - 100].is_have == false)
            {
                //GameData.Instance.magic_all_list.list[unit_number - 100].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.magic_all_list.list[unit_number - 100].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.magic_all_list.list[unit_number - 100].unit_name;
        }
        //버프일때
        else if (unit_number < 300)
        {
            if (GameData.Instance.buff_all_list.list[unit_number - 200].is_have == false)
            {
                //GameData.Instance.buff_all_list.list[unit_number - 200].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.buff_all_list.list[unit_number - 200].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.buff_all_list.list[unit_number - 200].unit_name;
        }
        //패시브일때
        else
        {
            if (GameData.Instance.passive_all_list.list[unit_number - 300].is_have == false)
            {
                //GameData.Instance.passive_all_list.list[unit_number - 300].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.passive_all_list.list[unit_number - 300].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.passive_all_list.list[unit_number - 300].unit_name;
        }
        panel_gotcha.SetActive(true);
    }

    //레전드뽑기
    public void BuyLegendCard()
    {
        rand_index = Random.Range(0, GameData.Instance.legend_card_list.list.Count);

        unit_number = GameData.Instance.legend_card_list.list[rand_index];

        //유닛일때
        if (unit_number < 100)
        {
            if (GameData.Instance.unit_all_list.list[unit_number].is_have == false)
            {
                //GameData.Instance.unit_all_list.list[unit_number].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.unit_all_list.list[unit_number].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.unit_all_list.list[unit_number].unit_name;
        }
        //마법일때
        else if (unit_number < 200)
        {
            if (GameData.Instance.magic_all_list.list[unit_number - 100].is_have == false)
            {
                //GameData.Instance.magic_all_list.list[unit_number - 100].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.magic_all_list.list[unit_number - 100].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.magic_all_list.list[unit_number - 100].unit_name;
        }
        //버프일때
        else if (unit_number < 300)
        {
            if (GameData.Instance.buff_all_list.list[unit_number - 200].is_have == false)
            {
                //GameData.Instance.buff_all_list.list[unit_number - 200].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.buff_all_list.list[unit_number - 200].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.buff_all_list.list[unit_number - 200].unit_name;
        }
        //패시브일때
        else
        {
            if (GameData.Instance.passive_all_list.list[unit_number - 300].is_have == false)
            {
                //GameData.Instance.passive_all_list.list[unit_number - 300].is_have = true;
            }
            else
            {
                rand_count = Random.Range(1, 11);
                GameData.Instance.passive_all_list.list[unit_number - 300].unit_count += rand_count;
            }
            unit_name_text.text = GameData.Instance.passive_all_list.list[unit_number - 300].unit_name;
        }
        panel_gotcha.SetActive(true);
    }

    //보석 부족할때
    public void NotEnoughGem()
    {
        //이미 켜져있음
        if (panel_gem.activeSelf == true)
        {
            return;
        }

        //아니면
        float time = 0;
        time += Time.deltaTime * 1.0f;
        panel_gem.SetActive(true);
        if (time >= 3.0f)
        {
            panel_gem.SetActive(false);
            return;
        }
    }

    //골드 부족할때
    public void NotEnoughGold()
    {
        //이미 켜져있음
        if (panel_gold.activeSelf == true)
        {
            return;
        }

        //아니면
        float time = 0;
        time += Time.deltaTime * 1.0f;
        panel_gold.SetActive(true);
        if (time >= 3.0f)
        {
            panel_gold.SetActive(false);
            return;
        }
    }
}
