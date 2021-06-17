using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Change : MonoBehaviour
{/*
    //게임시스템
    //public GameObject gameSystem;
    //public GameSystem gameSystem_script;

    //이미지 컴포넌트
    public Image icon;
    //부모 storage 스크립트
    public Storage_Select parent_storage;
    //1성 아이콘 모음집
    public GameObject icon_parent_1;
    //2성 아이콘 모음집
    public GameObject icon_parent_2;

    // Start is called before the first frame update
    void Start()
    {
        icon = GetComponent<Image>();
        parent_storage = transform.parent.GetComponent<Storage_Select>();
    }

    // Update is called once per frame
    void Update()
    {
        //스토리지 차있을때
        if (parent_storage.is_full == true)
        {
            //활성화
            icon.enabled = true;
            if(parent_storage.unit_number / 1000 == 0)
            {
                icon.sprite = icon_parent_1.transform.GetChild(parent_storage.unit_number - 1).GetComponent<SpriteRenderer>().sprite;
            }
            else if (parent_storage.unit_number / 1000 == 1)
            {
                icon.sprite = icon_parent_2.transform.GetChild(parent_storage.unit_number - 1001).GetComponent<SpriteRenderer>().sprite;
            }

        }
        else if (parent_storage.is_full == false)
        {
            //비활성화
            icon.enabled = false;
        }
    }*/
}
