using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class setResolution : MonoBehaviour
{
    private void start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1400, 1080, false);
    }
}
