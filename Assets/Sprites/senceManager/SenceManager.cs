using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceManager : MonoBehaviour
{
    
    public AutoCenterView autoCenterView;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string senceNameToLoad;

        switch(autoCenterView.curCenterChildIndex)
        {
            case 0: 
                senceNameToLoad = ScenceName.Game_1;
                 break;
            case 1:
                senceNameToLoad = ScenceName.Game_2;
                break;
            case 2:
                senceNameToLoad = ScenceName.Game_3;
                break;
            case 3:
                senceNameToLoad = ScenceName.Game_4;
                break;
            case 4:
                senceNameToLoad = ScenceName.Game_5;
                break;
            default:
                senceNameToLoad = ScenceName.Game_1;
                break;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("RobLoad/RobLoadCanvas"));

            go.GetComponent<SceneLoad>().TargetSceneName = senceNameToLoad;
        }
    }
}
