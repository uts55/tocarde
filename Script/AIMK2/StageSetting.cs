using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class setting
{
    public bool active;
    public float rezentime;
}
public class StageSetting : MonoBehaviour
{
    public string file;
    GameManager gamemanager;
    EnemyCall call;
    setting[] set;
    void Awake()
    {
        call = GetComponent<EnemyCall>();
        gamemanager = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<GameManager>();
        Read(file, gamemanager.stage - 1);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Read(string file, int line)
    {
        StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/" + file);
        int lineofFile = 0;
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }

            if (lineofFile == line)
            {
                var data_values = data_String.Split(',');
                for (int i = 0; i <= call.S.Length; i++)
                {
                    call.S[i].isactive = bool.Parse(data_values[i * 2 + 1]);
                    call.S[i].Rezentime = float.Parse(data_values[i * 2]);
                }
            }
            lineofFile++;
        }
    }
}
