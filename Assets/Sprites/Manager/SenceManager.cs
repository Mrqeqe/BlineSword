using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceManager : MonoBehaviour
{
    
    public AutoCenterView autoCenterView;

    public int SenceCount = 2;

    // Update is called once per frame
    void Update()
    {
        string senceNameToLoad = "";

        switch(autoCenterView.curCenterChildIndex)
        {
            case 0: 
                senceNameToLoad = ScenceName.Game_1;
                 break;
            case 1:
                senceNameToLoad = ScenceName.Game_2;
                break;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& autoCenterView.curCenterChildIndex <SenceCount)
        {
            
            GameObject go = Instantiate(Resources.Load<GameObject>("RobLoad/RobLoadCanvas"));

            go.GetComponent<SceneLoad>().TargetSceneName = senceNameToLoad;
        }
    }
}
