using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

[Serializable]
public class Obj
{
    public List<GameObject> Lists = new List<GameObject>();
}
public class ActiveManager : MonoBehaviour
{
    public List<Obj> Objs = new List<Obj>();
    Template_UIManager manager;
    CardDraw DrawSystem;
    WaveSystem wavesystem;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<Template_UIManager>();
        StartCoroutine(start());
        DrawSystem = GameObject.FindGameObjectWithTag("Drawsystem").GetComponent<CardDraw>();
        wavesystem = GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>();
    }
    IEnumerator start()
    {
        yield return new WaitForSeconds(0.1f);
        VIDE_Assign vide = GetComponent<VIDE_Assign>();
        manager.Interact(vide);
        Timestop();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void OnActive(int number)
    {
        for (int i = 0; i < Objs[number].Lists.Count; i++)
        {
            Objs[number].Lists[i].SetActive(true);
        }
    }
    public void OffActive(int number)
    {
        for (int i = 0; i < Objs[number].Lists.Count; i++)
        {
            Objs[number].Lists[i].SetActive(false);
        }
    }
    public void Timestop()
    {
        Time.timeScale = 0;
    }
    public void TimeStart()
    {
        Time.timeScale = 1;
    }
    public void Interact()
    {
        manager.Interact(VD.assigned);
    }
    public void EnemyCloseUp()
    {
        Camera.main.transform.position = new Vector3(2.5f,0,-20);
    }
    public void AllyCloseUp()
    {
        Camera.main.transform.position = new Vector3(-25f,0,-20);
    }
    public void GiveMoney(int a)
    {
        GameManager.Instance.gold += a;
    }
    public void SetDraw(int a)
    {
        DrawSystem.SettingDraw(a);
    }
    public void Wait(float a)
    {
        StartCoroutine(WaitSeconds(a));
    }
    IEnumerator WaitSeconds(float a)
    {
        yield return new WaitForSeconds(a);
        Interact();
    }
    public void Trash()
    {
        DrawSystem.DeleteHandAll();
    }
    public void StartGame()
    {
        DrawSystem.Istutorial = false;
    }
    public void Skip()
    {
        wavesystem.skip = true;
        wavesystem.Skip();
        wavesystem.skip = false;
    }
}
