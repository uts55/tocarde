using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitCountSlider : MonoBehaviour
{
    //슬라이더, 맥스 슬라이더
    public Slider count_slider;
    public Slider max_slider;

    //카드갯수
    public int card_count;
    public int max_count;

    //텍스트
    public TextMeshProUGUI count_slider_level_text;
    public TextMeshProUGUI count_slider_count_text;

    public TextMeshProUGUI max_slider_level_text;

    //넘버
    public int num;

    private void Awake()
    {
        num = int.Parse(gameObject.transform.name);

        count_slider = gameObject.transform.GetChild(5).GetComponent<Slider>();
        max_slider = gameObject.transform.GetChild(6).GetComponent<Slider>();

        count_slider_count_text = count_slider.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        count_slider_level_text = count_slider.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();

        max_slider_level_text = max_slider.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();

        count_slider.gameObject.SetActive(true);
        max_slider.gameObject.SetActive(false);
    }

    private void Start()
    {
        SliderInit();
    }

    public void SliderInit()
    {
        if (num < 100)
        {
            if (GameData.Instance.unit_all_list.list[num].is_have == true)
            {
                if (GameData.Instance.unit_all_list.list[num].grade == 0)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 0);
                    }
                    else if(GameData.Instance.unit_all_list.list[num].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 2);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 4);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 10);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 5)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 20);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 6)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 50);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 7)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 100);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 8)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 200);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 9)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 400);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 10)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].grade == 1)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 2);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 4);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 10);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 20);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 5)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 50);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 6)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 100);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 7)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 200);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 8)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
                else if (GameData.Instance.unit_all_list.list[num].grade == 2)
                {
                    if (GameData.Instance.unit_all_list.list[num].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 2);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 4);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 10);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.unit_all_list.list[num].unit_count, 20);
                    }
                    else if (GameData.Instance.unit_all_list.list[num].unit_level == 5)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
            }
            else
            {
                count_slider.gameObject.SetActive(false);
                max_slider.gameObject.SetActive(false);
            }
        }
        else if (num < 200)
        {
            if (GameData.Instance.magic_all_list.list[num - 100].is_have == true)
            {
                if (GameData.Instance.magic_all_list.list[num - 100].grade == 0)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 0);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 2);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 4);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 10);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 5)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 20);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 6)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 50);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 7)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 100);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 8)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 200);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 9)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 400);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 10)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].grade == 1)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 2);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 4);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 10);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 20);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 5)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 50);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 6)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 100);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 7)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 200);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 8)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
                else if (GameData.Instance.magic_all_list.list[num - 100].grade == 2)
                {
                    if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 2);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 4);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 10);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.magic_all_list.list[num - 100].unit_count, 20);
                    }
                    else if (GameData.Instance.magic_all_list.list[num - 100].unit_level == 5)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
            }
            else
            {
                count_slider.gameObject.SetActive(false);
                max_slider.gameObject.SetActive(false);
            }
        }
        else if (num < 300)
        {
            if (GameData.Instance.buff_all_list.list[num - 200].is_have == true)
            {
                if (GameData.Instance.buff_all_list.list[num - 200].grade == 0)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 0);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 2);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 4);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 10);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 5)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 20);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 6)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 50);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 7)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 100);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 8)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 200);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 9)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 400);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 10)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].grade == 1)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 2);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 4);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 10);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 20);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 5)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 50);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 6)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 100);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 7)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 200);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 8)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
                else if (GameData.Instance.buff_all_list.list[num - 200].grade == 2)
                {
                    if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 2);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 4);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 10);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.buff_all_list.list[num - 200].unit_count, 20);
                    }
                    else if (GameData.Instance.buff_all_list.list[num - 200].unit_level == 5)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
            }
            else
            {
                count_slider.gameObject.SetActive(false);
                max_slider.gameObject.SetActive(false);
            }
        }
        else if (num < 400)
        {
            if (GameData.Instance.passive_all_list.list[num - 300].is_have == true)
            {
                if (GameData.Instance.passive_all_list.list[num - 300].grade == 0)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 0);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 2);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 4);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 10);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 5)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 20);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 6)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 50);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 7)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 100);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 8)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 200);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 9)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 400);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 10)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].grade == 1)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 2);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 4);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 10);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 20);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 5)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 50);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 6)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 100);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 7)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 200);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 8)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
                else if (GameData.Instance.passive_all_list.list[num - 300].grade == 2)
                {
                    if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 1)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 2);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 2)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 4);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 3)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 10);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 4)
                    {
                        SetCoundAndMax(GameData.Instance.passive_all_list.list[num - 300].unit_count, 20);
                    }
                    else if (GameData.Instance.passive_all_list.list[num - 300].unit_level == 5)
                    {
                        count_slider.gameObject.SetActive(false);
                        max_slider.gameObject.SetActive(true);
                        TextUpdate();
                    }
                }
            }
            else
            {
                count_slider.gameObject.SetActive(false);
                max_slider.gameObject.SetActive(false);
            }
        }
    }

    public void SetCoundAndMax(int count, int max)
    {
        Debug.Log(count);
        count_slider.maxValue = max;
        count_slider.value = count;

        if (count > max)
        {
            count_slider.value = max;
        }
        count_slider_count_text.text = count.ToString() + " / " + max.ToString();

        TextUpdate();
    }

    public void TextUpdate()
    {
        if (num < 100)
        {
            count_slider_level_text.text = GameData.Instance.unit_all_list.list[num].unit_level.ToString();
            max_slider_level_text.text = GameData.Instance.unit_all_list.list[num].unit_level.ToString();
        }
        else if (num < 200)
        {
            count_slider_level_text.text = GameData.Instance.magic_all_list.list[num - 100].unit_level.ToString();
            max_slider_level_text.text = GameData.Instance.magic_all_list.list[num - 100].unit_level.ToString();
        }
        else if (num < 300)
        {
            count_slider_level_text.text = GameData.Instance.buff_all_list.list[num - 200].unit_level.ToString();
            max_slider_level_text.text = GameData.Instance.buff_all_list.list[num - 200].unit_level.ToString();
        }
        else if (num < 400)
        {
            count_slider_level_text.text = GameData.Instance.passive_all_list.list[num - 300].unit_level.ToString();
            max_slider_level_text.text = GameData.Instance.passive_all_list.list[num - 300].unit_level.ToString();
        }
    }
}

