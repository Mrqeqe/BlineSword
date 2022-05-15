using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMainSence : MonoBehaviour
{
   
    public static void ReturnMainSenceLoad()
    {

        GameObject go = Instantiate(Resources.Load<GameObject>("RobLoad/RobLoadCanvas"));
        Time.timeScale = 1;
        go.GetComponent<SceneLoad>().TargetSceneName = ScenceName.scenceMain;
    }
}
