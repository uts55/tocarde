using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class wavetoggle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public WaveSystem wavesystem;
    public List<Sprite> enemypic;
    public GameObject nul;
    Image toggleup;
    public void OnPointerEnter(PointerEventData eventData)
    {
        toggleup.gameObject.SetActive(true);
        for (int i = 0; i < wavesystem.waves[wavesystem.thisWave+1].Unit.Count; i++)
        {
            nul = new GameObject();
            nul.AddComponent<Image>();
            for (int j = 0; j < wavesystem.EnemyList.Count; j++)
            {
                if(wavesystem.waves[wavesystem.thisWave + 1].Unit[i] == wavesystem.EnemyList[j])
                {
                    nul.GetComponent<Image>().sprite = enemypic[j];
                }
            }
            GameObject unit = Instantiate(nul, transform.position, Quaternion.identity);
            unit.transform.SetParent(toggleup.transform);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toggleup.gameObject.SetActive(false);
        Transform[] childlist = toggleup.GetComponentsInChildren<Transform>();
        for (int i = 1; i < childlist.Length; i++)
        {
            Destroy(childlist[i].gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        toggleup = GetComponentInChildren<Image>();
        toggleup.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}