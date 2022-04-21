using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartSence : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown )
        {
            videoPlayer.Pause();
        }
        if(videoPlayer.isPaused)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("RobLoad/RobLoadCanvas"));

            go.GetComponent<SceneLoad>().TargetSceneName = ScenceName.scenceMain;
            Destroy(this.gameObject);
        }
    }
}
